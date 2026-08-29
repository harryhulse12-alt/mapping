using Content.Shared.Examine;
using Content.Shared.Random.Helpers;
using Robust.Shared.Random;
using System.Reflection;
using System.Collections;
using Robust.Shared.Prototypes;

namespace Content.Omu.Server.Entities.SalvageLoot;

public sealed class RandomCompsSystem : EntitySystem
{
    [Dependency] private readonly IRobustRandom _random = default!;
    [Dependency] private readonly IEntityManager _entManager = null!;
    [Dependency] private readonly IComponentFactory _comp = default!;
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<RandomCompsComponent, ExaminedEvent>(OnExamine);
        SubscribeLocalEvent<RandomCompsComponent, MapInitEvent>(OnInit);
    }

    private void OnExamine(Entity<RandomCompsComponent> ent, ref ExaminedEvent args)
    {
        args.PushMarkup(Loc.GetString(ent.Comp.ExamineBaseMessage));
    }

    private void OnInit(EntityUid obj, RandomCompsComponent component, ref MapInitEvent args)
    {
        if (component.Comps is null)
            return;

        var list = component.Comps;

        for (int i = 0; i < component.NumberOfComps; i++)
        {
            if (list is null)
                return;

            var compList = _random.Pick(list);

            foreach (var compString in compList.Components)
            {

                if (!compList.Components.TryGetComponent(compString.Key, out var comp))
                    continue;

                if (_comp.TryGetRegistration(compString.Key, out var registration))
                    if (_entManager.HasComponent(obj, registration))
                    {
                        var existing = _entManager.GetComponent(obj, registration.Type);
                        MergeComponent(existing, comp);
                        continue;
                    }

                _entManager.AddComponent(obj, comp);
            }
            list.Remove(compList);
        }
    }

    private void MergeComponent(IComponent target, IComponent incoming)
    {
        var type = target.GetType();

        foreach (var property in type.GetProperties(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic))
        {
            var dataField = property.GetCustomAttribute<DataFieldAttribute>();

            if (dataField == null)
                continue;

            if (!property.CanRead)
                continue;

            var incomingValue = property.GetValue(incoming);

            if (incomingValue == null)
                continue;

            var targetValue = property.GetValue(target);

            if (incomingValue is IList incomingList &&
                targetValue is IList targetList)
            {
                foreach (var item in incomingList)
                    targetList.Add(item);

                continue;
            }

            if (incomingValue is IDictionary incomingDict &&
                targetValue is IDictionary targetDict)
            {
                foreach (DictionaryEntry entry in incomingDict)
                    targetDict[entry.Key] = entry.Value;

                continue;
            }

            if (incomingValue is ComponentRegistry incomingRegistry &&
                targetValue is ComponentRegistry targetRegistry)
            {
                foreach (var (key, entry) in incomingRegistry)
                    targetRegistry[key] = entry;

                continue;
            }

            if (property.CanWrite)
                property.SetValue(target, incomingValue);
        }
    }
}

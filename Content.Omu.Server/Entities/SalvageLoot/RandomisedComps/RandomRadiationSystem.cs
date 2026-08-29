using Content.Shared.Examine;
using Content.Shared.Radiation.Components;
using Robust.Shared.Random;

namespace Content.Omu.Server.Entities.SalvageLoot.RandomisedComps;

public sealed class RandomRadiationSystem : EntitySystem
{
    [Dependency] private readonly IRobustRandom _random = default!;
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<RandomRadiationComponent, ExaminedEvent>(OnExamine);
        SubscribeLocalEvent<RandomRadiationComponent, MapInitEvent>(OnInit);
    }

    private void OnExamine(Entity<RandomRadiationComponent> ent, ref ExaminedEvent args)
    {
        args.PushMarkup(Loc.GetString(ent.Comp.ExamineBaseMessage));
    }

    private void OnInit(EntityUid obj, RandomRadiationComponent component, ref MapInitEvent args)
    {
        EnsureComp<RadiationSourceComponent>(obj, out var radComp);

        radComp.Intensity = _random.NextFloat(1, component.MaxValue);
    }
}

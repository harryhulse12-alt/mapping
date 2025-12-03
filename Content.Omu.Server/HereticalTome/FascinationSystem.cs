using Content.Omu.Server.HereticalTome;
using Content.Omu.Server.HereticalTome.Components;
using Content.Shared.Examine;

namespace Content.Omu.Server.HereticalTome.Fascination;

[ByRefEvent]
public readonly record struct FascinationUpdateEvent();

public sealed class FascinationSystem: EntitySystem
{
[Dependency] private readonly ILocalizationManager _loc = default!;

public override void Initialize()
{
    base.Initialize();
    SubscribeLocalEvent<FascinationComponent, FacinationUpdateEvent>(UpdateDesc);
    SubscribeLocalEvent<FascinationComponent, ExaminedEvent>(OnExamined);
}

private void UpdateDesc(EntityUid uid, FascinationComponent comp, ref FascinationUpdateEvent Eventargs)
{
    switch(Fascination)
        {
            case 0: FascinationDesc = Loc.getstring("Fascination-0"); break;

            case 1: FascinationDesc = Loc.getstring("Fascination-1"); break;

            case 2: FascinationDesc = Loc.getstring("Fascination-2"); break;

            case 3: FascinationDesc = Loc.getstring("Fascination-3"); break;

            case 4: FascinationDesc = Loc.getstring("Fascination-4"); break;

            case 5: FascinationDesc = Loc.getstring("Fascination-5"); break;
        }

}

private void OnExamined(Entity<FascinationComponent> ent, ref ExaminedEvent args)
{
args.PushMarkup(FascinationDesc);
}
}

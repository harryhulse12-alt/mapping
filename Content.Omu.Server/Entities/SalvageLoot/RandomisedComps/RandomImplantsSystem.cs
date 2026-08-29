using Content.Shared.Examine;
using Content.Shared.Inventory.Events;
using Content.Server.Implants;
using Content.Shared.Popups;
using Content.Shared.Hands;

namespace Content.Omu.Server.Entities.SalvageLoot.RandomisedComps;

public sealed class RandomImplantSystem : EntitySystem
{
    [Dependency] private readonly SubdermalImplantSystem _subdermalImplant = default!;
    [Dependency] private readonly SharedPopupSystem _popup = default!;
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<RandomImplantsComponent, ExaminedEvent>(OnExamine);
        SubscribeLocalEvent<RandomImplantsComponent, GotEquippedEvent>(OnWear);
        SubscribeLocalEvent<RandomImplantsComponent, GotEquippedHandEvent>(OnEquip);
    }

    private void OnExamine(Entity<RandomImplantsComponent> ent, ref ExaminedEvent args)
    {
        args.PushMarkup(Loc.GetString(ent.Comp.ExamineBaseMessage));
    }

    private void OnWear(EntityUid obj, RandomImplantsComponent component, ref GotEquippedEvent args)
    {
        if (component.Clothing == false)
            return;

        _subdermalImplant.AddImplants(args.Equipee, component.Implants);

        _popup.PopupEntity(Loc.GetString("random-comp-implant-inject"), args.Equipee, args.Equipee);       //Give them some notification
        RemComp<RandomImplantsComponent>(obj);
    }

    private void OnEquip(EntityUid obj, RandomImplantsComponent component, ref GotEquippedHandEvent args)
    {
        if (component.Clothing == true)
            return;

        _subdermalImplant.AddImplants(args.User, component.Implants);

        _popup.PopupEntity(Loc.GetString("random-comp-implant-inject"), args.User, args.User);       //Give them some notification
        RemComp<RandomImplantsComponent>(obj);
    }
}

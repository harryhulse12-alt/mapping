using Content.Server.Explosion.EntitySystems;
using Content.Server.Heretic.Components;
using Content.Shared.Heretic.Prototypes;
using Content.Shared.Heretic;
using Content.Shared.Interaction;
using Content.Shared.Popups;
using Content.Shared.Tag;
using Robust.Shared.Prototypes;
using System.Text;
using System.Linq;
using Robust.Shared.Serialization.Manager;
using Content.Shared.Examine;
using Content.Shared._Goobstation.Heretic.Components;
using Content.Omu.Server.HereticalTome.Components;
using Content.Server.Heretic.EntitySystems;
using Content.Server.Heretic.EntitySystems;
using Content.Shared.Heretic;
using Content.Shared.Interaction.Events;
using Robust.Server.GameObjects;

namespace Content.Omu.Server.HereticalTome;

public sealed class KnowledgeReadSystem : EntitySystem
{
[Dependency] private readonly HereticSystem _heretic = default!;
[Dependency] private readonly HereticKnowledgeSystem _knowledge = default!;

public override void Initialize()
{
    base.Initialize();
    SubscribeLocalEvent<KnowledgeReadComponent, UseInHandEvent>(OnTriggerBooks);
}

private void OnTriggerBooks(EntityUid book, KnowledgeReadComponent component, ref UseInHandEvent args)
{
    if (TryComp<FascinationComponent>(args.User, out var comp) && comp.FascinationInt >5){comp.FascinationInt+=1;}else{EnsureComp<FascinationComponent>(args.User);}
        var ev = FascinationUpdateEvent();
        RaiseLocalEvent(uid,ref ev, true);

        if (!TryComp<HereticComponent>(args.User, out var heretic))
            return;
        var knowledge =  component.KnowledgeBook;

        _heretic.UpdateKnowledge(heretic.Owner, heretic, knowledge);
        RemComp<KnowledgeReadComponent>(component.Owner);

        args.Handled = true;

}
}

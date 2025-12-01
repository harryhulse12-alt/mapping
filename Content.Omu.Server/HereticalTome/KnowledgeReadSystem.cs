
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
using Robust.Server.GameObjects;

namespace Content.Omu.Server.HereticalTome;

public sealed class KnowledgeReadSystem : EntitySystem
{
    private HereticSystem _heretic = default!;
[Dependency] private readonly HereticKnowledgeSystem _knowledge = default!;

public override void Initialize()
{
    base.Initialize();
    SubscribeLocalEvent<KnowledgeReadComponent, TriggerEvent>(OnTriggerBooks);
}

private void OnTriggerBooks(EntityUid performer, KnowledgeReadComponent component, ref TriggerEvent args)
{

    if (HasComp<HereticComponent>(performer))
    {
        TryComp<HereticComponent>(performer, out var heretic);
        if (heretic == null)
        return;

        _heretic.UpdateKnowledge(performer, heretic, component.KnowledgeBook);
    }
}
}

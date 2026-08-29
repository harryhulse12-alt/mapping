using Robust.Shared.Prototypes;

namespace Content.Omu.Server.Entities.SalvageLoot;

[RegisterComponent, Access(typeof(RandomCompsSystem))]
public sealed partial class RandomCompsComponent : Component
{
    [DataField]
    public int NumberOfComps = 1;

    [DataField]
    public LocId ExamineBaseMessage = "random-comp-examine";

    [DataField]
    public List<RandomComponentEntry> Comps = new();

}

[DataDefinition]
public sealed partial class RandomComponentEntry
{
    [DataField(required: true)]
    public ComponentRegistry Components = new();
}

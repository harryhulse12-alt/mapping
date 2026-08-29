using Robust.Shared.Prototypes;

namespace Content.Omu.Server.Entities.SalvageLoot.RandomisedComps;

[RegisterComponent, Access(typeof(RandomImplantSystem))]
public sealed partial class RandomImplantsComponent : Component
{
    [DataField]
    public bool Clothing = false;

    [DataField(required: true)]
    public List<EntProtoId> Implants = new();

    [DataField]
    public LocId ExamineBaseMessage = "random-comp-implant-examine";        //This exists basically just to provide a warning its gonna stab you

}

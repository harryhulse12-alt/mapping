namespace Content.Omu.Server.Entities.SalvageLoot.RandomisedComps;

[RegisterComponent, Access(typeof(RandomRadiationSystem))]
public sealed partial class RandomRadiationComponent : Component
{
    [DataField]
    public float MaxValue = 5f;

    [DataField]
    public LocId ExamineBaseMessage = "random-comp-rad-examine";        //This exists basically just to provide a warning its radioactive.

}

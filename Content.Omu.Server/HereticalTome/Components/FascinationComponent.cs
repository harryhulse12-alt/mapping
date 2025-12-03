using Robust.Shared.GameObjects;
namespace Content.Omu.Server.HereticalTome.Components;

[RegisterComponent, NetworkedComponent]
public sealed partial class FascinationComponent : Component
{
    /// <summary>
    /// The level of madness
    /// </summary>
    [DataField("Fascination")]
    public float Fascination = 0f;

    [Datafield("FascinationDesc")]
    public string FascinationDesc;
}

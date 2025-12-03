using Robust.Shared.GameObjects;
namespace Content.Omu.Server.HereticalTome.Components;

[RegisterComponent]
public sealed partial class FascinationComponent : Component
{
    /// <summary>
    /// The level of madness
    /// </summary>
    [DataField("Fascination")]
    public float Fascination = 0f;

    [DataField("FascinationDesc")]
    public string FascinationDesc;
}

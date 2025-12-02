namespace Content.Omu.Server.HereticalTome.Components;

[RegisterComponent]
public sealed partial class WellComponent : Component
{
    /// <summary>
    ///
    /// </summary>
    [DataField("alttext")]
    public string alttext = "something seems off about this book";
}

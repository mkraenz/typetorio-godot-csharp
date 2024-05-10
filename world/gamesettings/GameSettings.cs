using Godot;

[GlobalClass]
public partial class GameSettings : Resource
{
    [ExportCategory("General")]
    [Export] public int GameTimeInSec { get; set; } = 60;
    [Export] public int MaxConcurrentWords { get; set; } = 100;

    [Export] public float SpawnIntervalInSec { get; set; } = 1f;

    // TODO word distribution
}
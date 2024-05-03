using System.IO;
using Godot;


public partial class Word : Control
{
	[Export]
	public string Text = "";

	public int PathRotationDegrees = 0;

	private Label label;
	private Path2D path;
	private AnimationPlayer animation;

	public override void _Ready()
	{
		animation = GetNode<AnimationPlayer>("AnimationPlayer");
		label = GetNode<Label>("Path2D/PathFollow2D/Label");
		path = GetNode<Path2D>("Path2D");

		label.Text = Text;
		path.RotationDegrees = PathRotationDegrees;
		label.RotationDegrees = -PathRotationDegrees; // cancels out path rotation so that the actual word is readable as "normal" (left-to-right)
	}

	public void Die()
	{
		animation.Play("die");
	}
}

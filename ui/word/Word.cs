using Godot;

public partial class Word : Label
{
	private AnimationPlayer animation;

	public override void _Ready()
	{
		animation = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public void Die()
	{
		// (Material as ShaderMaterial).SetShaderParameter("size", 1);
		animation.Play("die");
		// QueueFree();
	}
}

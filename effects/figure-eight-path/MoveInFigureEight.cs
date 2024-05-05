using Godot;
using System;

public partial class MoveInFigureEight : Path2D
{
	private NodePath _movedObject;

	// [Export]
	// public NodePath MovedObject
	// {
	// 	get => _movedObject;
	// 	set
	// 	{
			// _movedObject = value;
			// var remoteTransform = GetNode<RemoteTransform2D>("PathFollow2D/RemoteTransform2D");
			// // var nodePath = new NodePath($"../../{_movedObject}");
			// var x = GetNode(_movedObject.ToString());
			// remoteTransform.RemotePath = _movedObject; // _movedObject is relative to MoveInFigureEight, but needs to be relative to the RemoteTransform2D to work properly
			// remoteTransform.ForceUpdateCache();
	// 	}
	// }


	public override void _Ready()
	{
		// if (MovedObject is null) throw new Exception("_movedObject not set via GD Editor");

		// var remoteTransform = GetNode<RemoteTransform2D>("PathFollow2D/RemoteTransform2D");
		// // var nodePath = new NodePath($"../../{_movedObject}");
		// var x = GetNode(MovedObject.ToString());
		// remoteTransform.RemotePath = MovedObject; // _movedObject is relative to MoveInFigureEight, but needs to be relative to the RemoteTransform2D to work properly
	}
}

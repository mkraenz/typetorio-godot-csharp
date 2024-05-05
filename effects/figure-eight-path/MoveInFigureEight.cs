using Godot;
using System;

public partial class MoveInFigureEight : Path2D
{

	[Export]
	public NodePath _movedObject;

	public override void _Ready()
	{
		if (_movedObject is null) throw new Exception("_movedObject not set via GD Editor");

		var remoteTransform = GetNode<RemoteTransform2D>("PathFollow2D/RemoteTransform2D");
		
		// _movedObject is relative to MoveInFigureEight, but needs to be relative to the RemoteTransform2D to work properly
		var movedObjectNode = GetNode(_movedObject);
		var path = remoteTransform.GetPathTo(movedObjectNode); // I tried all sorts of ways of getting the path but this is the only one that works
		remoteTransform.RemotePath = path; 
	}
}

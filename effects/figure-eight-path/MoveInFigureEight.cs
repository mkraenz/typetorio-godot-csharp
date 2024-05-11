using System;
using Godot;

namespace Effects
{
    public partial class MoveInFigureEight : Path2D
    {
        [Export]
        public NodePath MovedObject { get; set; }

        public override void _Ready()
        {
            if (MovedObject is null)
                throw new ArgumentNullException("MovedObject not set via GD Editor");

            var remoteTransform = GetNode<RemoteTransform2D>("PathFollow2D/RemoteTransform2D");

            // MovedObject is relative to MoveInFigureEight, but needs to be relative to the RemoteTransform2D to work properly
            var movedObjectNode = GetNode(MovedObject);
            var path = remoteTransform.GetPathTo(movedObjectNode); // I tried all sorts of ways of getting the path but this is the only one that works
            remoteTransform.RemotePath = path;
        }
    }
}

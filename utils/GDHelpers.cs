using System;
using Godot;
using Main;

namespace Globals
{
    public class GDHelpers
    {
        public static void QueueFreeAllChildren(Node node)
        {
            foreach (Node child in node.GetChildren())
            {
                child.QueueFree();
            }
        }
    }
}

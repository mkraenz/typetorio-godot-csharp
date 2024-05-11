using Godot;

namespace Globals
{
    public class GDAccessors
    {
        public static Eventbus GetEventbus(Node node)
        {
            return node.GetNode<Eventbus>("/root/Eventbus");
        }
    }
}

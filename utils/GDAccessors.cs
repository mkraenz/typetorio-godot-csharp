using Globals;
using Godot;

public class GDAccessors
{
    public static Eventbus GetEventbus(Node node)
    {
        return node.GetNode<Eventbus>("/root/Eventbus");
    }
}

using Godot;

namespace Globals
{
    public class GDAccessors
    {
        public static Eventbus GetEventbus(Node node)
        {
            return node.GetNode<Eventbus>("/root/Eventbus");
        }

        public static GameProgress GetGameProgress(Node node)
        {
            return node.GetNode<GameProgress>("/root/GameProgress");
        }
    }
}

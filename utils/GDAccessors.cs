using System;
using Godot;
using Main;

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

        internal static SceneTransition GetSceneTransition(Node node)
        {
            return node.GetNode<SceneTransition>("/root/SceneTransition");
        }
    }
}

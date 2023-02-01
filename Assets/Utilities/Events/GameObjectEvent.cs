using UnityEngine;

namespace Logic.Events
{
    [CreateAssetMenu(fileName = "GameObjectEvent.asset", menuName = "Events/GameObjectEvent")]
    public class GameObjectEvent : EventBase<GameObject>
    {
    }
}
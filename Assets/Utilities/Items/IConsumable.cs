using UnityEngine;

namespace Logic.Items
{
    public interface IConsumable
    {
        void Consume(GameObject consumer);
    }
}
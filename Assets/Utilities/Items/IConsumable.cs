using UnityEngine;

namespace Utilities.Items
{
    public interface IConsumable
    {
        void Consume(GameObject consumer);
    }
}
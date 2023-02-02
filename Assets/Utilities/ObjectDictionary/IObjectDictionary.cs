using UnityEngine;

namespace Utilities.ObjectMap
{
    public interface IObjectDictionary
    {
        T TryGetValue<T>(Key key) where T:Object;
    }
}
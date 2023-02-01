using UnityEngine;

namespace Logic.ObjectMap
{
    public interface IObjectDictionary
    {
        T TryGetValue<T>(Key key) where T:Object;
    }
}
using UnityEngine;

namespace Logic.Interactions
{
    public static class ObjectExtensions
    {
        public static T GetComponent<T>(this Object @object) where T : Component
        {
            if (@object is GameObject gameObject)
                return gameObject.GetComponent<T>();
            return null;
        }
        
        public static T[] GetComponents<T>(this Object @object) where T : Component
        {
            if (@object is GameObject gameObject)
                return gameObject.GetComponents<T>();
            return null;
        }
    }
}
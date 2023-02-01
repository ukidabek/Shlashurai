using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic.ObjectMap
{
    public class ObjectDictionary : MonoBehaviour, IObjectDictionary
    {
        [Serializable]
        public struct KeyValuePair
        {
            [SerializeField] private Key _key;
            public Key Key => _key;
        
            [SerializeField] private Object _value;
            public Object Value => _value;
        }

        [SerializeField] private KeyValuePair[] _keyValuePair = null;
        
        protected Dictionary<Key, Object> _dictionary = null;

        private void Awake()
        {
            if (!_keyValuePair.Any()) return;
            
            _dictionary = new Dictionary<Key, Object>();
            foreach (var keyValuePair in _keyValuePair) 
                _dictionary.Add(keyValuePair.Key, keyValuePair.Value);
        }

        public T TryGetValue<T>(Key key) where T:Object
        {
            if (_dictionary != null && _dictionary.TryGetValue(key, out var value))
                return value as T;
            
            return null;
        }
    }
}

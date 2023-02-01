using System;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Weapons/AmmunitionStorage", fileName = "AmmunitionStorage")]
    public class AmmunitionStorage : ScriptableObject
    {
        [SerializeField] private bool _infinite = false;
        public bool Infinite => _infinite;

        public event Action<int> OnCountChange; 
        [SerializeField] private WeaponDescriptor _ammunitionType = null;
        public WeaponDescriptor AmmunitionType => _ammunitionType;

        [SerializeField] private int _count = 150;
        public int Count
        {
            get { return _count; }
            private set
            {
                _count = value;
                OnCountChange?.Invoke(_count);
            }
        }

        [SerializeField] private int _maxCount = 150;

        public void Retrieve(IClip clip)
        {
            if (_infinite)
            {
                clip.Reload();
                return;
            }
                
            if (Count > clip.Count)
            {
                Count -= clip.Count;
                clip.Reload();
            }
            else
            {
                clip.Reload(Count);
                Count = 0;
            }
        }
    }
}
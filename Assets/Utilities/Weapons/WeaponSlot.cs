using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Weapons
{
    
    public class WeaponSlot : MonoBehaviour
    {
        [SerializeField] private WeaponDescriptor[] _requirements;
        [SerializeField] private Weapon _storedWeapon = null;
        public Weapon StoredWeapon => _storedWeapon;

        public bool Full => _storedWeapon != null;

        public UnityEvent OnWeaponEquipped = new UnityEvent();

        public bool ValidateRequirement(IEnumerable<WeaponDescriptor> weponDecriptors)
        {
            if (_requirements.Length == 0) return false;
            var result= _requirements.Intersect(weponDecriptors);
            return _requirements.Length == result.Count();
        }

        public Weapon TakeWeapon(Transform toolTransform)
        {
            ReParentWeapon(toolTransform);
            return _storedWeapon;
        }

        public Weapon PutOffWeapon()
        {
            ReParentWeapon(transform);
            return _storedWeapon;
        }

        public void Equip(Weapon weapon)
        {
            _storedWeapon = weapon;
            ReParentWeapon(transform);
            OnWeaponEquipped.Invoke();
        }

        private void ReParentWeapon(Transform parent)
        {
            if(_storedWeapon == null) return;
            var weaponTransform = _storedWeapon.transform;
            weaponTransform.SetParent(parent);
            weaponTransform.localPosition = Vector3.zero;
            weaponTransform.localRotation = Quaternion.identity;
        }
    }
}
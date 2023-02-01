using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Index = Utilities.General.Index;

namespace Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private Index _activeSlotIndex = null;
        [SerializeField] private WeaponSlot[] _slots = null;
        public WeaponSlot[] Slots => _slots;
        
        [SerializeField] private HandSlotBinding[] _bindings = null;


        [Space]
        [SerializeField] private Transform _weaponParentSpot = null;

        [SerializeField] private GameObject _user = null;

        [SerializeField] private Weapon _currentWeapon = null;

        public Weapon CurrentWeapon
        {
            get => _currentWeapon;
            private set
            {
                if (_currentWeapon == value) return;
                _currentWeapon = value;
                OnWeaponSwitch.Invoke(value);
            }
        }

        [SerializeField] private AmmunitionStorage[] _ammunitionStorages = null;

        public AmmunitionStorage[] AmmunitionStorages => _ammunitionStorages;

        [Header("Events")]
        public UnityEvent<Weapon> OnWeaponSwitch = new UnityEvent<Weapon>();
        public UnityEvent<Weapon> OnWeaponEquippedToSlot = new UnityEvent<Weapon>();
        
        private void Awake()
        {
            _activeSlotIndex = new Index(_slots);
        }

        private WeaponSlot GetSlotForWeapon(Weapon weapon)
        {
            return _slots.FirstOrDefault(slot => slot.ValidateRequirement(weapon.Descriptors));
        }

        public void Equip(int index)
        {
            if(index == _activeSlotIndex) return;
            Unequip();
            _activeSlotIndex.Current = index;
            Equip();
        }
        
        public void Equip()
        {
            var slot = _slots[_activeSlotIndex];
            if(slot == null || slot.Full == false) return;
            
            var weapon = slot.TakeWeapon(_weaponParentSpot);

            weapon.OnEquip(_user);
            var handSlots = weapon.HandSpots;
            foreach (var handSlot in handSlots)
            {
                var binding = _bindings.FirstOrDefault(slotBinding => slotBinding.HumanBone == handSlot.HumanBone);
                binding.SetTransform(handSlot.SlotTransform);
            }

            CurrentWeapon = weapon;
        }

        public void EquipToSlot(Weapon weapon)
        {
            var slot = GetSlotForWeapon(weapon);
            if(slot == null) return;
            slot.Equip(weapon);
            OnWeaponEquippedToSlot.Invoke(weapon);
        }

        public void Unequip()
        {
            var slot = _slots[_activeSlotIndex];
            if(slot == null || slot.Full == false) return;
            
            foreach (var handSlotBinding in _bindings) 
                handSlotBinding.SetTransform(null);
            
            var weapon = slot.PutOffWeapon();
            weapon.OnUnequip(_user);
            
            CurrentWeapon = null;
        }

        public bool UseWeapon() => CurrentWeapon != null && CurrentWeapon.Use();
    }
}
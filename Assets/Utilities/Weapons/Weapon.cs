using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Index = Utilities.General.Index;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private string _displayName = null;
        public string DisplayName => _displayName;

        [SerializeField] private HandSpot[] _handSpots = null;
        public HandSpot[] HandSpots => _handSpots;

        [SerializeField] private WeaponDescriptor[] _descriptors = null;
        public WeaponDescriptor[] Descriptors => _descriptors;
        
        [SerializeField] private WeaponLogic[] _weaponLogics = null;

        private IEnumerable<WeaponAtomLogicBase> _weaponAtomLogicList = null;

        private Index _index = null;
        
        private void Awake()
        {
            _index = new Index(_weaponLogics);
            _weaponAtomLogicList = _weaponLogics.SelectMany(logic => logic.WeaponAtomLogic);
        }
        
        public void OnEquip(GameObject user)
        {
            foreach (var weaponLogic in _weaponLogics) 
                weaponLogic.SetUser(user);
        }
        
        public bool Use(GameObject target = null) => _weaponLogics[_index].Perform();

        public void OnUnequip(GameObject user)
        {
        }

        public T GetWeaponAtomicLogic<T>() => _weaponAtomLogicList.OfType<T>().First();
    }
}
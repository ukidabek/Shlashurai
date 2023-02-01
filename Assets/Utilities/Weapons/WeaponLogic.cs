using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Weapons
{
    public class WeaponLogic : MonoBehaviour
    {
        [SerializeField] private WeaponAtomLogicBase[] _weaponAtomLogic = null;
        public WeaponAtomLogicBase[] WeaponAtomLogic => _weaponAtomLogic;

        private IEnumerable<IWeaponConstraint> _constraint = null;
        private IEnumerable<IWeaponBehaviour> _behaviours = null;

        private void Awake()
        {
            if (!_weaponAtomLogic.Any()) return;
            
            _constraint = _weaponAtomLogic.OfType<IWeaponConstraint>();
            _behaviours = _weaponAtomLogic.OfType<IWeaponBehaviour>();
        }

        public void SetUser(GameObject _user)
        {
            foreach (var weaponAtomLogicBase in _weaponAtomLogic) 
                weaponAtomLogicBase.SetUser(_user);
        }
        
        public bool Perform()
        {
            if (_constraint.All(constraint => constraint.Validate()) == false) 
                return false;
            
            foreach (var weaponBehaviour in _behaviours) 
                weaponBehaviour.Perform();

            return true;
        }
    }
}
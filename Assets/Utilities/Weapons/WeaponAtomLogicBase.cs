using UnityEngine;

namespace Weapons
{
    public abstract class WeaponAtomLogicBase : MonoBehaviour
    {
        public virtual void SetUser(GameObject _user) {}
        private void Reset() => name = this.GetType().Name;
    }
}
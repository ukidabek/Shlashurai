using UnityEngine;
using Utilities.UI;

namespace Weapons
{
    [CreateAssetMenu(fileName = "WeaponManagerModel", menuName = "UI/Models/WeaponManagerModel")]
    public class WeaponManagerModel : ManagerModelBase<WeaponManager>
    {
        [SerializeField] private int _selectedWeaponIndex = 0;
        public int SelectedWeaponIndex
        {
            get => _selectedWeaponIndex;
            set => _selectedWeaponIndex = value;
        }
    }
}
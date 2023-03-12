using Shlashurai.Player.Logic;
using UnityEngine;

namespace Shlashurai.Items
{
	public class WeaponEquipmentEventHandler : EquipmentEventHandler
	{
		[SerializeField] private PlayerAttackStateLogic[] playerAttackStateLogics = null;
		private WeaponItemComponent m_weaponItemComponent;

		protected override void OnItemEquipped(IItem item)
		{
			if (item == null) return;

			m_weaponItemComponent = item.GetComponent<WeaponItemComponent>();

			if (m_weaponItemComponent == null) return;

			SetWeaponComponent(m_weaponItemComponent);
		}

		protected override void OnItemUnequipped(IItem item)
		{
			if (item == null) return;

			var weaponItemComponent = item.GetComponent<WeaponItemComponent>();

			if (weaponItemComponent == null || 
				weaponItemComponent != m_weaponItemComponent) 
				return;

			SetWeaponComponent(m_weaponItemComponent = null);
		}

		private void SetWeaponComponent(WeaponItemComponent weaponItemComponent)
		{
			foreach (var playerAttackState in playerAttackStateLogics)
				playerAttackState.WeaponItemComponent = weaponItemComponent;
		}
	}
}
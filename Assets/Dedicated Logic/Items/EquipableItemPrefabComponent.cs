using System.Collections.Generic;
using UnityEngine;

namespace Shlashurai.Items
{
	public class EquipableItemPrefabComponent : ItemPrefabComponent, IEquipable
	{
		public GameObject GameObject => Instance.gameObject;
		public IEnumerable<IEquipmentDescriptor> Descriptors { get; }
		public IEnumerable<object> Modifiers { get; }
		private Collider[] Colliders { get; }
		private Rigidbody Rigidbody { get; }
		public Vector3 LocalPosition { get; }
		public Vector3 LocalRotation { get; }

		public EquipableItemPrefabComponent(
			ItemBinder prefab,
			IEnumerable<IEquipmentDescriptor> descriptors,
			IEnumerable<object> modifiers,
			Vector3 localPosition,
			Vector3 localRotation) : base(prefab)
		{
			Descriptors = descriptors;
			Modifiers = modifiers;
			Colliders = Instance.GetComponents<Collider>();
			Rigidbody = Instance.GetComponent<Rigidbody>();
			LocalPosition = localPosition;
			LocalRotation = localRotation;
		}

		public void Equip(Transform parent)
		{
			EnablePhysic(false);

			Instance.gameObject.SetActive(true);
			var transform = Instance.transform;
			transform.SetParent(parent, false);
			transform.localPosition = LocalPosition;
			transform.localRotation = Quaternion.Euler(LocalRotation);
		}
		public void Unequip()
		{
			EnablePhysic(true);

			Instance.gameObject.SetActive(false);
			Instance.transform.SetParent(null, false);
		}

		private void EnablePhysic(bool status)
		{
			foreach (var colliders in Colliders)
				colliders.enabled = status;
			Rigidbody.isKinematic = !status;
		}

	}
}
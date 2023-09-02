using System.Collections.Generic;
using UnityEngine;

namespace Shlashurai.Items
{
	public interface IEquipable
    {
        public IEnumerable<IEquipmentDescriptor> Descriptors { get; }
		public IEnumerable<object> Modifiers { get; }

		public void Equip(Transform parent);
		public void Unequip();
	}
}
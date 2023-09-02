using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Items
{
	public abstract class ItemTemplateBase : ScriptableObject
	{
		[SerializeField] protected string m_displayName = string.Empty;
		[SerializeField, HideInInspector] protected ItemComponentTemplate[] m_itemComponents = null;

		public abstract IItem Create();
		protected IEnumerable<IItemComponent> GetItemComponentInstances()
			=> m_itemComponents
				.Select(componentTemplate => componentTemplate.Create())
				.ToArray();
	}
}
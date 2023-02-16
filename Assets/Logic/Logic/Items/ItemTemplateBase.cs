using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shlashurai.Items
{
	public abstract class ItemTemplateBase : ScriptableObject
	{
		[SerializeField] protected string m_displayName = string.Empty;
		[SerializeField] protected ItemComponentTemplate[] m_itemComponents = null;

		protected IEnumerable<IItemComponent> GetItemComponentInstances() 
			=> m_itemComponents
				.Select(compoenetTemplate => compoenetTemplate.Create())
				.ToArray();
		public abstract IItem Create();
	}
}
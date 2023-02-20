using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Shlashurai.Items
{
	[CustomEditor(typeof(ItemTemplate), true)]
	public class ItemTemplateEditor : Editor
	{
		private IEnumerable<Type> m_itemComponentsTypes = null;
		private FieldInfo m_componentsListFieldInfo = null;
		private GenericMenu m_componentsMenu = new GenericMenu();

		private void OnEnable()
		{
			var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			m_componentsListFieldInfo = target.GetType().GetField("m_itemComponents", bindingFlags);

			var itemComponentType = typeof(IItemComponent);
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			m_itemComponentsTypes = assemblies
				.SelectMany(assembly => assembly.GetTypes())
				.Where(type => type.IsAbstract == false && type.GetInterfaces().Contains(itemComponentType));

			foreach (var item in m_itemComponentsTypes)
			{
				m_componentsMenu.AddItem(new GUIContent(item.Name), true, AddComponent, item);
			}
		}

		private void AddComponent(object o)
		{
			var list = m_componentsListFieldInfo.GetValue(target) as IItemComponent[];
			var newComponent = Activator.CreateInstance(o as Type) as IItemComponent;
			list = list.Concat(new[] { newComponent })
				.Where(component => component != null)
				.ToArray();
			m_componentsListFieldInfo.SetValue(target, list);
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if(GUILayout.Button("Add component"))
				m_componentsMenu.ShowAsContext();
		}
	}
}
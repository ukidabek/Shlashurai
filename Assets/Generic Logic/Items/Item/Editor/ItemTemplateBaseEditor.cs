using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Items
{
	[CustomEditor(typeof(ItemTemplateBase), true)]
	public class ItemTemplateBaseEditor : Editor, ISearchWindowProvider
	{
		private const BindingFlags Binding_Flags = BindingFlags.NonPublic | BindingFlags.Instance;
		private FieldInfo m_itemComponentsFieldInfo = null;

		private List<ItemComponentTemplate> m_itemComponents = null;
		private IEnumerable<Editor> m_editors = null;
		private List<Editor> m_itemComponentsEditors = null;
		private List<SearchTreeEntry> m_searchTreeEntries = new List<SearchTreeEntry>();
		private Type m_itemTemplateBaseType = typeof(ItemTemplateBase);

		private string m_assetPath = string.Empty;

		private void OnEnable()
		{
			m_assetPath = AssetDatabase.GetAssetPath(target);
			m_itemComponentsFieldInfo = m_itemTemplateBaseType.GetField("m_itemComponents", Binding_Flags);

			var itemComponents = m_itemComponentsFieldInfo.GetValue(target) as ItemComponentTemplate[];
			m_itemComponents = new List<ItemComponentTemplate>(itemComponents ?? Array.Empty<ItemComponentTemplate>());
			m_editors = m_itemComponents.Select(component => CreateEditor(component));
			m_itemComponentsEditors = m_editors.ToList();

			var m_itemComponentTypes = TypeCache.GetTypesDerivedFrom<ItemComponentTemplate>();
			var icon = EditorGUIUtility.IconContent("ScriptableObject Icon");

			m_searchTreeEntries.Add(new SearchTreeGroupEntry(new GUIContent("Item components"), 0));
			foreach (var item in m_itemComponentTypes)
			{
				m_searchTreeEntries.Add(new SearchTreeEntry(new GUIContent(item.Name, icon.image))
				{
					userData = item,
					level = 1,
				});
			}
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			EditorGUILayout.Space();
			EditorGUI.indentLevel = 1;
			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			{
				for (int i = 0; i < m_itemComponentsEditors.Count; i++)
				{
					var editor = m_itemComponentsEditors[i];
					editor.OnInspectorGUI();
					if(GUILayout.Button("Remove"))
					{
						var target = editor.target;
						AssetDatabase.RemoveObjectFromAsset(target);
						EditorUtility.SetDirty(this.target);
						AssetDatabase.SaveAssetIfDirty(this.target);
						m_itemComponents.Remove(target as ItemComponentTemplate);
						OverrideItemComponents();
					}
					EditorGUILayout.Space(10);
				}
			}
			EditorGUI.indentLevel = 0;
			EditorGUILayout.EndVertical();
			if(GUILayout.Button("AddComponent"))
			{
				var mousePosition = Event.current.mousePosition;
				mousePosition = EditorGUIUtility.GUIToScreenPoint(mousePosition);
				var context = new SearchWindowContext(mousePosition);
				SearchWindow.Open(context, this);
			}
		}

		public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) => m_searchTreeEntries;

		public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
		{
			try
			{
				var type = SearchTreeEntry.userData as Type;

				var itemComponentTemplateInstance = CreateInstance(type) as ItemComponentTemplate;
				itemComponentTemplateInstance.name = type.Name;

				AssetDatabase.AddObjectToAsset(itemComponentTemplateInstance, m_assetPath);
				m_itemComponents.Add(itemComponentTemplateInstance);
				OverrideItemComponents();
				serializedObject.ApplyModifiedProperties();
				EditorUtility.SetDirty(target);
				AssetDatabase.SaveAssetIfDirty(target);

				return true;
			}
			catch (Exception ex)
			{ 
				return false;
			}
		}

		private void OverrideItemComponents()
		{
			m_itemComponentsFieldInfo.SetValue(target, m_itemComponents.ToArray());
			m_itemComponentsEditors = m_editors.ToList();
		}
	}
}
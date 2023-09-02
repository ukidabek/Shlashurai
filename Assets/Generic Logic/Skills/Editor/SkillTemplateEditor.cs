using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skills
{
	[CustomEditor(typeof(SkillTemplateBase), true)]
	public class SkillTemplateEditor : Editor, ISearchWindowProvider
	{
		private enum Content
		{
			None,
			Cost,
			Effect
		}

		private struct UserData
		{
			public Type Type;
			public Content Content;
		}

		private Content m_content = Content.None;
		private const BindingFlags Binding_Flags = BindingFlags.NonPublic | BindingFlags.Instance;

		private FieldInfo m_costTemplateFieldInfo = null;
		private FieldInfo m_effectTemplateFieldInfo = null;

		private string m_assetPath = string.Empty;

		private Type m_skillCostTemplateBaseType = typeof(SkillCostTemplateBase);
		private Type m_skillEffectTemplateBaseType = typeof(SkillEffectTemplateBase);

		private List<SearchTreeEntry> m_costTypes = null;
		private List<SearchTreeEntry> m_effectTypes = null;

		private Editor m_skillCostEditor = null;
		private List<Editor> m_effectCostEditor = null;

		private void OnEnable()
		{
			m_assetPath = AssetDatabase.GetAssetPath(target);

			var targetType = target.GetType();
			m_costTemplateFieldInfo = targetType.GetField("m_skillConstTemplate", Binding_Flags);
			m_effectTemplateFieldInfo = targetType.GetField("m_skillEffects", Binding_Flags);

			var skillCostTemplateTypes = TypeCache.GetTypesDerivedFrom(m_skillCostTemplateBaseType);
			m_costTypes = GenerateEntriesForType(skillCostTemplateTypes, "Skill cost", Content.Cost);

			var skillEffectTemplateTypes = TypeCache.GetTypesDerivedFrom(m_skillEffectTemplateBaseType);
			m_effectTypes = GenerateEntriesForType(skillEffectTemplateTypes, "Skill effect", Content.Effect);

			var cost = m_costTemplateFieldInfo.GetValue(target) as UnityEngine.Object;
			if (cost != null)
				m_skillCostEditor = CreateEditor(cost);

			var skillEffects = m_effectTemplateFieldInfo.GetValue(target) as SkillEffectTemplateBase[];
			skillEffects ??= Array.Empty<SkillEffectTemplateBase>();
			m_effectCostEditor = new List<SkillEffectTemplateBase>(skillEffects).Select(effect => CreateEditor(effect)).ToList();
		}

		private SearchWindowContext GetContext()
		{
			var mousePosition = Event.current.mousePosition;
			mousePosition = EditorGUIUtility.GUIToScreenPoint(mousePosition);
			return new SearchWindowContext(mousePosition);
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			EditorGUI.indentLevel = 1;
			if (m_skillCostEditor != null)
			{
				EditorGUILayout.BeginVertical(EditorStyles.helpBox);
				{
					m_skillCostEditor.OnInspectorGUI();
				}
				EditorGUILayout.EndVertical();
			}
			EditorGUI.indentLevel = 0;

			if (GUILayout.Button("Select Skill Cost"))
			{
				m_content = Content.Cost;
				SearchWindow.Open(GetContext(), this);
			}

			EditorGUI.indentLevel = 1;
			if (m_effectCostEditor.Any())
			{
				EditorGUILayout.BeginVertical(EditorStyles.helpBox);
				{
					for (int i = 0; i < m_effectCostEditor.Count; i++)
					{
						var editor = m_effectCostEditor[i];
						editor.OnInspectorGUI();
						if (GUILayout.Button("Remove"))
						{
							AssetDatabase.RemoveObjectFromAsset(editor.target);
							m_effectCostEditor.RemoveAt(i--);
							var skillEffects = m_effectCostEditor
								.Select(editor => editor.target)
								.OfType<SkillEffectTemplateBase>()
								.ToList();
							m_effectTemplateFieldInfo.SetValue(target, skillEffects.ToArray());
							serializedObject.ApplyModifiedProperties();
							EditorUtility.SetDirty(target);
							AssetDatabase.SaveAssetIfDirty(target);
						}
					}
				}
				EditorGUILayout.EndVertical();
			}
			EditorGUI.indentLevel = 0;

			if (GUILayout.Button("Add Skill Effect"))
			{
				m_content = Content.Effect;
				SearchWindow.Open(GetContext(), this);
			}
		}

		private List<SearchTreeEntry> GenerateEntriesForType(TypeCache.TypeCollection types, string title, Content content)
		{
			var icon = EditorGUIUtility.IconContent("ScriptableObject Icon");
			var list = new List<SearchTreeEntry>();
			list.Add(new SearchTreeGroupEntry(new GUIContent(title), 0));

			foreach (var type in types)
			{
				list.Add(new SearchTreeEntry(new GUIContent(type.Name, icon.image))
				{
					userData = new UserData
					{
						Type = type,
						Content = content
					},
					level = 1,
				});
			}

			return list;
		}

		public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
		{
			switch (m_content)
			{
				case Content.Cost:
					return m_costTypes;
				case Content.Effect:
					return m_effectTypes;
				default:
					return new List<SearchTreeEntry>();
			}
		}

		public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
		{
			var userData = (UserData)SearchTreeEntry.userData;
			var instance = CreateInstance(userData.Type);
			instance.name = userData.Type.Name;
			AssetDatabase.AddObjectToAsset(instance, m_assetPath);

			switch (userData.Content)
			{
				case Content.Cost:
					var cost = m_costTemplateFieldInfo.GetValue(target) as UnityEngine.Object;
					if (cost != null)
						AssetDatabase.RemoveObjectFromAsset(cost);
					m_costTemplateFieldInfo.SetValue(target, instance);
					m_skillCostEditor = CreateEditor(instance);
					break;
				case Content.Effect:
					var skillEffect = instance as SkillEffectTemplateBase;
					var x = m_effectCostEditor
						.Select(editor => editor.target)
						.OfType<SkillEffectTemplateBase>()
						.Concat(new[] { skillEffect });
					m_effectTemplateFieldInfo.SetValue(target, x.ToArray());
					m_effectCostEditor = x.Select(effectTemplate => CreateEditor(effectTemplate)).ToList();
					break;
			}

			serializedObject.ApplyModifiedProperties();
			EditorUtility.SetDirty(target);
			AssetDatabase.SaveAssetIfDirty(target);

			return true;
		}
	}
}
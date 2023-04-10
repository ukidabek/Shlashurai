using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Shlashurai.Statistics
{
	[CustomEditor(typeof(StatisticManager))]
	public class StatisticManagerEditor : Editor
	{
		private StatisticManager m_manager = null;
		private List<StatisticEditor> m_statisticEditors = null;
		private StatisticEditorFactory m_statisticEditorFactory = new StatisticEditorFactory();
		private bool m_showGUI;

		private void OnEnable()
		{
			m_manager = target as StatisticManager;
			CreateStatisticEditors();
		}

		private void CreateStatisticEditors()
		{
			m_statisticEditors = m_manager.Statistics
				.Select(m_statisticEditorFactory.Build)
				.ToList();
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			m_showGUI = EditorGUILayout.Foldout(m_showGUI, "Statistic details");
			if (m_showGUI)
			{
				EditorGUI.indentLevel = 1;
				foreach (var editor in m_statisticEditors)
				{
					editor.OnInspectorGUI();
				}
			}
			EditorGUI.indentLevel = 0;

			if (GUILayout.Button("Collect statistics"))
			{
				CollectStatistics();
			}

			if (m_statisticEditors.Count != m_manager.Statistics.Count())
				CreateStatisticEditors();

			if (m_statisticEditors.Count == 0) return;
		}

		private void CollectStatistics()
		{
			m_manager.CollectStatistics();
			CreateStatisticEditors();
			EditorUtility.SetDirty(target);
		}
	}
}
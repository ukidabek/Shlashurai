using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Shlashurai.Statistics
{
	[CustomEditor(typeof(StatisticManager))]
	public class StatisticManagerEditor : Editor
	{
		private StatisticManager m_manager = null;

		private List<Editor> m_statisticEditors = null;

		private StringBuilder m_statNameStringBuilder = new StringBuilder();

		private void OnEnable()
		{
			m_manager = target as StatisticManager;
			CreateStatisticEditors();
		}

		private void CreateStatisticEditors()
		{
			m_statisticEditors = m_manager.Statistics
				.Select(Editor.CreateEditor)
				.ToList();
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (GUILayout.Button("Collect statistics"))
			{
				CollectStatistics();
			}

			if (m_statisticEditors.Count != m_manager.Statistics.Count())
				CreateStatisticEditors();

			if (m_statisticEditors.Count == 0) return;

			foreach (var editor in m_statisticEditors)
			{
				m_statNameStringBuilder.Clear();
				var stat = editor.target as Statistic;
				if (stat.ID.Count() == 0) continue;
				{
					var lastID = stat.ID.Last();
					if (lastID == null) continue;
					foreach (var id in stat.ID)
					{
						m_statNameStringBuilder.Append(id.name);
						if (id == lastID) continue;
						m_statNameStringBuilder.Append(", ");
					}
				}
				EditorGUILayout.LabelField(m_statNameStringBuilder.ToString());
				editor.OnInspectorGUI();
				EditorGUILayout.Space();
			}
		}

		private void CollectStatistics()
		{
			m_manager.CollectStatistics();
			CreateStatisticEditors();

			EditorUtility.SetDirty(target);
		}
	}
}
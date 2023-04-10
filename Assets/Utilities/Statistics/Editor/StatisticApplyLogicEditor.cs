using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Shlashurai.Statistics
{
	[CustomEditor(typeof(StatisticApplyLogic), true)]
	public class StatisticApplyLogicEditor : Editor
	{
		public class StatisticReferenceSetter
		{
			private bool m_showStatistics = false;

			private Object m_target = null;
			private FieldInfo m_fieldInfo;
			private IEnumerable<Statistic> m_statistics = null;

			public StatisticReferenceSetter(Object target, FieldInfo fieldInfo, IEnumerable<Statistic> statistics)
			{
				m_target = target;
				m_fieldInfo = fieldInfo;
				m_statistics = statistics;
			}

			public void OnInspectorGUI()
			{
				if (m_showStatistics)
				{
					foreach (var statistic in m_statistics)
					{
						EditorGUILayout.BeginHorizontal();
						var id = statistic.GetID();
						GUILayout.Label(id);
						if (GUILayout.Button("Apply", GUILayout.Width(45)))
						{
							m_fieldInfo.SetValue(m_target, statistic);
							EditorUtility.SetDirty(m_target);
							m_showStatistics = false;
						}
						EditorGUILayout.EndHorizontal();
					}
					if (GUILayout.Button("Cancel"))
					{
						m_showStatistics = false;
					}
				}
				else if (GUILayout.Button($"Select {m_fieldInfo.Name} statistic"))
				{
					m_showStatistics = true;
				}
			}

		}

		private StatisticApplyLogic m_statisticApplyLogic = null;
		private StatisticReferenceSetter[] m_statisticToApplyFieldInfo = null;
		private Statistic[] m_statistics = null;

		protected virtual void OnEnable()
		{
			if (target == null) return;
			m_statisticApplyLogic = target as StatisticApplyLogic;

			var statisticApplyLogicType = typeof(StatisticApplyLogic);
			var statisticType = typeof(Statistic);

			var rootGameObject = m_statisticApplyLogic.transform.root.gameObject;
			m_statistics = rootGameObject.GetComponentsInChildren<Statistic>();

			m_statisticToApplyFieldInfo = target
				.GetType()
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
				.Where(field => field.FieldType == statisticType)
				.Select(fieldInfo => new StatisticReferenceSetter(target, fieldInfo, m_statistics))
				.ToArray();
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			foreach (var statistic in m_statisticToApplyFieldInfo) 
				statistic.OnInspectorGUI();
		}
	}
}
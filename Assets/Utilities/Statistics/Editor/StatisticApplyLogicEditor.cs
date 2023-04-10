using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Shlashurai.Statistics
{
	[CustomEditor(typeof(StatisticApplyLogic), true)]
	public class StatisticApplyLogicEditor : Editor
	{
		private StatisticApplyLogic m_statisticApplyLogic = null;
		private FieldInfo m_statisticToApplyFieldInfo = null;
		private Statistic[] m_statistics = null;
		private bool m_showStatistics = false;
		private StringBuilder stringBuilder = new StringBuilder();

		protected virtual void OnEnable()
		{
			if (target == null) return;
			m_statisticApplyLogic = target as StatisticApplyLogic;
			var statisticApplyLogicType = typeof(StatisticApplyLogic);
			m_statisticToApplyFieldInfo = statisticApplyLogicType.GetField("m_statisticToApply",
				BindingFlags.NonPublic | BindingFlags.Instance);
			
			var rootGameObject = m_statisticApplyLogic.transform.root.gameObject;
			m_statistics = rootGameObject.GetComponentsInChildren<Statistic>();
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (m_showStatistics)
			{
				foreach (var statistic in m_statistics) 
				{
					EditorGUILayout.BeginHorizontal();
					var id = statistic.GetID();
					GUILayout.Label(id);
					if(GUILayout.Button("Apply", GUILayout.Width(45)))
					{
						m_statisticToApplyFieldInfo.SetValue(target, statistic);
						EditorUtility.SetDirty(target);
						m_showStatistics = false;
					}
					EditorGUILayout.EndHorizontal();
				}
				if (GUILayout.Button("Cancel"))
				{
					m_showStatistics = false;
				}
			}
			else if (GUILayout.Button("Select statistic"))
			{
				m_showStatistics = true;
			}
		}
	}
}
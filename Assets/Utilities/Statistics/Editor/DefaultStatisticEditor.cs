using UnityEditor;

namespace Shlashurai.Statistics
{
	internal class DefaultStatisticEditor : StatisticEditor
	{
		public DefaultStatisticEditor(Statistic statistic) : base(statistic)
		{
		}

		protected override void DrawGUI()
		{
			m_statistic.BaseValue = EditorGUILayout.FloatField(nameof(Statistic.BaseValue), m_statistic.BaseValue);
			EditorGUILayout.FloatField(nameof(Statistic.Value), m_statistic.Value);
		}
	}
}
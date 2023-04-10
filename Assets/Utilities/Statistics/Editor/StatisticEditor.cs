using UnityEditor;

namespace Shlashurai.Statistics
{
	internal abstract class StatisticEditor
	{
		protected Statistic m_statistic;
		private bool m_showGUI = false;

		protected StatisticEditor(Statistic statistic)
		{
			m_statistic = statistic;
		}

		public void OnInspectorGUI()
		{
			EditorGUI.BeginChangeCheck();
			EditorGUILayout.LabelField(m_statistic.GetID());
			m_showGUI = EditorGUILayout.Foldout(m_showGUI, "Show details");
			if (m_showGUI)
				DrawGUI();
			if (EditorGUI.EndChangeCheck())
				EditorUtility.SetDirty(m_statistic);
		}

		protected abstract void DrawGUI();
	}
}
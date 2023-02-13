using UnityEditor;
using UnityEngine;

namespace Shlashurai.Statistics
{
    [CustomEditor(typeof(StatisticManager))]
    public class StatisticManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Collect statistics"))
            {
                (target as StatisticManager).CollectStatistics();
            }
        }
    }
}
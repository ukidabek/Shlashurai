using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Utilities.States
{
	[CustomEditor(typeof(SwitchStateStateLogic))]
	public class SwitchStateStateLogicEditor : Editor
	{
		private SwitchStateStateLogic m_switchStateStateLogic = null;
		FieldInfo m_stateFieldInfo = null;

		private void OnEnable()
		{
			m_switchStateStateLogic = (target as SwitchStateStateLogic);
			m_stateFieldInfo = m_switchStateStateLogic
				.GetType()
				.GetField("_stateToEnter", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		public override void OnInspectorGUI()
		{
			var state = m_stateFieldInfo.GetValue(target) as State;
			if (state != null) 
			{
				var oldColor = GUI.color;
				GUI.color = Color.yellow;
				GUILayout.Label(state.name);
				GUI.color = oldColor;
			}

			base.OnInspectorGUI();
			if (GUILayout.Button("Get StateMachine"))
			{
				m_switchStateStateLogic.GetStateMachineObject();
				EditorUtility.SetDirty(target);
			}
			if (GUILayout.Button("Get Conditions"))
			{
				m_switchStateStateLogic.GetConditions();
				EditorUtility.SetDirty(target);
			}
		}
	}
}
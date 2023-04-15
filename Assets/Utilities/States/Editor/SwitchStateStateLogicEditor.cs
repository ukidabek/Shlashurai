using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Utilities.States
{
	[CustomEditor(typeof(SwitchStateStateLogic))]
	public class SwitchStateStateLogicEditor : Editor
	{
		private SwitchStateStateLogic m_switchStateStateLogic = null;
		private FieldInfo m_stateFieldInfo = null;
		private IEnumerable<IStateMachine> m_stateMachines = null;
		private bool m_showStateMachines = false;

		private SerializedProperty m_stateMachineSerializedProperty = null;

		private void OnEnable()
		{
			m_switchStateStateLogic = (target as SwitchStateStateLogic);
			m_stateFieldInfo = m_switchStateStateLogic
				.GetType()
				.GetField("_stateToEnter", BindingFlags.Instance | BindingFlags.NonPublic);
			m_stateMachines = m_switchStateStateLogic.GetComponentsFormRoot<IStateMachine>();
			m_stateMachineSerializedProperty = serializedObject.FindProperty("_stateMachineInstance");
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

			var stateMachine = m_stateMachines.StateMachineSelector(ref m_showStateMachines);
			if(stateMachine != null && stateMachine is Object stateMachineObject) 
			{
				m_stateMachineSerializedProperty.objectReferenceValue = stateMachineObject;
				serializedObject.ApplyModifiedProperties();
			}

			if (GUILayout.Button("Get Conditions"))
			{
				m_switchStateStateLogic.GetConditions();
				EditorUtility.SetDirty(target);
			}
		}
	}
}
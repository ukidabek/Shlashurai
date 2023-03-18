using UnityEditor;
using UnityEngine;

namespace Utilities.States
{
	[CustomEditor(typeof(SwitchStateStateLogic))]
	public class SwitchStateStateLogicEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (GUILayout.Button("Get StateMachine"))
			{
				(target as SwitchStateStateLogic).GetStateMachineObject();
				EditorUtility.SetDirty(target);
			}
		}
	}
}
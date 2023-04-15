using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Utilities.States
{
	internal static class StateEditorHelper
	{
		public static IEnumerable<T> GetComponentsFormRoot<T>(this Component component)
		{
			var rootGameObject = component.transform.root;
			return rootGameObject.GetComponentsInChildren<T>();
		}

		public static IStateMachine StateMachineSelector(this IEnumerable<IStateMachine> stateMachines, ref bool show)
		{
			if(show)
			{
				foreach (var stateMachine in stateMachines)
				{
					EditorGUILayout.BeginHorizontal();
					GUILayout.Label(stateMachine.Name);
					if (GUILayout.Button("Select", GUILayout.Width(45)))
					{
						show = false;
						return stateMachine;
					}
					EditorGUILayout.EndHorizontal();
				}

				if (GUILayout.Button("Cancel"))
					show = false;
			}
			else
			{
				if (GUILayout.Button("Select"))
					show = true;
			}
			return null;
		}
	}
}
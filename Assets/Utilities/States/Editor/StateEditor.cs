using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Utilities.States
{
	[CustomEditor(typeof(State))]
	public class StateEditor : Editor
	{
		private State m_state = null;
		private FieldInfo m_stateLogicList = null;

		private void OnEnable()
		{
			m_state = target as State;
			m_stateLogicList = m_state
				.GetType()
				.GetField("m_logic", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (GUILayout.Button("Get all state logic components"))
			{
				var stateLogic = m_state
					.GetComponents<IStateLogic>()
					.OfType<Object>();
		
				var currentStateLogicSet = (m_stateLogicList
					.GetValue(m_state) as Object[])
					.Where(stateLogic => stateLogic != null);

				var exception = stateLogic.Except(currentStateLogicSet);

				var newList = currentStateLogicSet.Concat(exception).OfType<Object>().ToArray();
				m_stateLogicList.SetValue(m_state, newList);

				EditorUtility.SetDirty(m_state);
			}
		}
	}
}
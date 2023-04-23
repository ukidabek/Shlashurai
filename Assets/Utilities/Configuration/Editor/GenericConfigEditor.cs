using System;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Utilities.Configuration
{
	[CustomEditor(typeof(GenericConfig), true)]
	public class GenericConfigEditor : Editor
	{
		GenericConfig m_configuration = null;

		private void OnEnable()
		{
			m_configuration = (GenericConfig)target;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (GUILayout.Button("Add setting"))
			{
				var currentPoint = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
				var context = new SearchWindowContext(currentPoint);
				var settingsTypeProvider = CreateInstance<SettingsTypeProvider>();
				settingsTypeProvider.AddSetting += SettingsTypeProvider_AddSetting;
				SearchWindow.Open(context, settingsTypeProvider);
			}
		}

		private void SettingsTypeProvider_AddSetting(Type obj)
		{
			var setting = Activator.CreateInstance(obj) as ISetting;
			m_configuration.AddSetting(setting);
		}
	}
}
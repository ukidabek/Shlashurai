using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Utilities.Configuration
{
	internal class SettingsTypeProvider : ScriptableObject, ISearchWindowProvider
	{
		private List<Type> m_settingsType = null;
		public event Action<Type> AddSetting = null
			;

		private void OnEnable()
		{
			var subclassType = typeof(ISetting);
			m_settingsType = AppDomain.CurrentDomain
				.GetAssemblies()
				.SelectMany(assembly => assembly.GetTypes())
				.Where(type => type.GetInterface(subclassType.Name) != null && !type.IsAbstract)
				.ToList();
		}

		public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
		{
			List<SearchTreeEntry> searchList = new List<SearchTreeEntry>();
			searchList.Add(new SearchTreeGroupEntry(new GUIContent("x"), 0));
			foreach (var type in m_settingsType)
			{
				var entry = new SearchTreeEntry(new GUIContent(type.Name));
				entry.level = 1;
				entry.userData = type;
				searchList.Add(entry);
			}
			return searchList;
		}

		public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
		{
			AddSetting?.Invoke(SearchTreeEntry.userData as Type);
			return true;
		}
	}
}

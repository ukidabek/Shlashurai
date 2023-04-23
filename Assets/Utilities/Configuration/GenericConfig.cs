using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Configuration
{
	[CreateAssetMenu(menuName = "Configuration/GenericConfiguration", fileName = "GenericConfiguration")]
	public class GenericConfig : Config
	{
		[SerializeReference] private List<ISetting> m_settings = new List<ISetting>();

		public override IEnumerable<ISetting> Settings => m_settings;

		public void AddSetting(ISetting obj) => m_settings.Add(obj);
	}
}
using Shlashurai.Containers;
using UnityEngine;
using Utilities.States;

namespace Shlashurai.States
{
	public class SpawnTriggerStateLogic : StateLogic
	{
		[SerializeField] private ItemSpawnManager m_spawn = null;

		public override void Activate()
		{
			base.Activate();
			m_spawn.Spawn();
		}
	}
}
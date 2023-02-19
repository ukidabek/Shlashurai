using UnityEngine;

namespace Shlashurai.Spawn
{
	public class SpawnManager : MonoBehaviour
	{
		[SerializeField] private SpawnBase[] m_spawns = null;

		private void Awake()
		{
			foreach (var spawn in m_spawns)
				spawn.Initialize(transform);
		}
	}
}
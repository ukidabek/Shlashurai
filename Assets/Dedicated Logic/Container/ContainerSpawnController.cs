using UnityEngine;
using Utilities.Containers;


namespace Shlashurai.Containers
{
	public class ContainerSpawnController : MonoBehaviour, IContainerSpawnController
	{
		[SerializeField] private ItemSpawnManager m_itemSpawnManager = null;

		public void Spawn() => m_itemSpawnManager.Spawn();
	}
}
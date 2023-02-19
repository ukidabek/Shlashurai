using UnityEngine;
using Utilities.Pool;

namespace Shlashurai.Spawn
{
	[CreateAssetMenu(menuName = "Spawn/Spawn/GameObjectSpawn", fileName = "GameObjectSpawn")]
	public class GameObjectSpawn : SpawnBase<GameObjectPool, GameObject, GameObject, GameObjectPoolHander>
	{
	}
}
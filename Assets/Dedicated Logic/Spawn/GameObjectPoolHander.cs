using UnityEngine;
using Utilities.Pool;

namespace Shlashurai.Spawn
{
	[CreateAssetMenu(menuName = "Spawn/Handler/GameObjectPoolHander", fileName = "GameObjectPoolHander")]
	public class GameObjectPoolHander : PoolHandler<GameObjectPool, GameObject> 
	{
	}
}
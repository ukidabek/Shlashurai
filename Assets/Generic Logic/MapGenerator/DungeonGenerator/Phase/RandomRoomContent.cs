using UnityEngine;

namespace MapGeneration.DungeonGenerator.V3
{
	public class RandomRoomContent : MonoBehaviour
	{
		[SerializeField, Range(0f,1f)] private float m_chance = .2f;
		
		public void Randomize()
		{
			var roll = Random.Range(0f, 1f);
			gameObject.SetActive(roll <= m_chance);
		}

		public void ForceOff() => gameObject.SetActive(false);
	}
}

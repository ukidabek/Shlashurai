using UnityEngine;

namespace Shlashurai.Characters
{
	public class ResourceOverTimeModifier : MonoBehaviour
	{
		[SerializeField] private ResourceHandler m_resourceChandler = null;
		[SerializeField] private float m_modificationSpeed = 5f;
		public float ModyficationSpeed
		{
			get => m_modificationSpeed;
			set => m_modificationSpeed = value;
		}

		private void Update()
		{
			var deltaTime = Time.deltaTime;
			m_resourceChandler.Value += m_modificationSpeed * deltaTime;
		}
	}
}
using System.Linq;
using UnityEngine;
using Utilities.Configuration;

namespace Shlashurai.Character
{
	public class CharacterSelectionManager : MonoBehaviour
	{
		[SerializeField] private Camera m_camera = null;
		[SerializeField] private GameObject m_instance = null;
		[SerializeField] private Transform m_parent = null;
		[SerializeField] private Config m_currentConfig = null;

		private void Awake()
		{
			m_camera.gameObject.SetActive(false);
		}

		public void SelectConfig(Config config)
		{
			if (!m_camera.gameObject.activeSelf)
				m_camera.gameObject.SetActive(true);

			DestroyInstance();

			m_currentConfig = config;

			CreateInstance(m_currentConfig);
		}

		private void CreateInstance(Config config)
		{
			var characterModelSetting = config.Settings
				.OfType<CharacterModelSetting>()
				.FirstOrDefault();

			m_instance = Instantiate(characterModelSetting.CharacterModel, m_parent, false);
			var layer = m_parent.gameObject.layer;
			var meshRenderers = m_instance.GetComponentsInChildren<Renderer>();

			foreach (var renderer in meshRenderers)
				renderer.gameObject.layer = layer;
		}

		public void ConfirmSelection()
		{
			DestroyInstance();

		}

		private void DestroyInstance()
		{
			if (m_instance != null) 
				Destroy(m_instance);
		}
	}
}
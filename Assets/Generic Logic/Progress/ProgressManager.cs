using System;
using UnityEngine;

namespace Progress
{
	public class ProgressManager : MonoBehaviour
	{
		[SerializeField] private float m_experience = 0f;
		[SerializeField] private int m_level = 0;
		[SerializeField] private ProgressDefinition m_progressDefinition = null;

		public void AddExperience(float experience)
		{
			m_experience += experience;
		}
	}
}

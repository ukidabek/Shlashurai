using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities.States;

public class LoadSceneStateLogic : StateLogic, ISwitchStateCondition
{
	[SerializeField] private int m_sceneIndex = -1;
	[SerializeField] private LoadSceneMode m_loadSceneMode = LoadSceneMode.Additive;

	private AsyncOperation m_asyncOperation;

	public bool Condition => m_asyncOperation.isDone;

	public override void Activate()
	{
		m_asyncOperation = SceneManager.LoadSceneAsync(m_sceneIndex, m_loadSceneMode);
	}
}

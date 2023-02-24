using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities.States;

public class LoadedScenesCleaner : CoroutineStateLogic, ISwitchStateCondition
{
	[SerializeField] private int[] m_sceneBuildIndexToIgnore = null;

	private bool m_initializationDone = false;
	private List<AsyncOperation> m_sceneUnloadOperations = new List<AsyncOperation>();
	public bool Condition
	{
		get
		{
			if(m_initializationDone == false) return false;

			if(m_initializationDone && m_sceneUnloadOperations.Any() == false) return true;

			return m_sceneUnloadOperations.All(operation => operation.isDone);
		}
	}

	public override void Activate()
	{
		base.Activate();
		m_sceneUnloadOperations.Clear();
		m_initializationDone = false;
	}

	public override IEnumerator Coroutine()
	{
		var loadedScenes = SceneManager.sceneCount;
		var sceneList = new Scene[loadedScenes];
		for (int i = 0; i < loadedScenes; i++)
		{
			sceneList[i] = SceneManager.GetSceneAt(i);
		}

		yield return new WaitUntil(() => sceneList.All(scene => scene.isLoaded));

		for (int i = 0; i < loadedScenes; i++)
		{
			var buildIndex = sceneList[i].buildIndex;
			if (m_sceneBuildIndexToIgnore.Contains(buildIndex)) continue;
			var operation = SceneManager.UnloadSceneAsync(buildIndex);
			m_sceneUnloadOperations.Add(operation);
		}

		m_initializationDone = true;
	}

	public void OnUpdate(float deltaTime, float timeScale)
	{
		var loadedScenes = SceneManager.sceneCount;
		for (int i = 1; i < loadedScenes; i++)
		{
			var scene = SceneManager.GetSceneAt(i);
			if(scene.isLoaded == false) continue;
			var operation = SceneManager.UnloadSceneAsync(scene);
			m_sceneUnloadOperations.Add(operation);
		}
	}
}
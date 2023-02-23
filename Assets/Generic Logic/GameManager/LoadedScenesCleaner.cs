using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities.States;

public class LoadedScenesCleaner : CoroutineStateLogic, ISwitchStateCondition
{
#if UNITY_EDITOR

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
#else
	public bool Condition => true;z
#endif

	public override void Activate()
	{
		base.Activate();
#if UNITY_EDITOR
		m_sceneUnloadOperations.Clear();
		m_initializationDone = false;
#endif

	}

	public override IEnumerator Coroutine()
	{
#if UNITY_EDITOR
		var loadedScenes = SceneManager.sceneCount;
		var sceneList = new Scene[loadedScenes];
		for (int i = 0; i < loadedScenes; i++)
		{
			sceneList[i] = SceneManager.GetSceneAt(i);
		}

		yield return new WaitUntil(() => sceneList.All(scene => scene.isLoaded));

		for (int i = 1; i < loadedScenes; i++)
		{
			var operation = SceneManager.UnloadSceneAsync(sceneList[i]);
			m_sceneUnloadOperations.Add(operation);
		}

		m_initializationDone = true;
#else
		yield return null;
#endif
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
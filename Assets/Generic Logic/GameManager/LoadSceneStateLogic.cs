using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities.States;

public class LoadSceneStateLogic : StateLogic, ISwitchStateCondition
{
#if UNITY_EDITOR
	[SerializeField] private UnityEditor.SceneAsset scentToLoad;
#endif
	[SerializeField] private int m_sceneIndex = -1;
	[SerializeField] private LoadSceneMode m_loadSceneMode = LoadSceneMode.Additive;

	private AsyncOperation m_asyncOperation;

	public bool Condition => m_asyncOperation.isDone;

	public override void Activate()
	{
		m_asyncOperation = SceneManager.LoadSceneAsync(m_sceneIndex, m_loadSceneMode);
	}

	private void OnValidate()
	{
#if UNITY_EDITOR
		if(scentToLoad == null) return;
		var length = UnityEditor.EditorBuildSettings.scenes.Length;
		for (int i = 0; i < length; i++)
		{
			var editorScene = UnityEditor.EditorBuildSettings.scenes[i];
			var path = UnityEditor.AssetDatabase.GetAssetPath(scentToLoad);
			if (editorScene.path == path)
			{
				m_sceneIndex = i;
				break;
			}
		}
#endif
	}
}

using MapGeneration.BaseGenerator;
using UnityEngine;

namespace MapGeneration.DungeonGenerator
{
	public class DebugCameraInitialization : MonoBehaviour, IGenerationInitalization
    {
        [SerializeField] private Camera _debugCamera = null;
        [SerializeField] private KeyCode _showDebugCamera = KeyCode.F12;

        private void Awake()
        {
            _debugCamera.enabled = false;
        }

        public void Initialize(LevelGenerator generator, object[] generationData)
        {
            var settings = generator.GetMetaDataObject<GenerationSettings>();

            Vector3 position = new Vector3(((settings.Size.x - 1) * settings.RoomSize.x) / 2, 100, ((settings.Size.y - 1) * settings.RoomSize.y) / 2);

            _debugCamera.orthographicSize = (settings.RoomSize.x * settings.Size.x) / 2;
            _debugCamera.transform.position = position;
        }

        private void Update()
        {
            bool buttonPressed = Input.GetKey(_showDebugCamera);
            if (_debugCamera.enabled != buttonPressed)
                _debugCamera.enabled = buttonPressed;            
        }
    }
}
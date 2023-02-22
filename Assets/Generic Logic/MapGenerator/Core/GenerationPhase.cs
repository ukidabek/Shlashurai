using System.Collections;
using UnityEngine;

namespace MapGeneration.BaseGenerator
{
	public abstract class GenerationPhase : MonoBehaviour, IGenerationPhase
    {
        [SerializeField] protected bool _isDone = false;
        public bool IsDone { get { return _isDone; } set { _isDone = value; } }

        [SerializeField] protected bool _pause = false;
        public bool Pause { get { return _pause; } }

        public abstract IEnumerator Generate(LevelGenerator generator);
    }
}
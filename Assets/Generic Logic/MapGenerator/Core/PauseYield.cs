using UnityEngine;

namespace MapGeneration.BaseGenerator
{
	public class PauseYield : CustomYieldInstruction
    {
        private LevelGenerator _generator = null;

        public PauseYield(LevelGenerator generator)
        {
            this._generator = generator;
        }

        public override bool keepWaiting { get { return _generator.State == GenerationState.Pause; } }
    }
}
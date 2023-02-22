using System.Collections;

namespace MapGeneration.BaseGenerator
{
    public interface IGenerationPhase
    {
        bool IsDone { get; set; }
        bool Pause { get; }
        IEnumerator Generate(LevelGenerator generator);
    }
}
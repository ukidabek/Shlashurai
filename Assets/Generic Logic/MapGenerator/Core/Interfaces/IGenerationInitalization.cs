namespace MapGeneration.BaseGenerator
{
    public interface IGenerationInitalization
    {
        void Initialize(LevelGenerator generator, object[] generationData);
    }
}
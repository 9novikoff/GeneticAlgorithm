namespace GeneticAlgorithm.Domain.Mutations;

public interface IMutation
{
    public IChromosome Mutate(IChromosome chromosome);
}
namespace GeneticAlgorithm.Domain.Selections;

public interface IVariationSelection
{
    public IChromosome[] Select(IChromosome[] population, IFitness fitness, double percent);
}
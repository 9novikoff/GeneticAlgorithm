namespace GeneticAlgorithm.Domain.Selections;

public interface IPopulationSelection
{
    public IChromosome[] Select(IChromosome[] population, IChromosome[] variated, IFitness fitness);
}
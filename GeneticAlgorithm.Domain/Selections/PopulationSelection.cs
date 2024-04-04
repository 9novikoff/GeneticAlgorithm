namespace GeneticAlgorithm.Domain.Selections;

public class PopulationSelection : IPopulationSelection
{
    public IChromosome[] Select(IChromosome[] population, IChromosome[] variated, IFitness fitness)
    {
        var chromosomes = population.Concat(variated).OrderByDescending(fitness.Evaluate).ToList();
        return chromosomes.Take(population.Length).ToArray();
    }
}
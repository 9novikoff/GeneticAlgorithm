namespace GeneticAlgorithm.Domain.Selections;

public class VariationSelection : IVariationSelection
{
    public IChromosome[] Select(IChromosome[] population, IFitness fitness, double percent)
    {
        return population.OrderByDescending(fitness.Evaluate).ToArray()[0..(int)Math.Floor(percent * population.Length)];
    }
}
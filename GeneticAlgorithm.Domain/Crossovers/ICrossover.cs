namespace GeneticAlgorithm.Domain.Crossovers;

public interface ICrossover
{
    public (IChromosome, IChromosome) Cross(IChromosome firstChromosome, IChromosome secondChromosome);
}
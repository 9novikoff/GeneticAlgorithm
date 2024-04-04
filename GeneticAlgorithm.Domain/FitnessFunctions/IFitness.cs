namespace GeneticAlgorithm.Domain.Selections;

public interface IFitness
{
    public double Evaluate(IChromosome chromosome);
}
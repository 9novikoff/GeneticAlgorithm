namespace GeneticAlgorithm.Domain.Selections;

public class DistanceFitness : IFitness
{
    public double Evaluate(IChromosome chromosome)
    {
        double sum = 0;
        var last = chromosome.Genes.Aggregate((a, b) =>
        {
            sum += ((DistanceGene)a).Distances[((DistanceGene)b).Number];
            return b;
        });

        sum += ((DistanceGene)last).Distances[((DistanceGene)chromosome.Genes[0]).Number];

        return 1 / sum;
    }
}
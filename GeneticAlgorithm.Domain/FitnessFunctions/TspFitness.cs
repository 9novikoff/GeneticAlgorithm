namespace GeneticAlgorithm.Domain.Selections;

public class TspFitness : IFitness
{
    public double Evaluate(IChromosome chromosome)
    {
        double distance = 0;
        chromosome.Genes.Aggregate((a, b) =>
        {
            distance += EuclideanTwoDimensionDistance((PointGene)a, (PointGene)b);
            return b;
        });

        return 1/distance;
    }

    private static double EuclideanTwoDimensionDistance(PointGene firstGene, PointGene secondGene)
    {
        return Math.Sqrt(Math.Pow(firstGene.X - secondGene.X, 2) + Math.Pow(firstGene.Y - secondGene.Y, 2));
    }
}
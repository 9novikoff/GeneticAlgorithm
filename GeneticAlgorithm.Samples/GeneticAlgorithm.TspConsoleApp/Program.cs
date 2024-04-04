using GeneticAlgorithm.Domain;
using GeneticAlgorithm.Domain.Crossovers;
using GeneticAlgorithm.Domain.Mutations;
using GeneticAlgorithm.Domain.PopulationGenerators;
using GeneticAlgorithm.Domain.Selections;

namespace GeneticAlgorithm.TspConsoleApp;

class Program
{
    private const string TspGenes = "berlin52.xml";
    private const int PopulationSize = 100; 
    static void Main(string[] args)
    {
        IGenesReader reader = new XmlGenesReader();
        var genes = reader.Read(TspGenes);

        IChromosome[] routeChromosomesPopulation = PopulationGenerator.GeneratePermutation(genes, PopulationSize).Select(g => new RouteChromosome(g.ToArray())).ToArray();
        
        IGeneticAlgorithm algorithm = new Domain.GeneticAlgorithm(routeChromosomesPopulation, Condition(),
            new PopulationSelection(), new VariationSelection(), new PartiallyMappedCrossover(),
            new InversionMutation(), new DistanceFitness());

        Console.WriteLine(1/algorithm.Fitness.Evaluate(routeChromosomesPopulation[0]));
        
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        
        var resultPopulation = algorithm.Run();
        
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        
        var best = resultPopulation.OrderByDescending(algorithm.Fitness.Evaluate).First();
        Console.WriteLine(1/algorithm.Fitness.Evaluate(best));
        
        foreach (var gene in best.Genes)
        {
            Console.Write($"{gene},");
        }
    }

    private static IEnumerator<int> Condition()
    {
        const int iterationsAmount = 1000;
        for (int i = 0; i < iterationsAmount; i++)
        {
            yield return i;
        }
    }
}
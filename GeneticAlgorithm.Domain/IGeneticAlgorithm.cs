using System.Collections;
using GeneticAlgorithm.Domain.Crossovers;
using GeneticAlgorithm.Domain.Mutations;
using GeneticAlgorithm.Domain.PopulationGenerators;
using GeneticAlgorithm.Domain.Selections;

namespace GeneticAlgorithm.Domain;

public interface IGeneticAlgorithm
{
    public IChromosome[] Population { get; set; }
    public IEnumerator Condition { get; set; }
    public IPopulationSelection PopulationSelection { get; set; }
    public IVariationSelection VariationSelection { get; set; }
    public ICrossover Crossover { get; set; }
    public IMutation Mutation { get; set; }
    public IFitness Fitness { get; set; }

    
    public IChromosome[] Run()
    {
        const double variationPopulationPercent = 0.9;
        const double mutationProbability = 0.5;
        
        if (Condition.Current == null)
            return Population;
        do
        {
            var selectedPopulation = (IChromosome[])VariationSelection.Select(Population, Fitness, variationPopulationPercent).Clone();
            
            var variatedPopulation = new IChromosome[selectedPopulation.Length];

            for (int i = 0; i < variatedPopulation.Length - variatedPopulation.Length%2; i+=2)
            {
                var crossed = Crossover.Cross(selectedPopulation[i], selectedPopulation[i + 1]);

                var firstChromosome = crossed.Item1;
                var secondChromosome = crossed.Item2;

                if (NumbersGenerator.IsProbable(mutationProbability))
                {
                    firstChromosome = Mutation.Mutate(firstChromosome);
                    secondChromosome = Mutation.Mutate(secondChromosome);
                }

                variatedPopulation[i] = firstChromosome;
                variatedPopulation[i + 1] = secondChromosome;
            }
            
            if (variatedPopulation.Length % 2 != 0)
                variatedPopulation[^1] = selectedPopulation[^1];
            
            Population = PopulationSelection.Select(Population, variatedPopulation, Fitness);
            
        } while (Condition.MoveNext());

        return Population;
    }
}
using System.Collections;
using GeneticAlgorithm.Domain.Crossovers;
using GeneticAlgorithm.Domain.Mutations;
using GeneticAlgorithm.Domain.Selections;

namespace GeneticAlgorithm.Domain;

public class GeneticAlgorithm : IGeneticAlgorithm
{
    public GeneticAlgorithm(IChromosome[] population, IEnumerator condition, IPopulationSelection populationSelection, IVariationSelection variationSelection, ICrossover crossover, IMutation mutation, IFitness fitness)
    {
        Population = population;
        Condition = condition;
        PopulationSelection = populationSelection;
        VariationSelection = variationSelection;
        Crossover = crossover;
        Mutation = mutation;
        Fitness = fitness;
    }

    public IChromosome[] Population { get; set; }
    public IEnumerator Condition { get; set; }
    public IPopulationSelection PopulationSelection { get; set; }
    public IVariationSelection VariationSelection { get; set; }
    public ICrossover Crossover { get; set; }
    public IMutation Mutation { get; set; }
    public IFitness Fitness { get; set; }
}



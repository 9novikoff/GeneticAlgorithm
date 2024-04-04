using GeneticAlgorithm.Domain.PopulationGenerators;

namespace GeneticAlgorithm.Domain.Mutations;

public class InversionMutation : IMutation
{
    public IChromosome Mutate(IChromosome chromosome)
    {
        var resultChromosome = (IChromosome)chromosome.Clone();
        resultChromosome.Genes = chromosome.Genes.Select(g => (IGene)g.Clone()).ToArray();
        
        var(k1, k2) = NumbersGenerator.GetRandomBoards(0, resultChromosome.Genes.Length);

        for (int i = 0; k1 + i < (float)(k2+k1)/2; i++)
        {
            if(k1+i != k2-i)
                (resultChromosome.Genes[k1 + i], resultChromosome.Genes[k2 - i]) = (resultChromosome.Genes[k2 - i], resultChromosome.Genes[k1 + i]);
        }

        return resultChromosome;
    }
}
using GeneticAlgorithm.Domain.PopulationGenerators;

namespace GeneticAlgorithm.Domain.Crossovers;

public class PartiallyMappedCrossover : ICrossover
{
    public (IChromosome, IChromosome) Cross(IChromosome firstChromosome, IChromosome secondChromosome)
    {
        var firstNewChromosome = (IChromosome)firstChromosome.Clone();
        firstNewChromosome.Genes = firstChromosome.Genes.Select(g => (IGene)g.Clone()).ToArray();
        
        var secondNewChromosome = (IChromosome)secondChromosome.Clone();
        secondNewChromosome.Genes = secondChromosome.Genes.Select(g => (IGene)g.Clone()).ToArray();
        
        var firstBackup = firstChromosome.Genes.Select(g => (IGene)g.Clone()).ToArray();
        var secondBackup = secondChromosome.Genes.Select(g => (IGene)g.Clone()).ToArray();
        
        var(k1, k2) = NumbersGenerator.GetRandomBoards(0, firstNewChromosome.Genes.Length);

        for (int i = k1; i <= k2; i++)
        {
            (firstNewChromosome.Genes[i], secondNewChromosome.Genes[i]) =
                (secondNewChromosome.Genes[i], firstNewChromosome.Genes[i]);
        }

        for (int i = 0; i < k1; i++)
        {
            var current = firstNewChromosome.Genes[i];
            while (firstNewChromosome.Genes[k1..(k2 + 1)].Select(g => g.Equals(current)).Any(e => e != false))
            {
                current = firstBackup[Array.IndexOf(secondBackup, current)];
            }
            firstNewChromosome.Genes[i] = current;

            current = secondNewChromosome.Genes[i];
            while (secondNewChromosome.Genes[k1..(k2 + 1)].Select(g => g.Equals(current)).Any(e => e != false))
            {
                current = secondBackup[Array.IndexOf(firstBackup, current)];
            }
            secondNewChromosome.Genes[i] = current;
        }
        for (int i = k2+1; i < firstNewChromosome.Genes.Length; i++)
        {
            var current = firstNewChromosome.Genes[i];
            while (firstNewChromosome.Genes[k1..(k2 + 1)].Select(g => g.Equals(current)).Any(e => e != false))
            {
                current = firstBackup[Array.IndexOf(secondBackup, current)];
            }
            firstNewChromosome.Genes[i] = current;

            current = secondNewChromosome.Genes[i];
            while (secondNewChromosome.Genes[k1..(k2 + 1)].Select(g => g.Equals(current)).Any(e => e != false))
            {
                current = secondBackup[Array.IndexOf(firstBackup, current)];
            }
            secondNewChromosome.Genes[i] = current;
        }
        
        return (firstNewChromosome, secondNewChromosome);
    }

    // public (IChromosome, IChromosome) Cross(IChromosome firstChromosome, IChromosome secondChromosome)
    // {
    //     return (firstChromosome, secondChromosome);
    // }
}
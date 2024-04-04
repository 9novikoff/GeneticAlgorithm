namespace GeneticAlgorithm.Domain.PopulationGenerators;

public static class PopulationGenerator
{
    public static IEnumerable<IEnumerable<IGene>> GeneratePermutation(IGene[] genes, int amount)
    {
        return genes.Permute().Take(amount);
    }
    
    private static int Factorial(int n)
    {
        return Enumerable.Range(1, n).Aggregate((a, b) => a * b);
    }
    
    private static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T>? sequence)
    {
        if (sequence == null)
        {
            yield break;
        }

        var list = sequence.ToList();

        if (!list.Any())
        {
            yield return Enumerable.Empty<T>();
        }
        else
        {
            var startingElementIndex = 0;

            foreach (var startingElement in list)
            {
                var index = startingElementIndex;
                var remainingItems = list.Where((e, i) => i != index);

                foreach (var permutationOfRemainder in remainingItems.Permute())
                {
                    yield return permutationOfRemainder.Prepend(startingElement);
                }

                startingElementIndex++;
            }
        }
    }
    
}
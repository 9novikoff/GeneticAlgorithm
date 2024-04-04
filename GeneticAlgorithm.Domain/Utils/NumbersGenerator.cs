namespace GeneticAlgorithm.Domain.PopulationGenerators;

public static class NumbersGenerator
{
    public static (int, int) GetRandomBoards(int minValue, int maxValue)
    {
        var random = new Random();
        var (first, second) = (random.Next(minValue, maxValue), random.Next(minValue, maxValue));

        if (first < second)
            return (first, second);
        if (first > second)
            return (second, first);
        if (first == minValue)
            return (first, random.Next(minValue + 1, maxValue));
        return first == maxValue - 1 ? (random.Next(minValue, maxValue - 1), first) : (first, second + 1);
    }

    public static bool IsProbable(double probability)
    {
        return new Random().NextDouble() < probability;
    }
}
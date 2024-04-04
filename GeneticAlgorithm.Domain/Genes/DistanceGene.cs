namespace GeneticAlgorithm.Domain;

public class DistanceGene : IGene
{
    public DistanceGene(int number, double[] distances)
    {
        Number = number;
        Distances = distances;
    }
    public int Number { get; }
    public double[] Distances { get; set; }

    public bool Equals(IGene? other)
    {
        if (other is DistanceGene otherPoint)
            return otherPoint.Distances.SequenceEqual(Distances);
        return false;
    }

    public override string ToString()
    {
        return $"{Number}";
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
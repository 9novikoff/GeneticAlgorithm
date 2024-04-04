namespace GeneticAlgorithm.Domain;

public class PointGene: IGene
{
    public PointGene(int number, double x, double y)
    {
        Number = number;
        X = x;
        Y = y;
    }
    public int Number { get; }
    public double X { get; set; }
    public double Y { get; set; }

    public bool Equals(IGene? other)
    {
        if (other is PointGene otherPoint)
            return Math.Abs(otherPoint.X - this.X) < 1e-15 && Math.Abs(otherPoint.Y - this.Y) < 1e-15;
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
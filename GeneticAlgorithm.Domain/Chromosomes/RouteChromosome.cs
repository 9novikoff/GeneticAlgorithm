namespace GeneticAlgorithm.Domain;

public class RouteChromosome: IChromosome
{
    public RouteChromosome(IGene[] genes)
    {
        Genes = genes;
    }

    public IGene[] Genes { get; set; }
    
    public object Clone()
    {
        Genes = Genes.Select(g => (IGene)g.Clone()).ToArray();
        return this.MemberwiseClone();
    }
}
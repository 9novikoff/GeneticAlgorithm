namespace GeneticAlgorithm.Domain;

public interface IChromosome: ICloneable
{
    IGene[] Genes { get; set; }
}
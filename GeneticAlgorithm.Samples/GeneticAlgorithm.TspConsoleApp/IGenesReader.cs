using GeneticAlgorithm.Domain;

namespace GeneticAlgorithm.TspConsoleApp;

public interface IGenesReader
{
    public IGene[] Read(string path);
}
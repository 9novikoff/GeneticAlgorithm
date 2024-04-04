using GeneticAlgorithm.Domain;

namespace GeneticAlgorithm.TspConsoleApp;

public class TspGenesReader : IGenesReader
{
    public IGene[] Read(string path)
    {
        var lines = File.ReadAllLines(path);
        var genes = new IGene[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            var split = lines[i].Split(' '); 
            genes[i] = new PointGene(int.Parse(split[0]), double.Parse(split[1]), double.Parse(split[2]));
        }

        return genes;
    }
}
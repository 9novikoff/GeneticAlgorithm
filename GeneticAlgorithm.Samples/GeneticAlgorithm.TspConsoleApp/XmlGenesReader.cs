using System.Xml;
using GeneticAlgorithm.Domain;

namespace GeneticAlgorithm.TspConsoleApp;

public class XmlGenesReader : IGenesReader
{
    public IGene[] Read(string path)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);

        XmlNodeList vertexNodes = xmlDoc.SelectNodes("//graph/vertex");

        var distanceGenes = new List<DistanceGene>();
        
        int vertex = 0;
        foreach (XmlNode vertexNode in vertexNodes)
        {
            var distances = new double[vertexNodes[0].SelectNodes("edge").Count + 1];
            int number = int.Parse(vertexNode.SelectSingleNode("edge[1]").InnerText);

            var counter = 0;
            foreach (XmlNode edgeNode in vertexNode.SelectNodes("edge"))
            {
                double distance = double.Parse(edgeNode.Attributes["cost"].Value);
                distances[int.Parse(edgeNode.InnerText)] = distance;
            }
            
            distanceGenes.Add(new DistanceGene(vertex, distances));
            vertex++;
        }

        return distanceGenes.ToArray();
    }
}
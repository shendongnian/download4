    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //this one uses strings as node names
                Dijkstra1.Program.Dijkstra();
                //this one uses integers as node names
                Dijkstra2.Program.Dijkstra();
            }
        }
    }
    namespace Dijkstra1
    {
        class Program
        {
            //A connected to B
            //B connected to A, C , D
            //C connected to B, D
            //D connected to B, C , E
            //E connected to D.
            static List<List<String>> input1 = new List<List<string>>{
                   new List<String>() {"A","0","1","0","0","0"},
                   new List<String>() {"B","1","0","1","1","0"},
                   new List<String>() {"C","0","1","0","1","0"},
                   new List<String>() {"D","0","1","1","0","1"},
                   new List<String>() {"E","0","0","0","1","0"}
                };
            //A  |   0 1 2 2 3  |
            //B  |   1      0      1      1      2       |
            //C  |   2      1      0      1      2       | 
            //D  |   2      1      1      0      1       |
            //E  |   3      2      2      1      0       |
            static List<List<String>> input2 = new List<List<string>>{
                   new List<String>() {"A","0","1","2","2","3"},
                   new List<String>() {"B","1","0","1","1","2"},
                   new List<String>() {"C","2","1","0","1","2"},
                   new List<String>() {"D","2","1","1","0","1"},
                   new List<String>() {"E","3","2","2","1","0"}
                };
            static public void Dijkstra()
            {
                CGraph cGraph;
                cGraph = new CGraph(input1);
                Console.WriteLine("-------------Input 1 -------------");
                cGraph.PrintGraph();
                cGraph = new CGraph(input2);
                Console.WriteLine("-------------Input 2 -------------");
                cGraph.PrintGraph();
            }
            class CGraph
            {
                List<Node> graph = new List<Node>();
                public CGraph(List<List<String>> input)
                {
                    foreach (List<string> inputRow in input)
                    {
                        Node newNode = new Node();
                        newNode.name = inputRow[0];
                        newNode.distanceDict = new Dictionary<string, Path>();
                        newNode.visited = false;
                        newNode.neighbors = new List<Neighbor>();
                        //for (int index = 1; index < inputRow.Count; index++)
                        //{
                        //    //skip diagnol values so you don't count a nodes distance to itself.
                        //    //node count start at zero
                        //    // index you have to skip the node name
                        //    //so you have to subtract one from the index
                        //    if ((index - 1) != nodeCount)
                        //    {
                        //        string nodeName = input[index - 1][0];
                        //        int distance = int.Parse(inputRow[index]);
                        //        newNode.distanceDict.Add(nodeName, new List<string>() { nodeName });
                        //    } 
                        //}
                        graph.Add(newNode);
                    }
                    //initialize neighbors using predefined dictionary
                    for (int nodeCount = 0; nodeCount < graph.Count; nodeCount++)
                    {
                        for (int neighborCount = 0; neighborCount < graph.Count; neighborCount++)
                        {
                            //add one to neighbor count to skip Node name in index one
                            if (input[nodeCount][neighborCount + 1] != "0")
                            {
                                Neighbor newNeightbor = new Neighbor();
                                newNeightbor.node = graph[neighborCount];
                                newNeightbor.distance = int.Parse(input[nodeCount][neighborCount + 1]);
                                graph[nodeCount].neighbors.Add(newNeightbor);
                                Path path = new Path();
                                path.nodeNames = new List<string>() { input[neighborCount][0] };
                                //add one to neighbor count to skip Node name in index one
                                path.totalDistance = int.Parse(input[nodeCount][neighborCount + 1]);
                                graph[nodeCount].distanceDict.Add(input[neighborCount][0], path);
                            }
                        }
                    }
                    foreach (Node node in graph)
                    {
                        foreach (Node nodex in graph)
                        {
                            node.visited = false;
                        }
                        TransverNode(node);
                    }
                }
                public class Neighbor
                {
                    public Node node { get; set; }
                    public int distance { get; set; }
                }
                public class Path
                {
                    public List<string> nodeNames { get; set; }
                    public int totalDistance { get; set; }
                }
                public class Node
                {
                    public string name { get; set; }
                    public Dictionary<string, Path> distanceDict { get; set; }
                    public Boolean visited { get; set; }
                    public List<Neighbor> neighbors { get; set; }
                }
                static void TransverNode(Node node)
                {
                    if (!node.visited)
                    {
                        node.visited = true;
                        foreach (Neighbor neighbor in node.neighbors)
                        {
                            TransverNode(neighbor.node);
                            string neighborName = neighbor.node.name;
                            int neighborDistance = neighbor.distance;
                            //compair neighbors dictionary with current dictionary
                            //update current dictionary as required
                            foreach (string key in neighbor.node.distanceDict.Keys)
                            {
                                if (key != node.name)
                                {
                                    int neighborKeyDistance = neighbor.node.distanceDict[key].totalDistance;
                                    if (node.distanceDict.ContainsKey(key))
                                    {
                                        int currentDistance = node.distanceDict[key].totalDistance;
                                        if (neighborKeyDistance + neighborDistance < currentDistance)
                                        {
                                            List<string> nodeList = new List<string>();
                                            nodeList.AddRange(neighbor.node.distanceDict[key].nodeNames);
                                            nodeList.Insert(0, neighbor.node.name);
                                            node.distanceDict[key].nodeNames = nodeList;
                                            node.distanceDict[key].totalDistance = neighborKeyDistance + neighborDistance;
                                        }
                                    }
                                    else
                                    {
                                        List<string> nodeList = new List<string>();
                                        nodeList.AddRange(neighbor.node.distanceDict[key].nodeNames);
                                        nodeList.Insert(0, neighbor.node.name);
                                        Path path = new Path();
                                        path.nodeNames = nodeList;
                                        path.totalDistance = neighbor.distance + neighborKeyDistance;
                                        node.distanceDict.Add(key, path);
                                    }
                                }
                            }
                        }
                    }
                }
                public void PrintGraph()
                {
                    foreach (Node node in graph)
                    {
                        Console.WriteLine("Node : {0}", node.name);
                        foreach (string key in node.distanceDict.Keys.OrderBy(x => x))
                        {
                            Console.WriteLine(" Distance to node {0} = {1}, Path : {2}", key, node.distanceDict[key].totalDistance, string.Join(",", node.distanceDict[key].nodeNames.ToArray()));
                        }
                    }
                }
            }
        }
    }
    namespace Dijkstra2
    {
        class Program
        {
             //0---1---2---3
             //     |
             //    4
             //     |
             //    5---6---7
             //     \  /
             //      8
             //      |
             //      9 
            
            static List<List<int>> input1 = new List<List<int>>
             {       // 0  1  2  3  4  5  6  7  8  9
                    new List<int>() {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                    new List<int>() {1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                    new List<int>() {2, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0},
                    new List<int>() {3, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                    new List<int>() {4, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0},
                    new List<int>() {5, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0},
                    new List<int>() {6, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0},
                    new List<int>() {7, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
                    new List<int>() {8, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1},
                    new List<int>() {9, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
             }; 
            
            static public void Dijkstra()
            {
                CGraph cGraph;
                cGraph = new CGraph(input1);
                Console.WriteLine("-------------Input 1 -------------");
                cGraph.PrintGraph();
            }
            class CGraph
            {
                List<Node> graph = new List<Node>();
                public CGraph(List<List<int>> input)
                {
                    foreach (List<int> inputRow in input)
                    {
                        Node newNode = new Node();
                        newNode.name = inputRow[0];
                        newNode.distanceDict = new Dictionary<int, Path>();
                        newNode.visited = false;
                        newNode.neighbors = new List<Neighbor>();
                        //for (int index = 1; index < inputRow.Count; index++)
                        //{
                        //    //skip diagnol values so you don't count a nodes distance to itself.
                        //    //node count start at zero
                        //    // index you have to skip the node name
                        //    //so you have to subtract one from the index
                        //    if ((index - 1) != nodeCount)
                        //    {
                        //        string nodeName = input[index - 1][0];
                        //        int distance = int.Parse(inputRow[index]);
                        //        newNode.distanceDict.Add(nodeName, new List<string>() { nodeName });
                        //    } 
                        //}
                        graph.Add(newNode);
                    }
                    //initialize neighbors using predefined dictionary
                    for (int nodeCount = 0; nodeCount < graph.Count; nodeCount++)
                    {
                        for (int neighborCount = 0; neighborCount < graph.Count; neighborCount++)
                        {
                            //add one to neighbor count to skip Node name in index one
                            if (input[nodeCount][neighborCount + 1] != 0)
                            {
                                Neighbor newNeightbor = new Neighbor();
                                newNeightbor.node = graph[neighborCount];
                                newNeightbor.distance = input[nodeCount][neighborCount + 1];
                                graph[nodeCount].neighbors.Add(newNeightbor);
                                Path path = new Path();
                                path.nodeNames = new List<int>() { input[neighborCount][0] };
                                //add one to neighbor count to skip Node name in index one
                                path.totalDistance = input[nodeCount][neighborCount + 1];
                                graph[nodeCount].distanceDict.Add(input[neighborCount][0], path);
                            }
                        }
                    }
                    foreach (Node node in graph)
                    {
                        foreach (Node nodex in graph)
                        {
                            node.visited = false;
                        }
                        TransverNode(node);
                    }
                }
                public class Neighbor
                {
                    public Node node { get; set; }
                    public int distance { get; set; }
                }
                public class Path
                {
                    public List<int> nodeNames { get; set; }
                    public int totalDistance { get; set; }
                }
                public class Node
                {
                    public int name { get; set; }
                    public Dictionary<int, Path> distanceDict { get; set; }
                    public Boolean visited { get; set; }
                    public List<Neighbor> neighbors { get; set; }
                }
                static void TransverNode(Node node)
                {
                    if (!node.visited)
                    {
                        node.visited = true;
                        foreach (Neighbor neighbor in node.neighbors)
                        {
                            TransverNode(neighbor.node);
                            int neighborName = neighbor.node.name;
                            int neighborDistance = neighbor.distance;
                            //compair neighbors dictionary with current dictionary
                            //update current dictionary as required
                            foreach (int key in neighbor.node.distanceDict.Keys)
                            {
                                if (key != node.name)
                                {
                                    int neighborKeyDistance = neighbor.node.distanceDict[key].totalDistance;
                                    if (node.distanceDict.ContainsKey(key))
                                    {
                                        int currentDistance = node.distanceDict[key].totalDistance;
                                        if (neighborKeyDistance + neighborDistance < currentDistance)
                                        {
                                            List<int> nodeList = new List<int>();
                                            nodeList.AddRange(neighbor.node.distanceDict[key].nodeNames);
                                            nodeList.Insert(0, neighbor.node.name);
                                            node.distanceDict[key].nodeNames = nodeList;
                                            node.distanceDict[key].totalDistance = neighborKeyDistance + neighborDistance;
                                        }
                                    }
                                    else
                                    {
                                        List<int> nodeList = new List<int>();
                                        nodeList.AddRange(neighbor.node.distanceDict[key].nodeNames);
                                        nodeList.Insert(0, neighbor.node.name);
                                        Path path = new Path();
                                        path.nodeNames = nodeList;
                                        path.totalDistance = neighbor.distance + neighborKeyDistance;
                                        node.distanceDict.Add(key, path);
                                    }
                                }
                            }
                        }
                    }
                }
                public void PrintGraph()
                {
                    foreach (Node node in graph)
                    {
                        Console.WriteLine("Node : {0}", node.name);
                        foreach (int key in node.distanceDict.Keys.OrderBy(x => x))
                        {
                            Console.WriteLine(" Distance to node {0} = {1}, Path : {2}", key, node.distanceDict[key].totalDistance, string.Join(",", node.distanceDict[key].nodeNames.ToArray()));
                        }
                    }
                }
            }
        }
    }
    ​

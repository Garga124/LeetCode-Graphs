/*Time complexity:O(V + E), the Time Complexity of this method is the same as the time complexity of DFS traversal which is O(V+E).
Space complexity:O(V). The extra space of V is needed for the stack, recursionstack and visited array
*/
public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        //Create an Adjacency List
        Dictionary<int, List<int>> adjList = BuildAdjacencyList(graph);
        //Get the number of nodes 
        int vertex = graph.GetLength(0);
        //Call method to return the safenodes
        return EventualSafeNodes(adjList,vertex);
         
    }

    //Method to calculate the safe nodes
    public IList<int> EventualSafeNodes(Dictionary<int,List<int>> adjList,int vertex)
    {
        //Define the list of the variables required
        bool[] visited = new bool[vertex];
        bool[] recTraversal = new bool[vertex];
        bool[] check = new bool[vertex];
        IList<int> result = new List<int>();

        //Loop on all the nodes to traverse using DFS traversal and identify if there is a cycle
        for(int i =0;i<vertex;i++)
        {
            if(!visited[i])
            {
                 dfsTraversal(i,adjList,visited,recTraversal,check);
            }
        }

        //Non-cyclic nodes will be marked as true . Print those nodes
        for(int i =0;i<vertex;i++)
        {
            if(check[i])
            {
                result.Add(i);

            }
        }
        return result;

    }

    //DFS traversal of the graph

    public bool dfsTraversal(int vertex, Dictionary<int,List<int>> adjList, bool[] visited, bool[] recTraversal, bool[]check)
    {
        if(!visited[vertex])
        {
            check[vertex] = false;
            visited[vertex] = true;
            recTraversal[vertex] = true;
            foreach(int edge in adjList[vertex])
            {
                if(!visited[edge] && dfsTraversal(edge,adjList,visited,recTraversal,check )){
                    return true;
                }else if(recTraversal[edge])
                {
                    return true;
                }
            }
        }
        check[vertex] = true;
        recTraversal[vertex] = false;
        return false;
    }

    public Dictionary<int, List<int>> BuildAdjacencyList(int[][] graph)
    {
        Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
        int vertex = graph.GetLength(0);
        for(int i=0;i<vertex;i++)
        {
            adjList[i] = new List<int>();
        }
        int count = 0;
        foreach(int[] edge in graph)
        {
           foreach(int item in edge)
           {
            adjList[count].Add(item);
           }
           count++;
        }
        return adjList;
    }
}
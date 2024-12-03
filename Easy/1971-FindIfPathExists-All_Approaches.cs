/*
Time Complexity O(V+E)
Space Complexity O(V+E)
*/
public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        Dictionary<int,List<int>> adj = BuildAdjacencyList(edges);
       // return ifPathExistsUsingBFS(adj,source,destination);
        //return ifPathExistsUsingDFS(adj,source,destination);
        return ifPathExistsUsingDFSRecursive(adj,new HashSet<int> (),source,destination);
        
        
    }

/**
*Method to build adjacency list from the two dimensional array
*pass the edges and its connected vertexes in two dimensional array
**/
    public Dictionary<int, List<int>> BuildAdjacencyList(int[][] edges)
    {
        var adj = new Dictionary<int,List<int>>();
        foreach(var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            if(!adj.ContainsKey(u))
            {
                adj[u] = new List<int>();

            }
            if(!adj.ContainsKey(v))
            {
                adj[v] = new List<int>();
            }

            adj[u].Add(v);
            adj[v].Add(u);
        }

        return adj;

    }

    /**
    *Method to check if there is a path between the source and destination
    *Params : Adjacency list of the graph
    *Params : sourcce vertex of the graph to start traversing
    *Params : destination vertex of the graph to end the traversing
    *
    **/
    public bool ifPathExistsUsingBFS(Dictionary<int, List<int>> adj, int source, int destination)
    {
        //Traverse the graph in BFS
        //Visited Array , to avoid the infinite loop between the vertex
        //Queue to store the edges of the vertex
        //Loop on the queue until the queue is not empty or we reach the destination node

        //Create a Hashset to store the visited nodes so that we will not revist those nodes
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();

        
        queue.Enqueue(source);

        //Loop on the queue to traverse the graph
        while(queue.Count!=0)
        {
            int u = queue.Dequeue();
            visited.Add(u);
            //find out all the edges of the node
            if(u == destination)
            {
                return true;
            }
            
            foreach(int edges in adj[u])
            {
                if(!visited.Contains(edges))
                {
                    queue.Enqueue(edges);
                    visited.Add(edges);
                }
            }
        }
        return false;
    }
    public bool ifPathExistsUsingDFS(Dictionary<int,List<int>> adj,int source,int destination)
    {
        HashSet<int> visited = new HashSet<int>() {source};
        Stack<int> stack = new Stack<int>();

        stack.Push(source);
        while(stack.Count !=0)
        {
            int u = stack.Pop();
            if(u == destination)
            {
                return true;
            }

            foreach(int edge in adj[u])
            {
                if(!visited.Contains(edge))
                {
                    stack.Push(edge);
                    visited.Add(edge);
                }
            }
        }
        return false;

    }

    public bool ifPathExistsUsingDFSRecursive(Dictionary<int,List<int>> adj, HashSet<int> visited, int source,int destination)
    {
        if(source == destination)
        {
            return true;
        }
        if(!visited.Contains(source))
        {
        visited.Add(source);

        foreach(int edge in adj[source])
        {
            if(ifPathExistsUsingDFSRecursive(adj,visited,edge,destination))
            {
                return true;
            }
        }
        }
        return false;
    }

}
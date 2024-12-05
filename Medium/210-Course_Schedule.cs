/*
Time complexity:O(V + E), the Time Complexity of this method is the same as the time complexity of DFS traversal which is O(V+E).
Space complexity:O(V). The extra space of V is needed for the stack, recursionstack and visited array

*/

public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int,List<int>> adjList = BuildAdjacencyList(prerequisites,numCourses);
        return TopologicalSort(numCourses,adjList);

    }

    public int[] TopologicalSort(int numCourses, Dictionary<int,List<int>> adjList)
    {
        int[] orderOfCourses = new int[numCourses];
        //Create a Stack to store the order
        Stack<int> stack = new Stack<int>();
        //Create a visited array
        bool[] visited = new bool[numCourses];
        //Create a recursion stack to verify if the path has been visited or not
        bool[] recStack = new bool[numCourses];
        bool isCyclic = false;
   
       //Call the recursive helper function to detect cycle in the graph
        for(int i = 0;i<numCourses;i++)
        {
            if(!visited[i] && DFSSort(i,adjList,visited,stack,recStack))
            { 
                isCyclic = true;
            }
           
        }
       
       // If there isnt a cycle then return the sorted list
        if(!isCyclic)
        {
            int lengthOfStack = stack.Count;
            for(int i =0;i<lengthOfStack;i++)
            {
            orderOfCourses[i] = stack.Pop();
            }
            return orderOfCourses;
        } 
        
        return new int[]{};
     

    }
    
    public bool DFSSort(int vertex,Dictionary<int,List<int>> adjList, bool[] visited, Stack<int> stack,bool[] recStack)
    {
       if (!visited[vertex]) 
       {
        visited[vertex] = true;
        recStack[vertex]= true;
        //find all the adjacent edges
        foreach(int edge in adjList[vertex])
        {
           //if its already visited then do not need to traverse  
            if(!visited[edge] && DFSSort(edge,adjList,visited,stack,recStack))
            {
                 return true;
            } 
            else if(recStack[edge])
            {
                //There is a cycle
                return true;
            }
        }
       }
    
        //Set the recStack false when we are going back to the
        // Remove the vertex from recursion stack
        recStack[vertex] = false;
        //Push it in stack
        stack.Push(vertex);
        return false;
       
    }

    public Dictionary<int,List<int>> BuildAdjacencyList(int[][] prerequisites, int vertices)
    {
        Dictionary<int,List<int>> adjList = new Dictionary<int,List<int>>();
            for(int i=0;i<vertices;i++)
            {
                adjList[i] = new List<int>();
            }

            foreach(int[] edge in prerequisites)
            {
                //edge from v to u
            int u = edge[0];    
            int v = edge[1];
            adjList[v].Add(u);
            
            }
        return adjList;


    }

}
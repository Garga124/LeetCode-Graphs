/*
Time Complexity O(M+N)
Space Complexity O(N)
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if(node == null)
            return null;
        Dictionary<int,Node> map = new Dictionary<int,Node>();
        return CloneGraph(node, map);
        
    }
    public Node CloneGraph(Node node, Dictionary<int, Node> map){
        if(map.ContainsKey(node.val)){
            return map[node.val];
        }
        Node copy = new Node(node.val);
        map.Add(node.val,copy);
        foreach(Node neighbour in node.neighbors){
            copy.neighbors.Add(CloneGraph(neighbour,map));
        }
        return copy;
    }
    
}
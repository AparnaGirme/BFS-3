/*
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
    // TC => O(V+E)
    // SC => O(V)
    Dictionary<Node, Node> lookup = new Dictionary<Node, Node>();
    public Node CloneGraph(Node node) {
        if(node == null){
            return node;
        }
        dfs(node);
        return lookup[node];
    }

    public void dfs(Node node){
        //base
        if(lookup.ContainsKey(node)){
            return;
        }
        //logic
        var copiedNode = Clone(node);
        List<Node> neighbors = new List<Node>();
        foreach(var n in node.neighbors){
            dfs(n);
            lookup[node].neighbors.Add(lookup[n]);
        }
    }
    public Node Clone(Node node){
        if(lookup.ContainsKey(node)){
            return lookup[node];
        }

        var newNode = new Node(node.val);
        lookup.Add(node, newNode);
        return newNode;
    }
}
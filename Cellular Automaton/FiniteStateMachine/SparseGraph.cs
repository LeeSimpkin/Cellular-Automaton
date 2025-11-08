using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class SparseGraph<TNode, TEdge>
    {
        private readonly Dictionary<TNode, List<(TEdge edge, TNode target)>> adjacency = new();
        public void AddNode(TNode node)
        {
            if (!adjacency.ContainsKey(node))
            {
                adjacency[node] = new List<(TEdge, TNode)>();
            }
        }
        public void AddEdge(TNode from, TEdge edge, TNode to)
        {
            AddNode(from);
            AddNode(to);
            adjacency[from].Add((edge, to));
        }
        public IEnumerable<(TEdge edge, TNode target)> GetEdges(TNode node)
        {
            if (adjacency.TryGetValue(node, out var edges))
            {
                return edges;
            }
            return Enumerable.Empty<(TEdge, TNode)>();

        }
    }
}

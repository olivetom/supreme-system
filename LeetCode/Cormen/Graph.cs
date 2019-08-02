using System;
using System.Collections.Generic;

namespace LeetCode.Cormen
{
	enum Colors : int { White, Gray, Black };

    public class Graph<T> where T:  IComparable
    {

        Dictionary<T, List<T>> AdjacencyList { get; } = new Dictionary<T, List<T>>();
        int Count { get => AdjacencyList.Count; }

		public Graph()
        {
        }

		internal Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
		{
			foreach (var vertex in vertices)
				AddVertex(vertex);

			foreach (var edge in edges)
				AddEdge(edge);
		}


		internal void AddVertex(T vertex)
		{
			AdjacencyList[vertex] = new List<T>();
		}

        internal void AddEdge(Tuple<T, T> edge)
		{
			if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
			{  //undirected graph
				AdjacencyList[edge.Item1].Add(edge.Item2);
				AdjacencyList[edge.Item2].Add(edge.Item1);
			}
		}

        internal List<T> BreadthFirstSearch(T source, Action<T> preVisitAction = null)
        {
            if (!AdjacencyList.ContainsKey(source)) return null;

            var visited = new List<T>();

            var Q = new Queue<T>();

            Q.Enqueue(source);

            while (Q.Count > 0)
            {
                var vertex = Q.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                AdjacencyList.TryGetValue(vertex, out List<T> lv);

                preVisitAction?.Invoke(vertex);

                visited.Add(vertex);

                lv.ForEach(neighbor =>
                {
                    if (!visited.Contains(neighbor))
                    {
                        //neighbor.color = Colors.Gray;
                        //neighbor.distance = vertex.distance + 1;
                        //neighbor.Predecesor = vertex;
                        Q.Enqueue(neighbor);

                    }
                });
			}
			return visited;
		}

        internal List<T> DepthFirstSearch(T source, Action<T> visitAction = null)
        {
            if (!AdjacencyList.ContainsKey(source)) return null;

			var visited = new List<T>();

            var S = new Stack<T>();

            S.Push(source);

            while (S.Count > 0)
            {
                var vertex = S.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                var lv = AdjacencyList[vertex];

				lv.ForEach(neighbor =>
				{
					if (!visited.Contains(neighbor))
                        S.Push(neighbor);
				});
            }
			return visited;
		}

		public Func<T, IEnumerable<T>> ShortestPathFunction(T start)
		{ //BFS plus a dictionary for predecesor of 
			var previous = new Dictionary<T, T>();

			var queue = new Queue<T>();
			queue.Enqueue(start);

			while (queue.Count > 0)
			{
				var vertex = queue.Dequeue();
				foreach (var neighbor in AdjacencyList[vertex])
				{
					if (previous.ContainsKey(neighbor))
						continue;

					previous[neighbor] = vertex;
					queue.Enqueue(neighbor);
				}
			}

			Func<T, IEnumerable<T>> shortestPath = v =>
			{
				var path = new List<T> { };

				var current = v;
				while (!current.Equals(start))
				{
					path.Add(current);
					current = previous[current];
				};

				path.Add(start);
				path.Reverse();

				return path;
			};

			return shortestPath;
		}




        public static void Program()
        {

            var vertices = new[] { 1, 2, 3,	4, 5, 6, 7, 8, 9, 10 };
			//var edges = new[] {
				//Tuple.Create(1,2),
				//Tuple.Create(1,5),

				////Tuple.Create(2,1),
				//Tuple.Create(2,5),
				//Tuple.Create(2,3),
				//Tuple.Create(2,4),

				////Tuple.Create(3,2),
				//Tuple.Create(3,4),

				////Tuple.Create(4,2),
				//Tuple.Create(4,5),
				////Tuple.Create(4,3),

				////Tuple.Create(5,4),
				////Tuple.Create(5,1),
				////Tuple.Create(5,2)
                //};

			var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
				Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
				Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10), Tuple.Create(8,10)};

			var  G = new Graph<int>(vertices, edges);

			Console.WriteLine("BFS:");

			G.BreadthFirstSearch(1).ForEach(i => Console.Write("{0},", i));
			Console.WriteLine();

            var path = new List<int>();
            G.BreadthFirstSearch(1, v => path.Add(v)).ForEach(i => Console.Write("{0},", i));
            Console.WriteLine();
            path.ForEach(i => Console.Write("{0},", i));

            Console.WriteLine();

            Console.WriteLine("DFS:");
            G.DepthFirstSearch(1).ForEach(v => Console.Write("{0},", v));



			var startVertex = 1;
			var shortestPath = G.ShortestPathFunction(startVertex);
			foreach (var vertex in vertices)
				Console.WriteLine("shortest path to {0,2}: {1}",
						vertex, string.Join(", ", shortestPath(vertex)));

		}



    }



    internal class GraphNode<T> where T : IComparable

		{
        internal readonly T Value;
		internal Colors color { get; set; } //color
		internal int distance;
        internal GraphNode<T> Predecesor { get; set; } //for BFS


		internal GraphNode(T value)
		{
			Value = value;
			color = Colors.White;
            distance = int.MaxValue;
		}

        public static bool operator ==(GraphNode<T> left, GraphNode<T> right)
        {
            return left.Equals(right);
        }

		public static bool operator !=(GraphNode<T> left, GraphNode<T> right)
		{
			return !left.Equals(right);
		}

        public override bool Equals(Object obj)
        {
            GraphNode<T> b = obj as GraphNode<T>;
            return !Object.ReferenceEquals(null, obj) && Value.Equals(b.Value);
        }

		public override int GetHashCode()
		{
            return Value.GetHashCode();
		}

  //      public static bool operator ==(GraphNode<T> a, GraphNode<T> b)
		//{
		//	Console.WriteLine("Overloaded == called");
  //          return a.Equals(b);
		//}

	}
}

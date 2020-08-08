using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Structures {
	/// <summary>
	/// Defines the structure for the clock
	/// </summary>
	public class ClockList {
		class Node {
			string _Page;
			bool _R;
			Node _Next;
			public Node() => this._R = true;
		}
		private Node[] _Nodes;
		public ClockList(int pageCount) {
			this._Nodes = new Node[pageCount];
			for (var i = 0; i < pageCount; i++) {
				this._Nodes[i] = new Node();
			}
		}
	}
}

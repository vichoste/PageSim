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
			public string Page { get; set;  }
			public bool IsClean { get; set; }
			public Node Next;
			public Node() => this.IsClean = true;
		}
		private readonly Node[] _Nodes;
		public ClockList(int pageCount) {
			this._Nodes = new Node[pageCount];
			this._Nodes[0] = new Node();
			for (var i = 0; i < pageCount - 1; i++) {
				this._Nodes[i + 1] = new Node();
				this._Nodes[i].Next = this._Nodes[i + 1];
			}
			this._Nodes[pageCount - 1].Next = this._Nodes[0];
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Structures {
	/// <summary>
	/// Defines the structure for the clock.
	/// </summary>
	public class ClockList {
		class Node {
			public string Page { get; set;  }
			public bool IsClean { get; set; }
			public Node() => this.IsClean = true;
		}
		private int _CurrentNode;
		private readonly Node[] _Nodes;
		public ClockList(int pageCount) {
			this._CurrentNode = 0;
			this._Nodes = new Node[pageCount];
			for (var i = 0; i < pageCount; i++) {
				this._Nodes[i] = new Node();
			}
		}
		public void InsertPage(string page) {
			this._Nodes[this._CurrentNode].Page = page;
			this._Nodes[this._CurrentNode].IsClean = true;
			this._CurrentNode = this._CurrentNode == this._Nodes.Length - 1 ? 0 : this._CurrentNode += 1;
		}
		public void ReplacePage(string newPage) {
			while (this._Nodes[this._CurrentNode].IsClean) {
				this._Nodes[this._CurrentNode].IsClean = false;
				this._CurrentNode = this._CurrentNode == this._Nodes.Length - 1 ? 0 : this._CurrentNode += 1;
			}
			this._Nodes[this._CurrentNode].Page = newPage;
		}
	}
}

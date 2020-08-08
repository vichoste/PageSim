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
		/// <summary>
		/// Defines a node inside the list.
		/// </summary>
		class Node {
			/// <summary>
			/// Current page value.
			/// </summary>
			public string Page { get; set;  }
			/// <summary>
			/// Is a clean page.
			/// </summary>
			public bool IsClean { get; set; }
			/// <summary>
			/// Creates a new node.
			/// </summary>
			public Node() => this.IsClean = true;
		}
		/// <summary>
		/// Index pointing to the current node.
		/// </summary>
		private int _CurrentNode;
		/// <summary>
		/// Array of nodes.
		/// </summary>
		private readonly Node[] _Nodes;
		/// <summary>
		/// Creates a circular list of pages.
		/// </summary>
		/// <param name="pageCount">List size</param>
		public ClockList(int pageCount) {
			this._CurrentNode = 0;
			this._Nodes = new Node[pageCount];
			for (var i = 0; i < pageCount; i++) {
				this._Nodes[i] = new Node();
			}
		}
		/// <summary>
		/// Inserts a new page. Use only when the virtual memory is not full.
		/// </summary>
		/// <param name="page">Page to insert</param>
		public void InsertPage(string page) {
			this._Nodes[this._CurrentNode].Page = page;
			this._Nodes[this._CurrentNode].IsClean = true;
			this._CurrentNode = this._CurrentNode == this._Nodes.Length - 1 ? 0 : this._CurrentNode += 1;
			Console.WriteLine($"Current node: {this._CurrentNode}");
		}
		/// <summary>
		/// Replaces a page. Use only when the virtual memory is full.
		/// </summary>
		/// <param name="newPage">New page to insert in the current list position</param>
		/// <returns>Old page value</returns>
		public string ReplacePage(string newPage) {
			while (this._Nodes[this._CurrentNode].IsClean) {
				this._Nodes[this._CurrentNode].IsClean = false;
				this._CurrentNode = this._CurrentNode == this._Nodes.Length - 1 ? 0 : this._CurrentNode += 1;
			}
			var pageToReplace = this._Nodes[this._CurrentNode].Page;
			this._Nodes[this._CurrentNode].Page = newPage;
			this._Nodes[this._CurrentNode].IsClean = true;
			return pageToReplace;
		}
	}
}

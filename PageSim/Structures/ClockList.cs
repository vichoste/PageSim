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
		private class Node {
			private string _Page;
			private bool _R;
			public Node(string page) {
				this._Page = page;
				this._R = true;
			}
		}
		public ClockList(int pageCount) {

		}
	}
}

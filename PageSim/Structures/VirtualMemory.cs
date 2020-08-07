using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Structures {
	public class VirtualMemory {
		private int[] _Pages;
		private int _Capacity;
		public VirtualMemory(int pageAmount, int capacity) {
			this._Pages = new int[pageAmount];
			this._Capacity = capacity;
		}

	}
}

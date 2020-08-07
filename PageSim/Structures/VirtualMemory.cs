using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Structures {
	/// <summary>
	/// Represents the virtual memory
	/// </summary>
	public class VirtualMemory {
		// Pages inside the virtual memory
		private int[] _Pages;
		// Total capacity of the virtual memory
		private int _Capacity;
		/// <summary>
		/// Creates a new instance of a virtual memory
		/// </summary>
		/// <param name="pageAmount">Sets the amount of pages</param>
		/// <param name="capacity">Sets the total capacity</param>
		public VirtualMemory(int pageAmount, int capacity) {
			// Init
			this._Pages = new int[pageAmount];
			this._Capacity = capacity;
			// Populate the pages with "null" references
			for (var i = 0; i < this._Pages.Length; i++) {
				this._Pages[i] = 0;
			}
		}
		public int this[int i] {
			get => this._Pages[i];
			set => this._Pages[i] = value;
		}
		public int GetCurrentFreeCapacity() {
			var usedMemory = 0;
			foreach (var p in this._Pages) {
				if (p != 0) {
					usedMemory += 4;
				}
			}
			return this._Capacity - usedMemory;
		}
	}
}

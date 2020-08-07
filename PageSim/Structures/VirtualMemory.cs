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
		private int[] _PageReferences;
		// Total capacity of the virtual memory
		private readonly int _Capacity;
		/// <summary>
		/// Creates a new instance of a virtual memory
		/// </summary>
		/// <param name="capacity">Sets the total capacity</param>
		public VirtualMemory(int capacity) {
			// Init
			this._PageReferences = new int[capacity / 4];
			this._Capacity = capacity;
			// Populate the references with "null" references
			for (var i = 0; i < this._PageReferences.Length; i++) {
				this._PageReferences[i] = -1;
			}
		}
		public int this[int i] {
			get => this._PageReferences[i];
			set => this._PageReferences[i] = value;
		}
		public int GetCurrentFreeCapacity() {
			var usedMemory = 0;
			foreach (var p in this._PageReferences) {
				if (p != -1) {
					usedMemory += 4;
				}
			}
			return this._Capacity - usedMemory;
		}
	}
}

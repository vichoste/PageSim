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
		/// <summary>
		/// Pages inside the virtual memory
		/// </summary>
		private int[] _PageReferences;
		/// <summary>
		/// Total capacity of the virtual memory
		/// </summary>
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
		/// <summary>
		/// Gets a page inside the virtual memory page references.
		/// </summary>
		/// <param name="i">Index</param>
		/// <returns>Page number</returns>
		public int this[int i] {
			get => this._PageReferences[i];
			set => this._PageReferences[i] = value;
		}
		/// <summary>
		/// Gets the current available capacity of the virtual memory.
		/// </summary>
		/// <returns>Current free space</returns>
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

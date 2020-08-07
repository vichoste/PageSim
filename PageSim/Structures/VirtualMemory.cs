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
		private readonly string[] _PageReferences;
		/// <summary>
		/// Total capacity of the virtual memory
		/// </summary>
		private readonly int _Capacity;
		/// <summary>
		/// Amount of page references inside the virtual memory.
		/// </summary>
		public int Count {
			get => this._PageReferences.Length;
			private set { }
		}
		/// <summary>
		/// Amount of pages.
		/// </summary>
		public int PageCount { get; private set; }
		/// <summary>
		/// Creates a new instance of a virtual memory
		/// </summary>
		/// <param name="capacity">Sets the total capacity</param>
		public VirtualMemory(int capacity, int pageCount) {
			// Init
			this._PageReferences = new string[capacity / 4];
			this._Capacity = capacity;
			this.PageCount = pageCount;
			// Populate the references with "null" references
			for (var i = 0; i < this._PageReferences.Length; i++) {
				this._PageReferences[i] = "null";
			}
		}
		/// <summary>
		/// Gets a page inside the virtual memory page references.
		/// </summary>
		/// <param name="i">Index</param>
		/// <returns>Page number</returns>
		public string this[int i] {
			get => this._PageReferences[i];
			set => this._PageReferences[i] = value;
		}
		/// <summary>
		/// Gets the current available capacity of the virtual memory.
		/// </summary>
		/// <returns>Current free space</returns>
		public int GetCurrentFreeCapacity() {
			var usedMemory = 0;
			foreach (var pr in this._PageReferences) {
				if (string.Compare(pr, "null") != 0) {
					usedMemory += 4;
				}
			}
			return this._Capacity - usedMemory;
		}
		/// <summary>
		/// Finds the index of a page.
		/// </summary>
		/// <param name="page">Page to find</param>
		/// <returns>Index of the found page</returns>
		public int FindPage(string page) => Array.IndexOf(this._PageReferences, page);
	}
}

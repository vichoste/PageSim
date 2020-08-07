using PageSim.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Algorithms {
	public class LeastRecentlyUsed : IAlgorithmStrategy {
		/// <summary>
		/// Executes the algorithm.
		/// </summary>
		/// <param name="virtualMemory">Virtual memory to use</param>
		/// <param name="pageSequence">Page sequence to use</param>
		/// <returns>Amount of misses</returns>
		public int Execute(VirtualMemory virtualMemory, string[] pageSequence) {
			var hashtable = new Hashtable();
			var missCount = 0;
			var i = 0;
			foreach (var page in pageSequence) {
				if (!hashtable.ContainsKey(page)) {
					hashtable.Add(page, 1);
				}
				// While the queue is not full
				if (i < virtualMemory.PageCount) {
					virtualMemory[i++] = page;
					continue;
				}
			}
			return missCount;
		}
	}
}

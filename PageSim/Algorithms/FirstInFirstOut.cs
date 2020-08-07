using PageSim.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Algorithms {
	/// <summary>
	/// Defines the FIFO strategy for page replacement.
	/// </summary>
	public class FirstInFirstOut : IAlgorithmStrategy {
		/// <summary>
		/// Executes the algorithm.
		/// </summary>
		/// <param name="virtualMemory">Virtual memory to use</param>
		/// <param name="pageSequence">Page sequence to use</param>
		/// <returns>Amount of misses</returns>
		public int Execute(VirtualMemory virtualMemory, string[] pageSequence) {
			var missCount = 0;
			var queue = new Queue<string>();
			var i = 0;
			foreach (var page in pageSequence) {
				// If the queue doesn't contain the page, add it
				if (!queue.Contains(page)) {
					queue.Enqueue(page);
				}
				// While the queue is not full
				if (i < virtualMemory.PageCount) {
					virtualMemory[i++] = page;
					continue;
				}
				// While the queue is full
				if (virtualMemory.FindPage(page) == -1) {
					var pageToReplace = queue.Dequeue();
					var indexToReplace = virtualMemory.FindPage(pageToReplace);
					virtualMemory[indexToReplace] = page;
					missCount++;
				}
			}
			return missCount;
		}
	}
}

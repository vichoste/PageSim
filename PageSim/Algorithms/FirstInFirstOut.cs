using PageSim.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Algorithms {
	public class FirstInFirstOut : IAlgorithmStrategy {
		public int Execute(VirtualMemory virtualMemory, string[] pageSequence) {
			var missCount = 0;
			var queue = new Queue<string>();
			var i = 0;
			foreach (var page in pageSequence) {
				if (!queue.Contains(page)) {
					queue.Enqueue(page);
				}
				if (i < virtualMemory.PageCount) {
					virtualMemory[i++] = page;
					continue;
				}
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

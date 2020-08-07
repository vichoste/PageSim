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
			foreach (var ps in pageSequence) {
				queue.Enqueue(ps);
			}
			return missCount;
		}
	}
}

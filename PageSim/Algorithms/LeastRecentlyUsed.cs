using PageSim.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
				foreach (var k in hashtable) {
					Console.WriteLine($"{page} - {hashtable[page]}");
				}
				Console.WriteLine("===");
				// If the page is not added, add it
				if (!hashtable.ContainsKey(page)) {
					hashtable.Add(page, 1);
				} else { // If the page exists, increment its counter
					hashtable[page] = (int)hashtable[page] + 1;
				}
				// While the virtual memory is not full
				if (i < virtualMemory.PageCount) {
					virtualMemory[i++] = page;
					continue;
				}
				// While the virtual memory is full and we have a miss
				if (virtualMemory.FindPage(page) == -1) {
					var pageToReplace = "MinKey";
					var currentMin = int.MaxValue;
					foreach (var k in hashtable.Keys) {
						if ((int)hashtable[k] < currentMin) {
							pageToReplace = k as string;
							currentMin = (int)hashtable[k];
						}
					}
					var indexToReplace = virtualMemory.FindPage(pageToReplace);
					Console.WriteLine(indexToReplace);
					virtualMemory[indexToReplace] = page;
					hashtable.Remove(pageToReplace);
					missCount++;
				}
			}
			return missCount;
		}
	}
}

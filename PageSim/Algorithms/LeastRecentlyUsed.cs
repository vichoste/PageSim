using PageSim.Structures;
using System;
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
		public int Execute(VirtualMemory virtualMemory, string[] pageSequence) => throw new NotImplementedException();
	}
}

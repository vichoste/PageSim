using PageSim.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Algorithms {
	public interface IAlgorithmStrategy {
		void Execute(VirtualMemory virtualMemory, string[] pageSequence);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Algorithms {
	public class AlgorithmContext {
		public IAlgorithmStrategy AlgorithmStrategy { get; set; }
		public AlgorithmContext() {
		}
	}
}

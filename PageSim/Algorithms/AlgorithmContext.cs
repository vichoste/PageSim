using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Algorithms {
	public class AlgorithmContext {
		public IAlgorithmStrategy AlgorithmStrategy { private get; set; }
		public AlgorithmContext() {
		}
		public void Execute() => this.AlgorithmStrategy.Execute();
	}
}

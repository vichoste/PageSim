using PageSim.Structures;

namespace PageSim.Algorithms {
	public class AlgorithmContext {
		/// <summary>
		/// Virtual memory.
		/// </summary>
		private readonly VirtualMemory _VirtualMemory;
		/// <summary>
		/// Page sequence.
		/// </summary>
		private readonly string[] _PageSequence;
		/// <summary>
		/// Sets the current algorithm.
		/// </summary>
		public IAlgorithmStrategy AlgorithmStrategy { private get; set; }
		/// <summary>
		/// Creates a new context for the algorithms.
		/// </summary>
		/// <param name="virtualMemory">Virtual memory to use</param>
		/// <param name="pageSequence">Page sequence to use</param>
		public AlgorithmContext(VirtualMemory virtualMemory, string[] pageSequence) {
			this._VirtualMemory = virtualMemory;
			this._PageSequence = pageSequence;
		}
		/// <summary>
		/// Executes the algorithm.
		/// </summary>
		/// <param name="virtualMemory">Virtual memory to use</param>
		/// <param name="pageSequence">Page sequence to use</param>
		/// <returns>Amount of misses</returns>
		public int Execute() => this.AlgorithmStrategy.Execute(this._VirtualMemory, this._PageSequence);
	}
}

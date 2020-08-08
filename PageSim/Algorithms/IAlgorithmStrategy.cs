using PageSim.Structures;

namespace PageSim.Algorithms {
	/// <summary>
	/// Defines what object is an algorithm strategy.
	/// </summary>
	public interface IAlgorithmStrategy {
		/// <summary>
		/// Executes the algorithm.
		/// </summary>
		/// <param name="virtualMemory">Virtual memory to use</param>
		/// <param name="pageSequence">Page sequence to use</param>
		/// <returns>Amount of misses</returns>
		int Execute(VirtualMemory virtualMemory, string[] pageSequence);
	}
}

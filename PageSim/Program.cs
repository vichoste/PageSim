using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageSim.Arguments;

namespace PageSim {
	class Program {
		/// <summary>
		/// Starts the program.
		/// </summary>
		/// <param name="options">Input parameters</param>
		static void RunOptions(Options options) {
			var algorithm = options.Algorithm;
			var pageSequenceFile = options.PageSequenceFile;
			var pageCount = options.PageCount;
			var virtualMemoryAmount = options.VirtualMemoryAmount;
		}
		/// <summary>
		/// Main function.
		/// </summary>
		/// <param name="args">Input arguments</param>
		static void Main(string[] args) => _ = Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions);
	}
}

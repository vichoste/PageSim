using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageSim.Arguments;

namespace PageSim {
	class Program {
		static bool CheckOptions(Options options) {

			return true;
		}
		/// <summary>
		/// Starts the program.
		/// </summary>
		/// <param name="options">Input parameters</param>
		static void RunOptions(Options options) {
			if (CheckOptions(options)) {

			}
		}
		/// <summary>
		/// Main function.
		/// </summary>
		/// <param name="args">Input arguments</param>
		static void Main(string[] args) => _ = Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions);
	}
}

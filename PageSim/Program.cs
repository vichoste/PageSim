using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageSim.Arguments;
using PageSim.Structures;
using System.IO;
using PageSim.Algorithms;

namespace PageSim {
	class Program {
		/// <summary>
		/// Checks the correctness of the options.
		/// </summary>
		/// <param name="options">Input parameters</param>
		/// <returns>True if everything is fine</returns>
		static bool CheckOptions(Options options) {
			string[] validAlgorithms = { "FIFO" , "LRU", "CLK", "ALL" };
			// Check if the user specified a valid algorithm
			if (!validAlgorithms.Contains(options.Algorithm)) {
				Console.WriteLine("(!) El algoritmo debe ser FIFO, LRU, CLK o ALL (!)");
				return false;
			}
			// Check if the file is a *.txt
			if (string.Compare(options.PageSequenceFile.Split('.')[1], "txt") != 0) {
				Console.WriteLine("(!) El archivo debe ser un *.txt (!)");
				return false;
			}
			// Check if the memory amount is a multiple of 4
			if (options.VirtualMemoryCapacity % 4 != 0) {
				Console.WriteLine("(!) La cantidad de memoria no es múltiplo de 4 (!)");
				return false;
			}
			return true;
		}
		/// <summary>
		/// Runs an individual algorithm.
		/// </summary>
		/// <param name="algorithmContext">Algorithm context</param>
		/// <param name="algorithmStrategy">Algorithm to run</param>
		static void RunIndividualAlgorithm(AlgorithmContext algorithmContext, IAlgorithmStrategy algorithmStrategy) {
			algorithmContext.AlgorithmStrategy = algorithmStrategy;
			var missCount = algorithmContext.Execute();
			Console.WriteLine(missCount);
		}
		/// <summary>
		/// Starts the program.
		/// </summary>
		/// <param name="options">Input parameters</param>
		static void RunOptions(Options options) {
			if (CheckOptions(options)) {
				var virtualMemory = new VirtualMemory(options.VirtualMemoryCapacity, options.PageCount);
				var pageSequence = File.ReadAllLines(options.PageSequenceFile);
				var algorithmContext = new AlgorithmContext(virtualMemory, pageSequence);
				switch (options.Algorithm) {
					case "FIFO":
						RunIndividualAlgorithm(algorithmContext, new FirstInFirstOut());
						break;
					case "LRU":
						RunIndividualAlgorithm(algorithmContext, new LeastRecentlyUsed());
						break;
					case "CLK":
						RunIndividualAlgorithm(algorithmContext, new Clock());
						break;
					case "ALL":
						break;
				}
			}
		}
		/// <summary>
		/// Main function.
		/// </summary>
		/// <param name="args">Input arguments</param>
		static void Main(string[] args) => _ = Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions);
	}
}

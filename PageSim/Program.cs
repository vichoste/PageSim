using CommandLine;
using PageSim.Algorithms;
using PageSim.Arguments;
using PageSim.Structures;
using System;
using System.IO;
using System.Linq;

namespace PageSim {
	class Program {
		/// <summary>
		/// Checks the correctness of the options.
		/// </summary>
		/// <param name="options">Input parameters</param>
		/// <returns>True if everything is fine</returns>
		static bool CheckOptions(Options options) {
			string[] validAlgorithms = { "FIFO", "LRU", "CLK", "ALL" };
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
			// Check the page count memory exceeds the virtual memory capacity
			if (options.PageCount * 4 > options.VirtualMemoryCapacity) {
				Console.WriteLine("(!) La cantidad de referencias a páginas excede a la memoria virtual disponible (!)");
				return false;
			}
			return true;
		}
		/// <summary>
		/// Runs an individual algorithm.
		/// </summary>
		/// <param name="algorithmContext">Algorithm context</param>
		/// <param name="algorithmStrategy">Algorithm to run</param>
		static int RunIndividualAlgorithm(AlgorithmContext algorithmContext, IAlgorithmStrategy algorithmStrategy) {
			algorithmContext.AlgorithmStrategy = algorithmStrategy;
			var missCount = algorithmContext.Execute();
			return missCount;
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
						var missCount = RunIndividualAlgorithm(algorithmContext, new FirstInFirstOut());
						Console.WriteLine($"Cantidad de misses FIFO: {missCount}");
						break;
					case "LRU":
						missCount = RunIndividualAlgorithm(algorithmContext, new LeastRecentlyUsed());
						Console.WriteLine($"Cantidad de misses LRU: {missCount}");
						break;
					case "CLK":
						missCount = RunIndividualAlgorithm(algorithmContext, new Clock());
						Console.WriteLine($"Cantidad de misses CLK: {missCount}");
						break;
					case "ALL":
						var currentMin = int.MaxValue;
						var currentMinAlgorithm = "Ninguno";
						// Execute FIFO
						var missCountFIFO = RunIndividualAlgorithm(algorithmContext, new FirstInFirstOut());
						if (missCountFIFO < currentMin) {
							currentMin = missCountFIFO;
							currentMinAlgorithm = "FIFO";
						}
						// Execute LRU
						var virtualMemory2 = new VirtualMemory(options.VirtualMemoryCapacity, options.PageCount);
						algorithmContext.VirtualMemory = virtualMemory2;
						var missCountLRU = RunIndividualAlgorithm(algorithmContext, new LeastRecentlyUsed());
						if (missCountLRU < currentMin) {
							currentMin = missCountLRU;
							currentMinAlgorithm = "LRU";
						}
						// Execute CLK
						var virtualMemory3 = new VirtualMemory(options.VirtualMemoryCapacity, options.PageCount);
						algorithmContext.VirtualMemory = virtualMemory3;
						var missCountCLK = RunIndividualAlgorithm(algorithmContext, new Clock());
						if (missCountCLK < currentMin) {
							currentMin = missCountCLK;
							currentMinAlgorithm = "CLK";
						}
						// Print results
						Console.WriteLine($"Cantidad de misses FIFO: {missCountFIFO}");
						Console.WriteLine($"Cantidad de misses LRU: {missCountLRU}");
						Console.WriteLine($"Cantidad de misses CLK: {missCountCLK}");
						Console.WriteLine($"{currentMinAlgorithm} es el que tiene menos misses.");
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

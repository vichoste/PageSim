using PageSim.Structures;
using System;
using System.Collections.Generic;

namespace PageSim.Algorithms {
	/// <summary>
	/// Defines the FIFO strategy for page replacement.
	/// </summary>
	public class FirstInFirstOut : IAlgorithmStrategy {
		/// <summary>
		/// Executes the algorithm.
		/// </summary>
		/// <param name="virtualMemory">Virtual memory to use</param>
		/// <param name="pageSequence">Page sequence to use</param>
		/// <returns>Amount of misses</returns>
		public int Execute(VirtualMemory virtualMemory, string[] pageSequence) {
			var missCount = 0;
			var i = 0;
			var queue = new Queue<string>();
			foreach (var page in pageSequence) {
				Console.WriteLine("==========================================================");
				Console.WriteLine($"FIFO Solicitud del procesador para ingresar página {page}");
				Console.WriteLine($"Memoria disponible: {virtualMemory.GetCurrentFreeCapacity()} [KB]");
				// If the queue doesn't contain the page, add it
				if (!queue.Contains(page)) {
					queue.Enqueue(page);
					Console.WriteLine($"Página {page} agregada a la cola");
				}
				// While the virtual memory is not full
				if (i < virtualMemory.PageCount) {
					virtualMemory[i++] = page;
					Console.WriteLine($"Página {page} agregada a la memoria virtual en la posición {i}");
					continue;
				}
				// While the virtual memory is full and we have a miss
				if (virtualMemory.FindPage(page) == -1) {
					Console.WriteLine("(i) Miss (i)");
					var pageToReplace = queue.Dequeue();
					Console.WriteLine($"Página a reemplazar: {pageToReplace}");
					var indexToReplace = virtualMemory.FindPage(pageToReplace);
					Console.WriteLine($"Posición a reemplazar dentro de la memoria virtual: {indexToReplace}");
					virtualMemory[indexToReplace] = page;
					missCount++;
				} else {
					Console.WriteLine("(i) Hit (i)");
				}
			}
			return missCount;
		}
	}
}

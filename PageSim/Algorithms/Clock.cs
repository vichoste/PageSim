using PageSim.Structures;
using System;

namespace PageSim.Algorithms {
	/// <summary>
	/// Defines the CLK strategy for page replacement.
	/// </summary>
	public class Clock : IAlgorithmStrategy {
		/// <summary>
		/// Executes the algorithm.
		/// </summary>
		/// <param name="virtualMemory">Virtual memory to use</param>
		/// <param name="pageSequence">Page sequence to use</param>
		/// <returns>Amount of misses</returns>
		public int Execute(VirtualMemory virtualMemory, string[] pageSequence) {
			var missCount = 0;
			var i = 0;
			var clockList = new ClockList(virtualMemory.PageCount);
			foreach (var page in pageSequence) {
				Console.WriteLine("==========================================================");
				Console.WriteLine($"CLK Solicitud del procesador para ingresar página {page}");
				Console.WriteLine($"Memoria disponible: {virtualMemory.GetCurrentFreeCapacity()} [KB]");
				// While the virtual memory is not full
				if (i < virtualMemory.PageCount) {
					virtualMemory[i++] = page;
					Console.WriteLine($"Página {page} agregada a la memoria virtual en la posición {i}");
					clockList.InsertPage(page);
					Console.WriteLine($"Página {page} insertada en la lista circular");
					continue;
				}
				// While the virtual memory is full and we have a miss
				if (virtualMemory.FindPage(page) == -1) {
					Console.WriteLine("(i) Miss (i)");
					var pageToReplace = clockList.ReplacePage(page);
					Console.WriteLine($"Página {pageToReplace} reemplazada por {page} en la lista circular");
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

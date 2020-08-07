using PageSim.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Algorithms {
	public class LeastRecentlyUsed : IAlgorithmStrategy {
		/// <summary>
		/// Executes the algorithm.
		/// </summary>
		/// <param name="virtualMemory">Virtual memory to use</param>
		/// <param name="pageSequence">Page sequence to use</param>
		/// <returns>Amount of misses</returns>
		public int Execute(VirtualMemory virtualMemory, string[] pageSequence) {
			var hashtable = new Hashtable();
			var missCount = 0;
			var i = 0;
			foreach (var page in pageSequence) {
				Console.WriteLine("==========================================================");
				Console.WriteLine($"LRU Solicitud del procesador para ingresar página {page}");
				Console.WriteLine($"Memoria disponible: {virtualMemory.GetCurrentFreeCapacity()} [KB]");
				// While the virtual memory is not full
				if (i < virtualMemory.PageCount) {
					// If the page is not added, add it
					if (!hashtable.ContainsKey(page)) {
						hashtable.Add(page, 1);
						Console.WriteLine($"Página {page} agregada a la hashtable");
					} else { // If the page exists, increment its counter
						hashtable[page] = (int)hashtable[page] + 1;
						Console.WriteLine($"Página {page} ya existente en la hashtable. Cantidad: {hashtable[page]}");
					}
					virtualMemory[i++] = page;
					Console.WriteLine($"Página {page} agregada a la memoria virtual en la posición {i}");
					continue;
				}
				// While the virtual memory is full and we have a miss
				if (virtualMemory.FindPage(page) == -1) {
					Console.WriteLine("(i) Miss (i)");
					var pageToReplace = "MinKey";
					var currentMin = int.MaxValue;
					foreach (var k in hashtable.Keys) {
						if ((int)hashtable[k] < currentMin) {
							pageToReplace = k as string;
							currentMin = (int)hashtable[k];
						}
					}
					Console.WriteLine($"Página a reemplazar: {pageToReplace}");
					var indexToReplace = virtualMemory.FindPage(pageToReplace);
					Console.WriteLine($"Posición a reemplazar dentro de la memoria virtual: {indexToReplace}");
					virtualMemory[indexToReplace] = page;
					hashtable.Remove(pageToReplace);
					Console.WriteLine($"Página {pageToReplace} eliminada de la hashtable");
					hashtable.Add(page, 1);
					Console.WriteLine($"Página {page} agregada a la hashtable");
					missCount++;
				} else {
					Console.WriteLine("(i) Hit (i)");
				}
			}
			return missCount;
		}
	}
}

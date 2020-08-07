using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim.Arguments {
	/// <summary>
	/// Establish the parameters required for the program.
	/// </summary>
	class Options {
		[Option('a', Required = true, HelpText = "Algoritmo a utilizar. FIFO, LRU o CLK")]
		public string Algorithm { get; set; }
		[Option('f', Required = true, HelpText = "Archivo que contiene la secuencia de páginas")]
		public string PageSequenceFile { get; set; }
		[Value(1, Required = true, MetaName = "Cantidad de páginas", HelpText = "Establece la cantidad de páginas que contendrá la memoria virtual")]
		public byte PageCount { get; set; }
		[Value(2, Required = true, MetaName = "Espacio de memoria virtual disponible [kb]", HelpText = "Establece la cantidad de espacio de memoria virtual en kilobytes")]
		public int VirtualMemoryAmount { get; set; }
	}
}

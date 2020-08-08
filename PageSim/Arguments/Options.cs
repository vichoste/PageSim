using CommandLine;

namespace PageSim.Arguments {
	/// <summary>
	/// Establish the parameters required for the program.
	/// </summary>
	class Options {
		/// <summary>
		/// Selected algorithm.
		/// </summary>
		[Option('a', Required = true, HelpText = "Algoritmo a utilizar. FIFO, LRU, CLK o ALL")]
		public string Algorithm { get; set; }
		/// <summary>
		/// File containing the page sequence.
		/// </summary>
		[Option('f', Required = true, HelpText = "Archivo *.txt que contiene la secuencia de páginas")]
		public string PageSequenceFile { get; set; }
		/// <summary>
		/// Amount of pages.
		/// </summary>
		[Value(1, Required = true, MetaName = "Cantidad de referencia de páginas", HelpText = "Establece la cantidad de referencias de páginas que contendrá la memoria virtual")]
		public int PageCount { get; set; }
		/// <summary>
		/// Amount of memory inside of the virtual memory.
		/// </summary>
		[Value(2, Required = true, MetaName = "Espacio de memoria virtual disponible [KB]", HelpText = "Establece la cantidad de espacio de memoria virtual en kilobytes")]
		public int VirtualMemoryCapacity { get; set; }
	}
}

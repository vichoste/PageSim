using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSim {
	class Program {
		class Options {
			[Option('f', Required = true, HelpText = "Archivo que contiene la secuencia de páginas")]
			public string PageSequence { get; set; }
			[Value(1, Required = true, MetaName = "Cantidad de páginas", HelpText = "Establece la cantidad de páginas que contendrá la memoria virtual")]
			public byte PageCount { get; set; } 
			[Value(2, Required = true, MetaName = "Espacio de memoria virtual disponible [kb]", HelpText = "Establece la cantidad de espacio de memoria virtual en kilobytes")]
			public int VirtualMemoryAmount { get; set; }
		}
		/// <summary>
		/// Starts the program.
		/// </summary>
		/// <param name="options">Input parameters</param>
		static void RunOptions(Options options) {

		}
		/// <summary>
		/// Main function.
		/// </summary>
		/// <param name="args">Input arguments</param>
		static void Main(string[] args) => _ = Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions);
	}
}

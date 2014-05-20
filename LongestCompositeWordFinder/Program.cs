using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LongestCompositeWordFinderLibrary;

namespace LongestCompositeWordFinder {
	class Program {
		// Constants
		private static readonly string fileName = "wordsforproblem.txt";
		
		static void Main(string[] args) {
			CompositeWordFinder f = new CompositeWordFinder(fileName);
			IEnumerable<CompositeWord> compositeWords = f.GetOrderedCompositeWords();

			// Spit out the results
			IEnumerable<CompositeWord> longestCompositeWords = compositeWords.Take(2);
			Console.WriteLine("Longest composite word: {0}", longestCompositeWords.First());
			Console.WriteLine("Second longest composite word: {0}", longestCompositeWords.Last());
			Console.WriteLine("Total number of composite words: {0}", compositeWords.Count());

			Console.ReadKey();
		}
	}
}

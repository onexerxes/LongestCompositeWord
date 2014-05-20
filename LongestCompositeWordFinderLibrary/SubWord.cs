using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCompositeWordFinderLibrary {
	public class SubWord {
		// Private members
		private string Word;
		
		// Public properties
		public int Length { get { return Word.Length; } }
		public int CompositeWordLocationIndex { get; private set; }

		// Constructors
		public SubWord(string word, int index) {
			Word = word;
			CompositeWordLocationIndex = index;
		}
		
		// Public methods
		public override string ToString() {
			return Word;
		}
	}
}

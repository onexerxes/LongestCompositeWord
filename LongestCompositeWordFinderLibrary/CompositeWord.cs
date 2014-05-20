using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCompositeWordFinderLibrary {
	public class CompositeWord {
		// Private members		
		private string Word;
		private List<SubWord> SubWordList = new List<SubWord>();

		// Public properties
		public int Length { get { return Word.Length; } }

		// Constructors
		public CompositeWord(string word) {
			Word = word;
		}

		// Public methods
		public void AddSubWord(string subWord, int index) {
			SubWord sub = new SubWord(subWord, index);
			SubWordList.Add(sub);
		}
		public override string ToString() {
			return string.Concat(Word, ": ", string.Join(", ", SubWordList));
		}
		public bool IsTrueCompositeWord() {
			if (!DoSubWordsHaveEnoughLetters())
				return false;

			// See if we can find complete coverage by removing subwords
			while (SubWordList.Count > 0) {
				if (DoSubWordsCoverEntireWord())
					return true;
				else
					SubWordList.RemoveAt(0);
			}		

			// If we get here, nothing worked		
			return false;
		}

		// Private methods
		private bool DoSubWordsHaveEnoughLetters() {
			int totalSubWordLenth = SubWordList.Sum(sw => sw.Length);
			if (totalSubWordLenth < Word.Length)
				return false;
			else
				return true;
		}
		private bool DoSubWordsCoverEntireWord() {
			// Go thru each letter of the word and see if its covered by a subword
			int i = 0;
			while (i < Word.Length) {
				// See if there is a subword at this location
				SubWord subWord = SubWordList.FirstOrDefault(sw => sw.CompositeWordLocationIndex == i);

				// If nothing at this index, we cant provide full coverage
				if (subWord == null)
					return false;

				// Otherwise, move ahead by i and check for the next word
				else {
					i += subWord.Length;
				}
			}

			if (i == Word.Length)
				return true;
			else
				return false;
		}
	}
}

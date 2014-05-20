using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCompositeWordFinderLibrary {
	public class CompositeWordFinder {
		// Private members
		private string FileName;
		private Dictionary<string, CompositeWord> CompositeWordDictionary = new Dictionary<string, CompositeWord>();

		// Constructors
		public CompositeWordFinder(string fileName) {
			FileName = fileName;
			FindAllCompositeWords();
		}

		// Public members
		public IEnumerable<CompositeWord> GetOrderedCompositeWords() {
			var trueCompositeWords = CompositeWordDictionary.Values.Where(cw => cw.IsTrueCompositeWord()).ToList();

			return trueCompositeWords.OrderByDescending(cw => cw.Length);
		}

		// Private methods
		private void FindAllCompositeWords() {
			string[] wordArray = File.ReadAllLines(FileName);
			for (int i = 0; i < wordArray.Length; i++) {
				SetSubWords(wordArray, i);
				Console.WriteLine("Completed {0} of {1}", i, wordArray.Length);
			}
		}
		private void SetSubWords(string[] wordArray, int potentialSubWordIndex) {
			// Go thru every other word and see if this is a subword of it
			string potentialSubWord = wordArray[potentialSubWordIndex];
			for (int i = 0; i < wordArray.Length; i++) {
				if (i != potentialSubWordIndex) {	
					string word = wordArray[i];

					// Only bother checking if the potential subword is shorter than the word
					if (potentialSubWord.Length < word.Length) {
						int subWordIndex = word.IndexOf(potentialSubWord, StringComparison.Ordinal);

						// If found, create a CompositeWord and add to our list
						if (subWordIndex >= 0) {
							CompositeWord composite;
							if (!CompositeWordDictionary.TryGetValue(word, out composite)) {
								composite = new CompositeWord(word);
								CompositeWordDictionary.Add(word, composite);
							}

							composite.AddSubWord(potentialSubWord, subWordIndex);
						}
					}
				}

			}
		}
	}
}

public class Test {

	static int TOTAL_CHARACTERS = 256;

	// The preprocessing function that fills the actual value of the last occurrence of a character
	static void badCharacterHeuristic(char s[], int n,
	int badCharacter[]) {
		// First initializing all occurrences with -1
		for (int i = 0; i < TOTAL_CHARACTERS; i++)
			badCharacter[i] = -1;

		// Filling the actual value of the last occurrence of a character in the badCharacter array.
		for (int i = 0; i < n; i++)
			badCharacter[(int)s[i]] = i;
	}

	/*
	A function that searches the string and returns the occurrence.
	*/
	static void BoyerMooreAlgorithm(char text[], char pattern[]) {
		// getting the size of the pattern and the string.
		int m = pattern.length;
		int n = text.length;

		// defining a bacCharacter array.
		int badCharacter[] = new int[TOTAL_CHARACTERS];

		/*
		Filling the badCharacter array with the current pattern using a helper function.
		*/
		badCharacterHeuristic(pattern, m, badCharacter);

		// initially there is no shift
		int shifts = 0;

		// defining the boundaries of the searching
		while (shifts <= (n - m)) {
			int j = m - 1;

			/*
			If the pattern and text are matching, keep on reducing the j variable.
			*/
			while (j >= 0 && pattern[j] == text[shifts + j])
				j--;

			/*
			If the pattern is present at current
			shift, then j will become -1.
			*/
			if (j < 0) {
				System.out.println("Pattern found at index: " + shifts);

			/*
			Shifting the pattern so that the next character of the text is aligned with its last occurrence in the pattern.
			*/
			shifts += (shifts + m < n) ? m - badCharacter[text[shifts + m]] : 1;
			}

			/*
			It is shifting the pattern so that the bad character of the text is aligned with its last occurrence in the pattern. The max function helps to get the positive shift only.
			*/
			else
				shifts += Math.max(1, j - badCharacter[text[shifts + j]]);
		}
	}

	public static void main(String args[]) {

		char text[] = "Scaler Topics".toCharArray();
		char pattern[] = "Topics".toCharArray();

		BoyerMooreAlgorithm(text, pattern);
	}
}

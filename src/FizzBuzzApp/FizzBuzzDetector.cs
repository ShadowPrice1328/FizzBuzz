using System;
using System.Text;

namespace FizzBuzzApp;

/// <summary>
/// Detects and replaces words based on the algorithm constraints
/// </summary>
public class FizzBuzzDetector {
    /// <summary>
    /// Applies the FizzBuzz rules to the provided text and returns the transformed output together with the replacement statistics.
    /// </summary>
    /// <param name="input">The text to analyze and transform.</param>
    /// <returns>
    /// A <see cref="FizzBuzzResult"/> containing the processed text and occurrence counts.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="input"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the input length does not meet the required constraints.
    /// </exception>
    public FizzBuzzResult  GetOverlappings(string input) {
        if (input == null)
          throw new ArgumentNullException(nameof(input), "Input cannot be null.");
        
        if (input.Length < 7 || input.Length > 100)
          throw new ArgumentException("Input string length must be between 7 and 100 characters.");

        var output = new StringBuilder(input.Length);

        int wordIndex = 0;
        int i = 0;

        while (i < input.Length) {
            if (!char.IsLetterOrDigit(input[i])) {
                output.Append(input[i++]);
                continue;
            }

            int start = i;

            while (i < input.Length && char.IsLetterOrDigit(input[i]))
                i++;

            int length = i - start;

            wordIndex++;

            if (wordIndex % 15 == 0) {
                output.Append("FizzBuzz");
                result.FizzBuzzCount++;
            }
            else if (wordIndex % 3 == 0) {
                output.Append("Fizz");
                result.FizzCount++;
            }
            else if (wordIndex % 5 == 0) {
                output.Append("Buzz");
                result.BuzzCount++;
            }
            else {
                output.Append(input, start, length);
            }
        }

        result.OutputString = output.ToString();
    }
}

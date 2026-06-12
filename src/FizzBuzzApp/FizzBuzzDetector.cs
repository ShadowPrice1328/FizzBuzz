using System;

namespace FizzBuzzApp;

/// <summary>
/// Detects and replaces words based on the algorithm constraints
/// </summary>
public class FizzBuzzDetector {
    public FizzBuzzResult  GetOverlappings(string input) {
        if (input == null)
          throw new ArgumentNullException(nameof(input), "Input cannot be null.");
        
        if (input.Length < 7 || input.Length > 100)
          throw new ArgumentException("Input string length must be between 7 and 100 characters.");
    }
}

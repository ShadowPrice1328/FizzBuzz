namespace FizzBuzzApp;

/// <summary>
/// Represents the result of the FizzBuzz detection process.
/// </summary>
public class FizzBuzzResult {
  public string OutputString { get; set; } = string.Empty;

  public int FizzCount { get; set; }

  public int BuzzCount { get; set; }

  public int FizzBuzzCount { get; set; }

  public int TotalCount =>
    FizzCount + BuzzCount + FizzBuzzCount;
}
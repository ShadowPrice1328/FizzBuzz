using FizzBuzzApp;
using Xunit;

namespace FizzBuzzTests;

public class FizzBuzzDetectorTests {
    private readonly FizzBuzzDetector _detector = new();

    [Fact]
    public void GetOverlappings_NullInput_ThrowsArgumentNullException() {
        Assert.Throws<ArgumentNullException>(
            () => _detector.GetOverlappings(null!));
    }

    [Fact]
    public void GetOverlappings_InputTooShort_ThrowsArgumentException() {
        Assert.Throws<ArgumentException>(
            () => _detector.GetOverlappings("abc"));
    }

    [Fact]
    public void GetOverlappings_InputTooLong_ThrowsArgumentException() {
        string input = new string('a', 101);

        Assert.Throws<ArgumentException>(
            () => _detector.GetOverlappings(input));
    }

    [Fact]
    public void GetOverlappings_ReplacesThirdAndFifthWordsCorrectly() {
        string input = "one two three four five six seven";

        var result = _detector.GetOverlappings(input);

        Assert.Equal(
            "one two Fizz four Buzz Fizz seven",
            result.OutputString);

        Assert.Equal(2, result.FizzCount);
        Assert.Equal(1, result.BuzzCount);
        Assert.Equal(0, result.FizzBuzzCount);
        Assert.Equal(3, result.TotalCount);
    }

    [Fact]
    public void GetOverlappings_ReplacesFifteenthWordWithFizzBuzz() {
        string input =
            "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen";

        var result = _detector.GetOverlappings(input);

        Assert.Contains("FizzBuzz", result.OutputString);
        Assert.Equal(1, result.FizzBuzzCount);
        Assert.Equal(4, result.FizzCount);
        Assert.Equal(2, result.BuzzCount);
        Assert.Equal(7, result.TotalCount);
    }


    [Fact]
    public void GetOverlappings_IgnoresPunctuationWhenCountingWords() {
        string input =
            "one, two! three? four; five: six seven";

        var result = _detector.GetOverlappings(input);

        Assert.Equal(
            "one, two! Fizz? four; Buzz: Fizz seven",
            result.OutputString);

        Assert.Equal(2, result.FizzCount);
        Assert.Equal(1, result.BuzzCount);
        Assert.Equal(0, result.FizzBuzzCount);
    }

    [Fact]
    public void GetOverlappings_PreservesWhitespaceAndLineBreaks() {
        string input =
            "one two three\nfour five six";

        var result = _detector.GetOverlappings(input);

        Assert.Equal(
            "one two Fizz\nfour Buzz Fizz",
            result.OutputString);
    }

    [Fact]
    public void GetOverlappings_ExampleFromSpecification_ReturnsCorrectCount() {
        string input =
            """
            Mary had a little lamb
            Little lamb, little lamb
            Mary had a little lamb
            It's fleece was white as snow
            """;

        var result = _detector.GetOverlappings(input);

        Assert.Equal(5, result.FizzCount);
        Assert.Equal(3, result.BuzzCount);
        Assert.Equal(1, result.FizzBuzzCount);
        Assert.Equal(9, result.TotalCount);
    }
}

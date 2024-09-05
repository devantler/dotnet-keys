using Devantler.Keys.Age.Utils;

namespace Devantler.Keys.Age.Tests.Utils.DateTimeFormatterTests;

/// <summary>
/// Tests for the <see cref="DateTimeFormatter.FormatDateTimeWithCustomOffset"/> method.
/// </summary>
public class FormatDateTimeWithCustomOffsetTests
{
  /// <summary>
  /// Tests that a date with a zero offset is formatted correctly.
  /// </summary>
  [Fact]
  public void FormatDateTimeWithCustomOffset_GivenDateWithZeroOffset_ShouldReturnFormattedDateTimeWithZ()
  {
    // Arrange
    var dateTimeOffset = new DateTimeOffset(
        new DateTime(2022, 1, 1, 0, 0, 0),
        TimeSpan.Zero
    );

    // Act
    string formattedDateTime = DateTimeFormatter.FormatDateTimeWithCustomOffset(dateTimeOffset);

    // Assert
    Assert.Equal("2022-01-01T00:00:00Z", formattedDateTime);
  }

  /// <summary>
  /// Tests that a date with a non-zero offset is formatted correctly.
  /// </summary>
  [Fact]
  public void FormatDateTimeWithCustomOffset_GivenDateWithNonZeroOffset_ShouldReturnFormattedDateTimeWithOffset()
  {
    // Arrange
    var dateTimeOffset = new DateTimeOffset(
        new DateTime(2022, 1, 1, 0, 0, 0),
        TimeSpan.FromHours(1)
    );

    // Act
    string formattedDateTime = DateTimeFormatter.FormatDateTimeWithCustomOffset(dateTimeOffset);

    // Assert
    Assert.Equal("2022-01-01T00:00:00+01:00", formattedDateTime);
  }
}

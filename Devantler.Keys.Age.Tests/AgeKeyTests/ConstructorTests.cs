using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Devantler.Keys.Age.Tests.AgeKeyTests;

/// <summary>
/// Tests for the <see cref="AgeKey"/> constructor.
/// </summary>
public class ConstructorTests
{
  /// <summary>
  /// Tests that an age key is created with valid data.
  /// </summary>
  [Fact]
  public async Task Constructor_GivenValidData_ShouldCreateAgeKey()
  {
    // Arrange
    string publicKey = "age1wrczv4ll5att0mm8tmp4052z4fadw5zefxvefuqxu8rqtpe47chskk9dgn";
    string privateKey = "AGE-SECRET-KEY-1PW4MMMJ9KMZ94C2N2FM3UPLPQPEF8G9QHXP8VX6V6GW3EN9QMSVQX0ATHQ";
    var createdAt = DateTime.Parse("1920-08-18T00:00:00+00:00", CultureInfo.InvariantCulture);

    // Act
    var ageKey = new AgeKey(publicKey, privateKey, createdAt);

    // Assert
    Assert.Equal(publicKey, ageKey.PublicKey);
    Assert.Equal(privateKey, ageKey.PrivateKey);
    Assert.Equal(createdAt, ageKey.CreatedAt);
    _ = await Verify(ageKey.ToString());
  }

  /// <summary>
  /// Tests that an exception is thrown when the public key is invalid.
  /// </summary>
  [Fact]
  public void Constructor_GivenInvalidPublicKey_ShouldThrowException()
  {
    // Arrange
    string publicKey = "invalid";
    string privateKey = "AGE-SECRET-KEY-1PW4MMMJ9KMZ94C2N2FM3UPLPQPEF8G9QHXP8VX6V6GW3EN9QMSVQX0ATHQ";
    var createdAt = DateTime.Parse("1920-08-18T00:00:00+00:00", CultureInfo.InvariantCulture);

    // Act
    var ageKey = default(AgeKey);
    void act() => ageKey = new AgeKey(publicKey, privateKey, createdAt);

    // Assert
    _ = Assert.Throws<ValidationException>(act);
  }

  /// <summary>
  /// Tests that an exception is thrown when the private key is invalid.
  /// </summary>
  [Fact]
  public void Constructor_GivenInvalidPrivateKey_ShouldThrowException()
  {
    // Arrange
    string publicKey = "age1wrczv4ll5att0mm8tmp4052z4fadw5zefxvefuqxu8rqtpe47chskk9dgn";
    string privateKey = "invalid";
    var createdAt = DateTime.Parse("1920-08-18T00:00:00+00:00", CultureInfo.InvariantCulture);

    // Act
    var ageKey = default(AgeKey);
    void act() => ageKey = new AgeKey(publicKey, privateKey, createdAt);

    // Assert
    _ = Assert.Throws<ValidationException>(act);
  }

  /// <summary>
  /// Tests that the created at date is set to the current date when not provided.
  /// </summary>
  [Fact]
  public void Constructor_GivenNoCreatedAt_ShouldSetCreatedAtToCurrentDate()
  {
    // Arrange
    string publicKey = "age1wrczv4ll5att0mm8tmp4052z4fadw5zefxvefuqxu8rqtpe47chskk9dgn";
    string privateKey = "AGE-SECRET-KEY-1PW4MMMJ9KMZ94C2N2FM3UPLPQPEF8G9QHXP8VX6V6GW3EN9QMSVQX0ATHQ";

    // Act
    var ageKey = new AgeKey(publicKey, privateKey);

    // Assert
    Assert.Equal(publicKey, ageKey.PublicKey);
    Assert.Equal(privateKey, ageKey.PrivateKey);
    Assert.True(ageKey.CreatedAt <= DateTime.Now);
  }
}

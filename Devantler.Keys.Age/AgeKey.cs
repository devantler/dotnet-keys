using System.Globalization;
using Devantler.Keys.Core;

namespace Devantler.Keys.Age;

/// <summary>
/// A class to represent an Age key.
/// </summary>
public class AgeKey : IKey
{
  /// <summary>
  /// The public key.
  /// </summary>
  public required string PublicKey { get; set; }
  /// <summary>
  /// The private key.
  /// </summary>
  public required string PrivateKey { get; set; }

  /// <summary>
  /// The date and time the key was created.
  /// </summary>
  public required DateTime CreatedAt { get; set; }

  /// <summary>
  /// Prints the key in the Age format.
  /// </summary>
  /// <returns></returns>
  public override string ToString()
  {
    // I need the date in this format 2021-01-02T15:30:45+01:00
    return $"""
    # created: {CreatedAt.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture)}
    # public key: {PublicKey}
    {PrivateKey}
    """;
  }
}

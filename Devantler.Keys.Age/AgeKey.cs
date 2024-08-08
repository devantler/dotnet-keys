using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Devantler.Keys.Core;

namespace Devantler.Keys.Age;

/// <summary>
/// A class to represent an Age key.
/// </summary>
public class AgeKey : IKey
{
  /// <summary>
  /// Creates a new instance of the <see cref="AgeKey"/> class.
  /// </summary>
  /// <param name="publicKey"></param>
  /// <param name="privateKey"></param>
  /// <param name="createdAt"></param>
  [SetsRequiredMembers]
  public AgeKey(string publicKey, string privateKey, DateTime createdAt = default)
  {
    PublicKey = publicKey;
    PrivateKey = privateKey;
    CreatedAt = createdAt == default ? DateTime.Now : createdAt;
    Validator.ValidateObject(this, new ValidationContext(this), validateAllProperties: true);
  }

  /// <summary>
  /// The public key.
  /// </summary>
  /// <summary>
  /// The public key.
  /// </summary>
  [RegularExpression(@"^age1[a-z0-9]{58}$", ErrorMessage = "The public key must be a valid Age public key.")]
  public required string PublicKey { get; set; }
  /// <summary>
  /// The private key.
  /// </summary>
  /// <summary>
  /// The private key.
  /// </summary>
  [RegularExpression(@"^AGE-SECRET-KEY-1[A-Z0-9]{58}$", ErrorMessage = "The private key must be a valid Age secret key.")]
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

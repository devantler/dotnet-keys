namespace Devantler.Keys.Core;

/// <summary>
/// Interface for a key.
/// </summary>
public interface IKey
{
  /// <summary>
  /// The public key.
  /// </summary>
  string PublicKey { get; set; }

  /// <summary>
  /// The private key.
  /// </summary>
  string PrivateKey { get; set; }

  /// <summary>
  /// The date and time the key was created.
  /// </summary>
  DateTime CreatedAt { get; set; }

  /// <summary>
  /// Prints the key in the specific keys native format.
  /// </summary>
  /// <returns></returns>
  string ToString();
}

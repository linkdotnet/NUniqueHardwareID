using System.Security.Cryptography;

namespace LinkDotNet.NUniqueHardwareID
{
    /// <summary>
    /// Provides properties and methods to retrieve an unique hardware id
    /// </summary>
    public interface IUniqueHardwareId
    {
        /// <summary>
        /// Gets or sets whether the CPU is taking into account for calculating the hardware id
        /// </summary>
        bool UseCPUInformation { get; set; }

        /// <summary>
        /// Gets or sets whether the primay network device is taking into account for calculating the hardware id
        /// </summary>
        /// <remarks>The loopback-device is ignored</remarks>
        bool UseMACAddress { get; set; }

        /// <summary>
        /// Gets or sets whether the volume where windows is installed is taking into account
        /// </summary>
        bool UseVolumeInformation { get; set; }

        /// <summary>
        /// Calculates the unique hardware id with an MD5-Hash
        /// </summary>
        /// <returns>The unique id. Returns null, when <see cref="UseCPUInformation"/>,
        /// <see cref="UseMACAddress"/> and <see cref="UseVolumeInformation"/> are false</returns>
        string CalculateHardwareId();

        /// <summary>
        /// Calculates the unique hardwareid
        /// </summary>
        /// <param name="hashAlgorithm">Used hashAlgorithm-algorithm to create the unique id</param>
        /// <returns>The unique id. Returns null, when <see cref="UseCPUInformation"/>,
        /// <see cref="UseMACAddress"/> and <see cref="UseVolumeInformation"/> are false</returns>
        string CalculateHardwareId(HashAlgorithm hashAlgorithm);
    }
}

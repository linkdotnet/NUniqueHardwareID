using System.Security.Cryptography;

namespace LinkDotNet.NUniqueHardwareID
{
    /// <summary>
    /// Provides properties and methods to retrieve an unique hardware id
    /// </summary>
    interface IUniqueHardwareId
    {
        /// <summary>
        /// Gets or sets whether the CPU is taking into account for calculating the hardware id
        /// </summary>
        bool ShouldUseCPUInfo { get; set; }

        /// <summary>
        /// Gets or sets whether the primay network device is taking into account for calculating the hardware id
        /// </summary>
        /// <remarks>The loopback-device is ignored</remarks>
        bool ShouldUseMACAddress { get; set; }

        /// <summary>
        /// Calculates the unique hardware id with an MD5-Hash
        /// </summary>
        /// <returns>The unique id. Returns null, when <see cref="ShouldUseCPUInfo"/> and <see cref="ShouldUseMACAddress"/> are false</returns>
        string CalculateHardwareId();

        /// <summary>
        /// Calculates the unique hardwareid
        /// </summary>
        /// <param name="hashAlgorithm">Used hashAlgorithm-algorithm to create the unique id</param>
        /// <returns>The unique id. Returns null, when <see cref="ShouldUseCPUInfo"/> and <see cref="ShouldUseMACAddress"/> are false</returns>
        string CalculateHardwareId(HashAlgorithm hashAlgorithm);
    }
}

using System;

namespace LinkDotNet.NUniqueHardwareID
{
    /// <summary>
    /// Retrieves an unique identifier for the cpu
    /// </summary>
    internal static class CPURetriever
    {
        /// <summary>
        /// Generates a string containing cpu-information
        /// </summary>
        public static string GetCPUInfo()
        {
            var vendorIdentifier = Environment.GetEnvironmentVariable("Processor_Identifier");
            var revision = Environment.GetEnvironmentVariable("Processor_Revision");

            return vendorIdentifier + revision;
        }
    }
}
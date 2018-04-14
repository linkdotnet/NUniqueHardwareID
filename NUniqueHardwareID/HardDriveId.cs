using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace LinkDotNet.NUniqueHardwareID
{
    /// <summary>
    /// Gets information about the harddrive
    /// </summary>
    internal static class HardDriveId
    {
        /// <summary>
        /// Gets the serial number from the WinAPI GetVolumeInformation call
        /// </summary>
        public static string GetSerialNumber()
        {
            var windowsDrive = Path.GetPathRoot(Environment.SystemDirectory);

            GetVolumeInformation(
                windowsDrive, 
                null, 
                0, 
                out var serialNumber,
                out var maxComponentLength,
                out var sysFlags, 
                null, 
                0);

            return serialNumber.ToString();
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetVolumeInformation(
            string rootPathName,
            StringBuilder volumeNameBuffer,
            int volumeNameSize,
            out uint volumeSerialNumber,
            out uint maximumComponentLength,
            out uint fileSystemFlags,
            StringBuilder fileSystemNameBuffer,
            int nFileSystemNameSize);
    }
}
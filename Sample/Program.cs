using System;
using System.Security.Cryptography;
using LinkDotNet.NUniqueHardwareID;

namespace Sample
{
    internal static class Program
    {
        internal static void Main()
        {)
            var hardwareIdGenerator = new UniqueHardwareId();

            Console.WriteLine($"Hardware Id MD5: {hardwareIdGenerator.CalculateHardwareId()}");
            Console.WriteLine($"Hardware Id SHA256: {hardwareIdGenerator.CalculateHardwareId(SHA256.Create())}");
            Console.ReadKey();
        }
    }
}

# NUniqueHardwareID
This class can generate an unique hardware id based on different specs, which you can choose.

Time to time you want an unique id, which will not change offer a greater period of time.
At the moment the following things are taking into account
 - MAC-Address
	 - The first device (which is not the loopback device) MAC-Address is taking into account
 - CPU
	 - The vendor identifier and the revision is taken
 - Hard Drive Disk
	- Information about the primary disk (where windows is installed) are retrieved

## Sample

    using LinkDotNet.NUniqueHardwareID;
    
    var hardwareIdGenerator = new UniqueHardwareId
    {
        UseCPUInfo = true,
        UseMACAddress = true,
        UseVolumeInformation = true
    };
    
    var hardwareId = hardwareIdGenerator.CalculateHardwareId();

In this sample MD5 is used to generate the final string. You also have the possibility to pass in an Hash-Algorithm (i.e. SHA256).

    var hardwareId = hardwareIdGenerator.CalculateHardwareId(SHA256.Create());
    
## Download
You can either clone that repository to compile the assembly or include the source directly or use the nuget-Package: 
[![NuGet Version and Downloads count](https://buildstats.info/nuget/LinkDotNet.NUniqueHardwareID)](https://www.nuget.org/packages/LinkDotNet.NUniqueHardwareID) 

## License
MIT-License

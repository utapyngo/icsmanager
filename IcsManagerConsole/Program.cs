using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using IcsManagerLibrary;

namespace IcsManagerConsole
{

    class Program
    {
        static void Info()
        {
            foreach (var nic in IcsManager.GetAllIPv4Interfaces())
            {
                Console.WriteLine(
                            "Name .......... : {0}", nic.Name);
                Console.WriteLine(
                            "GUID .......... : {0}", nic.Id);
                Console.WriteLine(
                            "Status ........ : {0}", nic.OperationalStatus);

                Console.WriteLine(
                            "InterfaceType . : {0}", nic.NetworkInterfaceType);

                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    var ipprops = nic.GetIPProperties();
                    foreach (var a in ipprops.UnicastAddresses)
                    {
                        if (a.Address.AddressFamily == AddressFamily.InterNetwork)
                            Console.WriteLine(
                                "Unicast address : {0}/{1}", a.Address, a.IPv4Mask);
                    }
                    foreach (var a in ipprops.GatewayAddresses)
                    {
                        Console.WriteLine(
                            "Gateway ....... : {0}", a.Address);
                    }
                }
                try
                {
                    var connection = IcsManager.GetConnectionById(nic.Id);
                    if (connection != null)
                    {
                        var props = IcsManager.GetProperties(connection);
                        Console.WriteLine(
                            "Device ........ : {0}", props.DeviceName);
                        var sc = IcsManager.GetConfiguration(connection);
                        if (sc.SharingEnabled)
                            Console.WriteLine(
                                "SharingType ... : {0}", sc.SharingConnectionType);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Please run this program with Admin rights to see all properties");
                }
                catch (NotImplementedException e)
                {
                    Console.WriteLine("This feature is not supported on your operating system.");
                    Console.WriteLine(e.StackTrace);
                }
                Console.WriteLine();
            }
        }



        static void EnableICS(string shared, string home, bool force)
        {
            var connectionToShare = IcsManager.FindConnectionByIdOrName(shared);
            if (connectionToShare == null)
            {
                Console.WriteLine("Connection not found: {0}", shared);
                return;
            }
            var homeConnection = IcsManager.FindConnectionByIdOrName(home);
            if (homeConnection == null)
            {
                Console.WriteLine("Connection not found: {0}", home);
                return;
            }

            var currentShare = IcsManager.GetCurrentlySharedConnections();
            if (currentShare.Exists)
            {
                Console.WriteLine("Internet Connection Sharing is already enabled:");
                Console.WriteLine(currentShare);
                if (!force)
                {
                    Console.WriteLine("Please disable it if you want to configure sharing for other connections");
                    return;
                }
                Console.WriteLine("Sharing will be disabled first.");
            }

            IcsManager.ShareConnection(connectionToShare, homeConnection);
        }

        static void DisableICS()
        {
            var currentShare = IcsManager.GetCurrentlySharedConnections();
            if (!currentShare.Exists)
            {
                Console.WriteLine("Internet Connection Sharing is already disabled");
                return;
            }
            Console.WriteLine("Internet Connection Sharing will be disabled:");
            Console.WriteLine(currentShare);
            IcsManager.ShareConnection(null, null);
        }

        static void Usage()
        {
            var appName = Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName);
            appName = appName == null ? "" : appName.ToLower();
            Console.WriteLine("Usage: ");
            Console.WriteLine("  {0} info", appName);
            Console.WriteLine("  {0} enable {{GUID-OF-CONNECTION-TO-SHARE}} {{GUID-OF-HOME-CONNECTION}} [force]", appName);
            Console.WriteLine("  {0} enable \"Name of connection to share\" \"Name of home connection\" [force]", appName);
            Console.WriteLine("  {0} disable", appName);
        }

        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Info();
                    Usage();
                    return;
                }

                var command = args[0];

                if (command == "info")
                {
                    Info();
                }
                else if (command == "enable")
                {
                    var force = false;
                    if ((args.Length == 4) && (args[3] == "force"))
                    {
                        force = true;
                    }
                    try
                    {
                        var shared = args[1];
                        var home = args[2];
                        EnableICS(shared, home, force);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Usage();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("This operation requires elevation.");
                    }

                }
                else if (command == "disable")
                {
                    try
                    {
                        DisableICS();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("This operation requires elevation.");
                    }
                }
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("This program is not supported on your operating system.");
            }
            finally
            {
                #if (DEBUG)
                Console.ReadKey();
                #endif
            }
        }
    }
}

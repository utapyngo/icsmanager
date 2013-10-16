using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using NETCONLib;

namespace IcsManagerLibrary
{
    public class IcsManager
    {
        private static readonly INetSharingManager SharingManager = new NetSharingManager();

        public static IEnumerable<NetworkInterface> GetIPv4EthernetAndWirelessInterfaces()
        {
            return
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.Supports(NetworkInterfaceComponent.IPv4)
                where (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                   || (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                select nic;
        }

        public static NetShare GetCurrentlySharedConnections()
        {
            INetConnection sharedConnection = (
                from INetConnection c in SharingManager.EnumEveryConnection
                where GetConfiguration(c).SharingEnabled
                where GetConfiguration(c).SharingConnectionType ==
                    tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PUBLIC
                select c).DefaultIfEmpty(null).First();
            INetConnection homeConnection = (
                from INetConnection c in SharingManager.EnumEveryConnection
                where GetConfiguration(c).SharingEnabled
                where GetConfiguration(c).SharingConnectionType ==
                    tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PRIVATE
                select c).DefaultIfEmpty(null).First();
            return new NetShare(sharedConnection, homeConnection);
        }

        public static void ShareConnection(INetConnection connectionToShare, INetConnection homeConnection)
        {
            if ((connectionToShare == homeConnection) && (connectionToShare != null))
                throw new ArgumentException("Connections must be different");
            var share = GetCurrentlySharedConnections();
            if (share.SharedConnection != null)
                GetConfiguration(share.SharedConnection).DisableSharing();
            if (share.HomeConnection != null)
                GetConfiguration(share.HomeConnection).DisableSharing();
            if (connectionToShare != null)
            {
                var sc = GetConfiguration(connectionToShare);
                sc.EnableSharing(tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PUBLIC);
            }
            if (homeConnection != null)
            {
                var hc = GetConfiguration(homeConnection);
                hc.EnableSharing(tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PRIVATE);
            }
        }

        public static INetSharingConfiguration GetConfiguration(INetConnection connection)
        {
            return SharingManager.get_INetSharingConfigurationForINetConnection(connection);
        }

        public static INetConnectionProps GetProperties(INetConnection connection)
        {
            return SharingManager.get_NetConnectionProps(connection);
        }


        public static INetSharingEveryConnectionCollection GetAllConnections()
        {
            return SharingManager.EnumEveryConnection;
        }

        public static INetConnection FindConnectionByIdOrName(string shared)
        {
            return GetConnectionById(shared) ?? GetConnectionByName(shared);
        }

        public static INetConnection GetConnectionById(string guid)
        {
            return (from INetConnection c in GetAllConnections()
                    where GetProperties(c).Guid == guid
                    select c).DefaultIfEmpty(null).First();
        }

        public static INetConnection GetConnectionByName(string name)
        {
            return (from INetConnection c in GetAllConnections()
                    where GetProperties(c).Name == name
                    select c).DefaultIfEmpty(null).First();
        }

    }
}

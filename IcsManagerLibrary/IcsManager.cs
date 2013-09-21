using System.Linq;
using NETCONLib;

namespace IcsManagerLibrary
{
    public class IcsManager
    {
        private static readonly INetSharingManager SharingManager = new NetSharingManager();

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
                return;
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

        public static INetSharingConfiguration GetConfiguration(INetConnection netShareConnection)
        {
            return SharingManager.INetSharingConfigurationForINetConnection[netShareConnection];
        }

        public static INetConnectionProps GetProperties(INetConnection netShareConnection)
        {
            return SharingManager.NetConnectionProps[netShareConnection];
        }


        public static INetSharingEveryConnectionCollection GetAllConnections()
        {
            return SharingManager.EnumEveryConnection;
        }

        public static INetConnection FindConnectionByIdOrName(string shared)
        {
            INetConnection conn;
            conn = GetConnectionById(shared);
            if (conn == null)
            {
                conn = GetConnectionByName(shared);
            }
            return conn;
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

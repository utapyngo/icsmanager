using System;
using System.Net.NetworkInformation;
using IcsManagerLibrary;
using NETCONLib;

namespace IcsManagerGUI
{
    internal class ConnectionItem
    {
        public NetworkInterface Nic;

        public INetConnection Connection
        {
            get
            {
                return IcsManager.GetConnectionById(Nic.Id);
            }
        }

        public ConnectionItem(NetworkInterface nic)
        {
            Nic = nic;
        }

        override public String ToString()
        {
            return Nic.Name;
        }
    }
}

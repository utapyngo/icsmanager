using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using NETCONLib;
using IcsManagerLibrary;

namespace IcsManagerGUI
{
    public partial class IcsManagerForm : Form
    {

        public IcsManagerForm()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSharingManager_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshConnections();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Please restart this program with administrative priviliges.");
                Close();
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("This program is not supported on your operating system.");
                Close();
            }
        }

        private void AddNic(NetworkInterface nic)
        {
            var connItem = new ConnectionItem(nic);
            cbSharedConnection.Items.Add(connItem);
            cbHomeConnection.Items.Add(connItem);
            var netShareConnection = connItem.Connection;
            if (netShareConnection != null)
            {
                var sc = IcsManager.GetConfiguration(netShareConnection);
                if (sc.SharingEnabled)
                {
                    switch (sc.SharingConnectionType)
                    {
                        case tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PUBLIC:
                            cbSharedConnection.SelectedIndex = cbSharedConnection.Items.Count - 1;
                            break;
                        case tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PRIVATE:
                            cbHomeConnection.SelectedIndex = cbSharedConnection.Items.Count - 1;
                            break;
                    }
                }
            }
        }

        private void RefreshConnections()
        {
            cbSharedConnection.Items.Clear();
            cbHomeConnection.Items.Clear();
            foreach (var nic in IcsManager.GetAllIPv4Interfaces())
            {
                AddNic(nic);
            }
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            var sharedConnectionItem = cbSharedConnection.SelectedItem as ConnectionItem;
            var homeConnectionItem = cbHomeConnection.SelectedItem as ConnectionItem;
            if ((sharedConnectionItem == null) || (homeConnectionItem == null))
            {
                MessageBox.Show(@"Please select both connections.");
                return;
            }
            if (sharedConnectionItem.Connection == homeConnectionItem.Connection)
            {
                MessageBox.Show(@"Please select different connections.");
                return;
            }
            IcsManager.ShareConnection(sharedConnectionItem.Connection, homeConnectionItem.Connection);
            RefreshConnections();
        }

        private void cbHomeConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonStopSharing_Click(object sender, EventArgs e)
        {
            IcsManager.ShareConnection(null, null);
            RefreshConnections();
        }
    }
}

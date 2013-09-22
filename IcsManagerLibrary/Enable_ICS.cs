using System;
using System.Management.Automation;

namespace IcsManagerLibrary
{
    [Cmdlet(VerbsLifecycle.Enable, "ICS")]
    public class Enable_ICS: PSCmdlet
    {
        [Parameter(HelpMessage = "Connection to share (name or GUID)", 
                   Mandatory = true, 
                   Position = 0)]
        public string Shared_connection;

        [Parameter(HelpMessage = "Home connection (name or GUID)",
                   Mandatory = true,
                   Position = 1)]
        public string Home_connection;

        [Parameter(HelpMessage = "Force disabling ICS if already enabled",
                   Mandatory = false)]
        public bool force = false;

        protected override void ProcessRecord()
        {
            var connectionToShare = IcsManager.FindConnectionByIdOrName(Shared_connection);
            if (connectionToShare == null)
            {
                WriteError(new ErrorRecord(new PSArgumentException("Connection not found"), "", 
                    ErrorCategory.InvalidArgument, Shared_connection));
                return;
            }
            var homeConnection = IcsManager.FindConnectionByIdOrName(Home_connection);
            if (homeConnection == null)
            {
                WriteError(new ErrorRecord(new PSArgumentException("Connection not found"), 
                                           "", 
                                           ErrorCategory.InvalidArgument, 
                                           Home_connection));
                return;
            }

            var currentShare = IcsManager.GetCurrentlySharedConnections();
            if (currentShare.Exists)
            {
                WriteWarning("Internet Connection Sharing is already enabled: " + currentShare);
                if (!force)
                {
                    WriteError(new ErrorRecord(
                        new PSInvalidOperationException("Please disable existing ICS if you want to enable it for other connections, or set the force flag to true"), 
                        "",
                        ErrorCategory.InvalidOperation,
                        null));
                    return;
                }
                Console.WriteLine("Sharing will be disabled first.");
            }

            IcsManager.ShareConnection(connectionToShare, homeConnection);
        }
    }
}

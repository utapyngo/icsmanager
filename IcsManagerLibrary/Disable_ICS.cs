using System.Management.Automation;

namespace IcsManagerLibrary
{
    [Cmdlet(VerbsLifecycle.Disable, "ICS")]
    public class Disable_ICS: PSCmdlet
    {
        protected override void ProcessRecord()
        {
            IcsManager.ShareConnection(null, null);
        }
    }
}

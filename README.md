Internet Connection Sharing Manager
===================================

It is a simple command line tool for turning ICS on or off on Windows 7 and higher.

I wrote it because the `netsh routing` command which could be used for this in Windows XP is not available in Windows 7.


Requirements
------------

* Windows 7 or higher.
* .NET Framework 4.0.

Install System.Management.Automation
------------------------------------
It seems that `System.Management.Automation` is no longer supported by .NET.
There is an unofficial package https://www.nuget.org/packages/System.Management.Automation.

You can install it in Visual Studio by open **Tools** > **NuGet Package Manager** > **Package Manager Console** and type


    PM> Install-Package System.Management.Automation -Version 6.1.7601.17515


Building
--------

Run `build.cmd`.


Usage
-----

All commands require administrative privileges.

---
	
    icsmanager info

Display information about currently available connections:

* name
* guid
* status
* address
* gateway
* sharing status

---

    icsmanager enable {GUID-OF-CONNECTION-TO-SHARE} {GUID-OF-HOME-CONNECTION} [force]
    icsmanager enable "Name of connection to share" "Name of home connection" [force]

Enable connection sharing. Use the `force` argument if you want to automatically disable existing connection sharing.

---

    icsmanager disable

Disable connection sharing.

---

Powershell
----------

0. Import module:

    Import-Module IcsManager.dll

0. List network connections:

    Get-NetworkConnections

0. Start Internet Connection Sharing:

    Enable-ICS "Connection to share" "Home connection"

0. Stop Internet Connection Sharing:

    Disable-ICS


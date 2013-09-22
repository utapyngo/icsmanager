Internet Connection Sharing Manager
===================================

It is a simple command line tool for turning ICS on or off on Windows 7 and higher.

I wrote it because the `netsh routing` command which could be used for this in Windows XP is not available in Windows 7.


Requirements
------------

* Windows 7 or higher.
* .NET Framework 4.0.


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


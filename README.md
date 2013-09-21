ICS Manager
===========

Building
--------

Run `build.cmd`.


Usage
-----

All commans require administrative privileges.

	
`icsmanager info`

Display information about currently available connections:

* name
* guid
* status
* address
* gateway
* sharing status


`icsmanager enable {GUID-OF-CONNECTION-TO-SHARE} {GUID-OF-HOME-CONNECTION} [force]`
`icsmanager enable "Name of connection to share" "Name of home connection" [force]`

Enable connection sharing. Use the `force` argument if you want to automatically disable existing connection sharing.


`icsmanager disable`

Disable connection sharing.

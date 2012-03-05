Release Notes for the MCP2200 Driver INF File

Version 1.00
Driver Version: 5.1.2600.0
Initial Release
Use this driver if device manufacturing code is 1001nnn or earlier.
NOTE: Devices that use this driver were early samples only, and are not common.

Version 1.1
Driver version: 5.1.2600.2
Use this driver if device manufacturing code is 1002nnn or later.

WINDOWS HOTFIXES:
---
"Code 10" error when installing driver:
Microsoft has identified an issue with the "usbser.sys" driver causing performance issues and have created a fix.

Refer to Knowledge Base (KB) article "KB943198" at:
http://support.microsoft.com

The fix can be downloaded here:
http://www.microsoft.com/downloads/details.aspx?FamilyId=F2F0A7C2-3B44-4D2E-9640-E0D21818763E&displaylang=en
---
---
Device Enumerates, but does not communicate on the CDC interface (Windows XP):
Microsoft has identified an issue with the "usbser.sys" driver causing performance issues and have created a fix.

Refer to Knowledge Base (KB) article "KB935892" at:
http://support.microsoft.com

Note: The hotfix refers to issues with Windows XP Tablet PCs, however, this fix also corrects the CDC communication issue.

The fix can be downloaded here:
http://support.microsoft.com/kb/935892
---

---
Driver loading issue in Windows XP
Microsoft has identified an issue with the "usbser.sys" driver may not load when USB device uses IAD to define a function that has multiple interfaces.

Refer to Knowledge Base (KB) article "KB918365" at:
http://support.microsoft.com

Note: The hotfix refers to issues with Windows XP Tablet PCs, however, this fix also corrects the CDC communication issue.

The fix can be downloaded here:
http://support.microsoft.com/kb/918365
---

END
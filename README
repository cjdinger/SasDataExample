SAS Data Explorer task
by Chris Hemedinger, SAS
Copyright 2012

About this example
-----------------------
This simple custom task shows the features of the classes
within the SAS.Tasks.Toolkit.SasData namespace.

Online reference documentation:
http://go.sas.com/customtasksapi

To USE this example with SAS Enterprise Guide, follow these
simple steps to "install":

Version 4.3:
- Copy SAS.Tasks.SasDataExample.DLL to %appdata%\SAS\EnterpriseGuide\4.3\Custom
  You might need to create the "Custom" folder in that location.
  %appdata% is a Windows environment variable that resolves to your user profile 
  area.

Version 5.1
- Copy SAS.Tasks.SasDataExample.DLL to %appdata%\SAS\EnterpriseGuide\5.1\Custom
  You might need to create the "Custom" folder in that location.
  %appdata% is a Windows environment variable that resolves to your user profile 
  area.

You'll find the task in the Tools->Add-Ins menu.

This task also works with SAS Add-In for Microsoft Office:
-  Copy SAS.Tasks.SasDataExample.DLL to %appdata%\SAS\Add-InForMicrosoftOffice\4.3\Custom, or
-  Copy SAS.Tasks.SasDataExample.DLL to %appdata%\SAS\Add-InForMicrosoftOffice\5.1\Custom

You'll find the task in SAS->Tasks->SAS Examples.

To BUILD this example:
 - Open SasDataExample.sln file with:
     Microsoft Visual Studio 2010, OR
     Microsoft Visual C# 2010 Express Edition (free from Microsoft)

 - In the Properties for the project, verify the Reference paths
   include the location for your SAS Enterprise Guide installation 
   folder.  For example:

   9.3 installs: c:\program files\sashome\x86\sasenterpriseguide\4.3\

   Or

   9.2 installs: c:\program files\sas\enterpriseguide\4.3\

To UNDERSTAND this example:
  - The TestSasDataForm class (in TestSasDataForm.cs) includes
    methods that use the SAS.Task.Toolkit classes.  These classes simplify
	common data access needs that you may have within custom tasks.

	The classes used include:
	  SAS.Tasks.Toolkit.SasServer (object for SAS workspace)
	  SAS.Tasks.Toolkit.SasData.SasLibrary (object for SAS data library)
	  SAS.Tasks.Toolkit.SasData.SasData (object for SAS data set or view)
	  SAS.Tasks.Toolkit.SasData.SasColumn (object for a variable in a data set)
	  SAS.Tasks.Toolkit.Helpers.TaskDataHelpers (methods for retrieving data values)

For more information about custom tasks, visit The SAS Dummy blog at:
http://blogs.sas.com/sasdummy

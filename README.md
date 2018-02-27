# AttributeUnlocker
Unlocks an attribute within Application Server

# Purpose
As galaxies are migrated to new versions, attributes can be removed from the editor (2014 >= 2014 R2 - Engine.RestartOnFailure was removed from the IDE), if they are then locked the user has no way to unlock them. This simple application allows the user to compile using the GRAccess toolkit to unlock the required attributes via command line.

# Usage
The C# application was poorly written in Visual Studio 2015, compile the application
and execute it with the following parameters:

unlockattribute.exe galaxy name, template name, attribute name, <username>, <password>

Unsupported
-----------

The primary implications of being UNSUPPORTED are:

1. These scripts have had LIMITED testing and may not work completely as intended and may have unintended side effects.
1. They include NO WARRANTY OF ANY KIND. Schneider Electric Software assumes NO responsibility for these scripts or any unintended consequences of using them.
1. By using them, you assume FULL responsibility for the consequences.
1. The scripts/objects may fail to work following a product update (patch, service pack, major release) that makes changes to existing database objects.
1. Wonderware/Schneider Electric assumes no responsibility to answer questions or assist with the use of the scripts themselves (although, to the degree they leverage standard product features, those are of course supported).
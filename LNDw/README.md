# LNDw

Lightning Network channels rebalancing and Fee control by local balance ratio for Windows.

# install

Compile from source codes.

1. Download Visual Studio 2022(Download Community 2022)
https://learn.microsoft.com/ja-jp/visualstudio/releases/2022/release-notes
2. Project file open : LNDw.sln
3. Build release

Or Download binary files from release.

# Configure Windows(for SSL connection)

import personal certificate("tls.cert") into certificate stores using "certmgr.msc" 
1. Open a new command window.
2. Enter "certmgr.msc" as a command.
3. "Trusted Root Certification Authorities" -> "All Tasks" -> "Import"
4. Choose "tls.cert" file

# Using LNDw

LNDw.exe

# Configure LNDw
1. "Config setting" tab --> input LND endpoint uri and macaroon path.
![LNDw_setting](https://user-images.githubusercontent.com/35624002/204707251-afd5a7fb-ae5d-469c-aa26-c0b74c666047.gif)
2. "Channels" tab --> click "update channel" button.


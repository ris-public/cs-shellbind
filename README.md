# cs-shellbind
Bind command as stream.
WARNING: Never pass unsanitized strings to the hostname, port, etc.; they are just passed as-is and might cause shell escape attacks.

stdbuf (GNU coreutils/BSD) or unbuffer from expect (TCL) should preferably be there too (although this can work without it, there might be buffering delays).

WinPTY is recommended for Windows. Can be found at https://github.com/rprichard/winpty .

ShellSocket should be initialized with the values; default uses stdbuf but can be changed later. Comes with utility classes Pair and StatPair, which can be used to pair a Read/Write stream into one large stream.
RedirectErrorsToStream and RedirectErrorsToConsole were added.

# Architrcture
GetStream() returns the stream of ShellSocket. ProxySocket should be Start()ed to connect.

# Usage
Please see the Test file.

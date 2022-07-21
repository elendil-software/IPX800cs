# IPX800 C# v3

Copyright (c) 2013-2022 Julien Tschäppät

IPX800 C# is a library that allows to control an IPX800 v2, v3, v4, v5 from [GCE Electronic](http://www.gce-electronics.com)

## Features

Support of common functions of IPX800 v2, v3, v4, v5 like reading or setting output state and reading the inputs state

## Breaking changes

The version 3 introduce several breaking changes :

- IPX800v3 with firmware older than v3.05.42 is no more supported
- The class IPX800Factory is no more static and now implement IIPX800Factory
- Send of HTTP request now use HttpClient instead of WebRequest
- IIPX800, IIPX800v2, ... interfaces have been simplified. Only the IIPX800 left. To replace the specific methods (e.g. IPX800 v4 virtual outputs) some extensions methods have been added.
- Items of IPX800Version enum have been reorderd for more logical meaning (e.g. 3 value mean IPX800 v3

## Getting Started

First, install the [NuGet](https://www.nuget.org/packages/IPX800cs) package

    Install-Package IPX800cs

Then, get an instance of an IPX800 implementation using the factory and call any IPX800 action


```csharp

//Create an IIPX800 instance 
//In the case of the HTTP protocol, another method allows to pass the HttpClient.
IIPX800 ipx800 = ipx800Factory.CreateInstance(IPX800Version.V3, IPX800Protocol.Http, "http://192.168.1.2", 80, "user", "password");

// read the state of output 1
OutputState outputState = ipx800.GetOutput(new Output { Number = 1, Type = OutputType.Output });
//Same action using the extension method 
OutputState outputState2 = ipx800.GetOutput(1);

// read the state of virtual output
OutputState virtualOutputState = ipx800.GetOutput(new Output { Number = 1, Type = OutputType.VirtualOutput });
//Same action using the extension method
OutputState virtualOutputState2 = ipx800.GetVirtualOutput(1);

// set the output state
bool result = ipx800.SetOutput(new Output { Number = 1, State = OutputState.Active, Type = OutputType.Output });
//Same action using the extension method
bool result2 = ipx800.SetOutput(1, OutputState.Active);

// etc.
```

## License

IPX800 C# is free software; you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation; either version 3.0 of the License, or (at your option) any later version.

IPX800 C# is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details (<https://www.gnu.org/licenses/lgpl.html>)

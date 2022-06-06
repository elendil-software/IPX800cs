# IPX800 C# v3

Copyright (c) 2013-2022 Julien Tschäppät

IPX800 C# is a library that allows to control an IPX800 v2, v3, v4, v5 from [GCE Electronic](http://www.gce-electronics.com)

## Features

Support of common functions of IPX800 v2, v3, v4, v5 like reading or setting output state and reading the inputs state

## Getting Started

First, install the [NuGet](https://www.nuget.org/packages/IPX800cs) package

    Install-Package IPX800cs

Then, get an instance of an IPX800 implementation using the factory and call any IPX800 action


```csharp

IIPX800Factory ipx800Factory = new IPX800Factory();

//Create an IIPX800 instance 
//In the case of the HTTP protocol, another method allows to pass the HttpClient.
ipx800Factory.CreateInstance(IPX800Version.V4, IPX800Protocol.M2M, "192.168.1.2", 9870, "user", "password"),

// read the state of output 1
OutputState outputState = ipx800.GetOutput(new Output { Number = 1, Type = OutputType.Output });
//Same action using the extension method 
OutputState outputState = ipx800.GetOutput(1);

// set the output state
bool result = ipx800.SetOutput(new Output { Number = 1, State = OutputState.Active, Type = OutputType.Output });
//Same action using the extension method
bool result = ipx800.SetOutput(1, OutputState.Active);

// etc.
```

## License

IPX800 C# is free software; you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation; either version 3.0 of the License, or (at your option) any later version.

IPX800 C# is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details (<https://www.gnu.org/licenses/lgpl.html>)

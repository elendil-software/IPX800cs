# IPX800 C# v2

Copyright (c) 2013-2019 Julien Tschäppät

IPX800 C# is a library that allows to control an IPX800 v2, v3 or v4 from [GCE Electronic](http://www.gce-electronics.com)

## Features

Support of common functions of IPX800 v2, v3 and v4

### All IPX800 versions
- Set output state
- Get output state
- Get input state
- Get analog input value

### IPX800 v4

- Set virtual output state
- Get virtual output state
- Get virtual input state
- Get virtual analog input value

## Getting Started

First, install the NuGet package

    Install-Package IPX800cs

Then, get an instance of an IPX800 implementation using the factory and call any IPX800 action


```csharp

IIPX800v4 ipx800 = IPX800Factory.GetIPX800v4Instance("192.168.1.2", 9870, IPX800Protocol.M2M, "user", "password");

// read the state of output 1
OutputState outputState = ipx800.GetOutput(1);

// set the output state
ipx800.SetOutput(1, OutputState.Active);

// set the output state (delayed mode)
ipx800.SetDelayedOutput(1);

// read the state of the input 1
InputState inputState = ipx800.GetInput(1);

// read the value of the analog input 1
int analogValue = ipx800.GetAnalogInput(1);
```

## License

IPX800 C# is free software; you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation; either version 3.0 of the License, or (at your option) any later version.

IPX800 C# is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details (<https://www.gnu.org/licenses/lgpl.html>)

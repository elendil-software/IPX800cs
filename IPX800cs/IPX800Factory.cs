﻿using System;
using IPX800cs.ActionsExecutors;
using IPX800cs.Contracts;
using IPX800cs.Version;

namespace IPX800cs
{
	public static class IPX800Factory
	{
		public static IIPX800v2 GetIPX800v2Instance(string ip, int port, IPX800Protocol protocol, string user = null, string password = null)
		{
			Context context = new Context(ip, port, protocol, IPX800Version.V2, user, password);
			
			ISetOutputExecutor setOutputExecutor = new SetOutputExecutor(context);
			IGetOutputExecutor getOutputExecutor = new GetOutputExecutor(context);
			IGetInputExecutor getInputExecutor = new GetInputExecutor(context);
			IGetAnalogInputExecutor getAnalogInputExecutor = new GetAnalogInputExecutor(context);
			IGetVersionExecutor getVersionExecutor = new GetVersionExecutor(context);

			return new IPX800v2(setOutputExecutor, getOutputExecutor, getInputExecutor, getAnalogInputExecutor, getVersionExecutor);
		}
		
		public static IIPX800v4 GetIPX800v4Instance(string ip, int port, IPX800Protocol protocol, string user = null, string password = null)
		{
			Context context = new Context(ip, port, protocol, IPX800Version.V4, user, password);
			
			ISetOutputExecutor setOutputExecutor = new SetOutputExecutor(context);
			IGetOutputExecutor getOutputExecutor = new GetOutputExecutor(context);
			IGetOutputsExecutor getOutputsExecutor = new GetOutputsExecutor(context);
			IGetInputExecutor getInputExecutor = new GetInputExecutor(context);
			IGetInputsExecutor getInputsExecutor = new GetInputsExecutor(context);
			IGetAnalogInputExecutor getAnalogInputExecutor = new GetAnalogInputExecutor(context);
			IGetAnalogInputsExecutor getAnalogInputsExecutor = new GetAnalogInputsExecutor(context);
			
			return new IPX800v4(setOutputExecutor, getOutputExecutor, getOutputsExecutor, getInputExecutor, getInputsExecutor, getAnalogInputExecutor, getAnalogInputsExecutor);
		}
		
		public static IIPX800v3 GetIPX800v3Instance(string ip, int port, IPX800Protocol protocol, string user = null, string password = null)
        {          
            Context context = GetIPX800v3Context(ip, port, protocol, IPX800Version.V3, user, password);
            return GetIPX800v3(context);
		}

		private static Context GetIPX800v3Context(string ip, int port, IPX800Protocol protocol, IPX800Version ipx800Version, string user, string password)
		{
            try
            {
                //by setting no firmware version, will consider it's >= 3.05.42
                Context context = new Context(ip, port, protocol, ipx800Version, user, password);
                IIPX800v3 ipx800 = GetIPX800v3(context);
                System.Version firmwareVersion = ipx800.GetVersion();
                return new Context(ip, port, protocol, ipx800Version, user, password, firmwareVersion);
            }
            //if exception is thrown, we probably didn't try with the correct version and should be <= 3.05.38 (last version released before the 3.05.42)
            catch (Exception)
            {
                Context context = new Context(ip, port, protocol, ipx800Version, user, password, new System.Version(3, 5, 38));
                IIPX800v3 ipx800 = GetIPX800v3(context);
                System.Version firmwareVersion = ipx800.GetVersion();
                return new Context(ip, port, protocol, ipx800Version, user, password, firmwareVersion);
            }
        }

		private static IIPX800v3 GetIPX800v3(Context context)
		{
			ISetOutputExecutor setOutputExecutor = new SetOutputExecutor(context);
			IGetOutputExecutor getOutputExecutor = new GetOutputExecutor(context);
			IGetOutputsExecutor getOutputsExecutor = new GetOutputsExecutor(context);
			IGetInputExecutor getInputExecutor = new GetInputExecutor(context);
			IGetInputsExecutor getInputsExecutor = new GetInputsExecutor(context);
			IGetAnalogInputExecutor getAnalogInputExecutor = new GetAnalogInputExecutor(context);
			IGetVersionExecutor getVersionExecutor = new GetVersionExecutor(context);
			
			return new IPX800v3(setOutputExecutor, getOutputExecutor, getOutputsExecutor, getInputExecutor, getInputsExecutor, getAnalogInputExecutor, getVersionExecutor);
		}
	}
}
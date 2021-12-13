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

			return new IPX800v2(setOutputExecutor, getOutputExecutor, getInputExecutor, getAnalogInputExecutor);
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
	        Context context = new Context(ip, port, protocol, IPX800Version.V3, user, password);
	        ISetOutputExecutor setOutputExecutor = new SetOutputExecutor(context);
	        IGetOutputExecutor getOutputExecutor = new GetOutputExecutor(context);
	        IGetOutputsExecutor getOutputsExecutor = new GetOutputsExecutor(context);
	        IGetInputExecutor getInputExecutor = new GetInputExecutor(context);
	        IGetInputsExecutor getInputsExecutor = new GetInputsExecutor(context);
	        IGetAnalogInputExecutor getAnalogInputExecutor = new GetAnalogInputExecutor(context);
	        
	        return new IPX800v3(setOutputExecutor, getOutputExecutor, getOutputsExecutor, getInputExecutor, getInputsExecutor, getAnalogInputExecutor);
        }
	}
}
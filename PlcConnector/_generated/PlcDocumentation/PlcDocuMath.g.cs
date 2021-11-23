using System;

namespace PlcDocu.Plc
{
#if PLC_DOCU
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
	public abstract class Math
	{
		public object Sinus;
		public object NegativeSinus;
		public object Cosinus;
		public object Tangent;
		///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
		public Math()
		{
		}
	}
#endif
}
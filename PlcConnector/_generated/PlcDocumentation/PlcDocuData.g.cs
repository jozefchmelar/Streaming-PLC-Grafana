using System;

namespace PlcDocu.Plc
{
#if PLC_DOCU
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
	public abstract class Data
	{
		public object IncrementDouble;
		public object IncrementInt;
		public object DoubleValue;
		public object IntValue;
		public object Recipe;
		///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
		public Data()
		{
		}
	}
#endif
}
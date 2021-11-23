using System;

namespace PlcDocu.Plc
{
#if PLC_DOCU
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
	public abstract class MAIN
	{
		public Data Data;
		public Math Math;
		///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
		public MAIN()
		{
		}
	}
#endif
}
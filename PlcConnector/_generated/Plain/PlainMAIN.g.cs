using System;

namespace Plc
{
	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainMAIN : System.ComponentModel.INotifyPropertyChanged, Vortex.Connector.IPlain
	{
		PlainData _Data;
		public PlainData Data
		{
			get
			{
				return _Data;
			}

			set
			{
				if (_Data != value)
				{
					_Data = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Data)));
				}
			}
		}

		PlainMath _Math;
		public PlainMath Math
		{
			get
			{
				return _Math;
			}

			set
			{
				if (_Math != value)
				{
					_Math = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Math)));
				}
			}
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainMAIN()
		{
			_Data = new PlainData();
			_Math = new PlainMath();
		}
	}
}
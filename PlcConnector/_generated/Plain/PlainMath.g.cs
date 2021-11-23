using System;

namespace Plc
{
	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainMath : System.ComponentModel.INotifyPropertyChanged, Vortex.Connector.IPlain
	{
		System.Double _Sinus;
		public System.Double Sinus
		{
			get
			{
				return _Sinus;
			}

			set
			{
				if (_Sinus != value)
				{
					_Sinus = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Sinus)));
				}
			}
		}

		System.Double _NegativeSinus;
		public System.Double NegativeSinus
		{
			get
			{
				return _NegativeSinus;
			}

			set
			{
				if (_NegativeSinus != value)
				{
					_NegativeSinus = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(NegativeSinus)));
				}
			}
		}

		System.Double _Cosinus;
		public System.Double Cosinus
		{
			get
			{
				return _Cosinus;
			}

			set
			{
				if (_Cosinus != value)
				{
					_Cosinus = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Cosinus)));
				}
			}
		}

		System.Double _Tangent;
		public System.Double Tangent
		{
			get
			{
				return _Tangent;
			}

			set
			{
				if (_Tangent != value)
				{
					_Tangent = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Tangent)));
				}
			}
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainMath()
		{
		}
	}
}
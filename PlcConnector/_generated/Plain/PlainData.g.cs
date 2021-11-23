using System;

namespace Plc
{
	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainData : System.ComponentModel.INotifyPropertyChanged, Vortex.Connector.IPlain
	{
		System.Single _IncrementDouble;
		public System.Single IncrementDouble
		{
			get
			{
				return _IncrementDouble;
			}

			set
			{
				if (_IncrementDouble != value)
				{
					_IncrementDouble = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(IncrementDouble)));
				}
			}
		}

		System.Int16 _IncrementInt;
		public System.Int16 IncrementInt
		{
			get
			{
				return _IncrementInt;
			}

			set
			{
				if (_IncrementInt != value)
				{
					_IncrementInt = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(IncrementInt)));
				}
			}
		}

		System.Single _DoubleValue;
		public System.Single DoubleValue
		{
			get
			{
				return _DoubleValue;
			}

			set
			{
				if (_DoubleValue != value)
				{
					_DoubleValue = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(DoubleValue)));
				}
			}
		}

		System.Int16 _IntValue;
		public System.Int16 IntValue
		{
			get
			{
				return _IntValue;
			}

			set
			{
				if (_IntValue != value)
				{
					_IntValue = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(IntValue)));
				}
			}
		}

		System.String _Recipe;
		public System.String Recipe
		{
			get
			{
				return _Recipe;
			}

			set
			{
				if (_Recipe != value)
				{
					_Recipe = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Recipe)));
				}
			}
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainData()
		{
		}
	}
}
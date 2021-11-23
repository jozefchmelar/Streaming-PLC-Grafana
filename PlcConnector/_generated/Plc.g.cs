using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;
using PlcConnector.Properties;

[assembly: Vortex.Connector.Attributes.AssemblyPlcCounterPart("{\r\n  \"Types\": [\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"Data\",\r\n      \"Namespace\": \"Plc\",\r\n      \"TypeMetaInfo\": 1\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"Math\",\r\n      \"Namespace\": \"Plc\",\r\n      \"TypeMetaInfo\": 1\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"MAIN\",\r\n      \"Namespace\": \"Plc\",\r\n      \"TypeMetaInfo\": 3\r\n    }\r\n  ],\r\n  \"Name\": \"Plc\",\r\n  \"Namespace\": \"Plc\"\r\n}")]
#pragma warning disable SA1402, CS1591, CS0108, CS0067
namespace Plc
{
	public partial class PlcTwinController : Vortex.Connector.ITwinController, IPlcTwinController, IShadowPlcTwinController
	{
		public string Symbol
		{
			get;
			protected set;
		}

		public string HumanReadable
		{
			get
			{
				return PlcTwinController.Translator.Translate(_humanReadable).Interpolate(this);
			}

			protected set
			{
				_humanReadable = value;
			}
		}

		protected string _humanReadable;
		MAIN _MAIN;
		public MAIN MAIN
		{
			get
			{
				return _MAIN;
			}
		}

		IMAIN IPlcTwinController.MAIN
		{
			get
			{
				return MAIN;
			}
		}

		IShadowMAIN IShadowPlcTwinController.MAIN
		{
			get
			{
				return MAIN;
			}
		}

		public void LazyOnlineToShadow()
		{
			MAIN.LazyOnlineToShadow();
		}

		public void LazyShadowToOnline()
		{
			MAIN.LazyShadowToOnline();
		}

		public PlainPlcTwinController CreatePlainerType()
		{
			var cloned = new PlainPlcTwinController();
			cloned.MAIN = MAIN.CreatePlainerType();
			return cloned;
		}

		protected PlainPlcTwinController CreatePlainerType(PlainPlcTwinController cloned)
		{
			cloned.MAIN = MAIN.CreatePlainerType();
			return cloned;
		}

		public System.String AttributeName
		{
			get
			{
				return PlcTwinController.Translator.Translate(_AttributeName).Interpolate(this);
			}

			set
			{
				_AttributeName = value;
			}
		}

		private System.String _AttributeName
		{
			get;
			set;
		}

		public IPlcTwinController Online
		{
			get
			{
				return (IPlcTwinController)this;
			}
		}

		public IShadowPlcTwinController Shadow
		{
			get
			{
				return (IShadowPlcTwinController)this;
			}
		}

		public Vortex.Connector.IConnector Connector
		{
			get;
			set;
		}

		public PlcTwinController()
		{
			var adapter = new Vortex.Connector.ConnectorAdapter(typeof (DummyConnectorFactory));
			this.Connector = adapter.GetConnector(new object[]{});
			_MAIN = new MAIN(this.Connector, "", "MAIN");
		}

		public PlcTwinController(Vortex.Connector.ConnectorAdapter adapter, object[] parameters)
		{
			this.Connector = adapter.GetConnector(parameters);
			_MAIN = new MAIN(this.Connector, "", "MAIN");
		}

		public PlcTwinController(Vortex.Connector.ConnectorAdapter adapter)
		{
			this.Connector = adapter.GetConnector(adapter.Parameters);
			_MAIN = new MAIN(this.Connector, "", "MAIN");
		}

		public static string LocalizationDirectory
		{
			get;
			set;
		}

		private static Vortex.Localizations.Abstractions.ITranslator _translator
		{
			get;
			set;
		}

		internal static Vortex.Localizations.Abstractions.ITranslator Translator
		{
			get
			{
				if (_translator == null)
				{
					_translator = Vortex.Localizations.Abstractions.ITranslator.Get(typeof (Localizations));
				} return  _translator ; 

			}
		}
	}

	public partial interface IPlcTwinController
	{
		IMAIN MAIN
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		Plc.PlainPlcTwinController CreatePlainerType();
	}

	public partial interface IShadowPlcTwinController
	{
		IShadowMAIN MAIN
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		Plc.PlainPlcTwinController CreatePlainerType();
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainPlcTwinController : System.ComponentModel.INotifyPropertyChanged, Vortex.Connector.IPlain
	{
		PlainMAIN _MAIN;
		public PlainMAIN MAIN
		{
			get
			{
				return _MAIN;
			}

			set
			{
				if (_MAIN != value)
				{
					_MAIN = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(MAIN)));
				}
			}
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainPlcTwinController()
		{
			_MAIN = new PlainMAIN();
		}
	}
}
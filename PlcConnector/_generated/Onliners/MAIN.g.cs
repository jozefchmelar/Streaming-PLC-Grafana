using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace Plc
{
#pragma warning disable SA1402, CS1591, CS0108, CS0067
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "MAIN", "Plc", TypeComplexityEnum.Complex)]
	public partial class MAIN : Vortex.Connector.IVortexObject, IMAIN, IShadowMAIN, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		Data _Data;
		public Data Data
		{
			get
			{
				return _Data;
			}
		}

		IData IMAIN.Data
		{
			get
			{
				return Data;
			}
		}

		IShadowData IShadowMAIN.Data
		{
			get
			{
				return Data;
			}
		}

		Math _Math;
		public Math Math
		{
			get
			{
				return _Math;
			}
		}

		IMath IMAIN.Math
		{
			get
			{
				return Math;
			}
		}

		IShadowMath IShadowMAIN.Math
		{
			get
			{
				return Math;
			}
		}

		public void LazyOnlineToShadow()
		{
			Data.LazyOnlineToShadow();
			Math.LazyOnlineToShadow();
		}

		public void LazyShadowToOnline()
		{
			Data.LazyShadowToOnline();
			Math.LazyShadowToOnline();
		}

		public PlainMAIN CreatePlainerType()
		{
			var cloned = new PlainMAIN();
			cloned.Data = Data.CreatePlainerType();
			cloned.Math = Math.CreatePlainerType();
			return cloned;
		}

		protected PlainMAIN CreatePlainerType(PlainMAIN cloned)
		{
			cloned.Data = Data.CreatePlainerType();
			cloned.Math = Math.CreatePlainerType();
			return cloned;
		}

		partial void PexPreConstructor(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail);
		partial void PexPreConstructorParameterless();
		private System.Collections.Generic.List<Vortex.Connector.IVortexObject> @Children
		{
			get;
			set;
		}

		public System.Collections.Generic.IEnumerable<Vortex.Connector.IVortexObject> @GetChildren()
		{
			return this.@Children;
		}

		public void AddChild(Vortex.Connector.IVortexObject vortexObject)
		{
			this.@Children.Add(vortexObject);
		}

		private System.Collections.Generic.List<Vortex.Connector.IVortexElement> Kids
		{
			get;
			set;
		}

		public System.Collections.Generic.IEnumerable<Vortex.Connector.IVortexElement> GetKids()
		{
			return this.Kids;
		}

		public void AddKid(Vortex.Connector.IVortexElement vortexElement)
		{
			this.Kids.Add(vortexElement);
		}

		partial void PexConstructor(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail);
		partial void PexConstructorParameterless();
		protected Vortex.Connector.IVortexObject @Parent
		{
			get;
			set;
		}

		public Vortex.Connector.IVortexObject GetParent()
		{
			return this.@Parent;
		}

		private System.Collections.Generic.List<Vortex.Connector.IValueTag> @ValueTags
		{
			get;
			set;
		}

		public System.Collections.Generic.IEnumerable<Vortex.Connector.IValueTag> GetValueTags()
		{
			return this.@ValueTags;
		}

		public void AddValueTag(Vortex.Connector.IValueTag valueTag)
		{
			this.@ValueTags.Add(valueTag);
		}

		protected Vortex.Connector.IConnector @Connector
		{
			get;
			set;
		}

		public Vortex.Connector.IConnector GetConnector()
		{
			return this.@Connector;
		}

		public void FlushPlainToOnline(Plc.PlainMAIN source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(Plc.PlainMAIN source)
		{
			source.CopyPlainToShadow(this);
		}

		public void FlushShadowToOnline()
		{
			this.LazyShadowToOnline();
			this.Write();
		}

		public void FlushOnlineToShadow()
		{
			this.Read();
			this.LazyOnlineToShadow();
		}

		public void FlushOnlineToPlain(Plc.PlainMAIN source)
		{
			this.Read();
			source.CopyCyclicToPlain(this);
		}

		protected System.String @SymbolTail
		{
			get;
			set;
		}

		public System.String GetSymbolTail()
		{
			return this.SymbolTail;
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

		public MAIN(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@ValueTags = new System.Collections.Generic.List<Vortex.Connector.IValueTag>();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			this.Kids = new System.Collections.Generic.List<Vortex.Connector.IVortexElement>();
			this.@Children = new System.Collections.Generic.List<Vortex.Connector.IVortexObject>();
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			_Data = new Data(this, "", "Data");
			_Math = new Math(this, "", "Math");
			AttributeName = "";
			parent.AddChild(this);
			parent.AddKid(this);
			PexConstructor(parent, readableTail, symbolTail);
		}

		public MAIN()
		{
			PexPreConstructorParameterless();
			_Data = new Data();
			_Math = new Math();
			AttributeName = "";
			PexConstructorParameterless();
		}
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainMAIN
	{
		public void CopyPlainToCyclic(Plc.MAIN target)
		{
			Data.CopyPlainToCyclic(target.Data);
			Math.CopyPlainToCyclic(target.Math);
		}

		public void CopyPlainToCyclic(Plc.IMAIN target)
		{
			this.CopyPlainToCyclic((Plc.MAIN)target);
		}

		public void CopyPlainToShadow(Plc.MAIN target)
		{
			Data.CopyPlainToShadow(target.Data);
			Math.CopyPlainToShadow(target.Math);
		}

		public void CopyPlainToShadow(Plc.IShadowMAIN target)
		{
			this.CopyPlainToShadow((Plc.MAIN)target);
		}

		public void CopyCyclicToPlain(Plc.MAIN source)
		{
			Data.CopyCyclicToPlain(source.Data);
			Math.CopyCyclicToPlain(source.Math);
		}

		public void CopyCyclicToPlain(Plc.IMAIN source)
		{
			this.CopyCyclicToPlain((Plc.MAIN)source);
		}

		public void CopyShadowToPlain(Plc.MAIN source)
		{
			Data.CopyShadowToPlain(source.Data);
			Math.CopyShadowToPlain(source.Math);
		}

		public void CopyShadowToPlain(Plc.IShadowMAIN source)
		{
			this.CopyShadowToPlain((Plc.MAIN)source);
		}
	}
}
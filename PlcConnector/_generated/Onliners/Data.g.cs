using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace Plc
{
#pragma warning disable SA1402, CS1591, CS0108, CS0067
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "Data", "Plc", TypeComplexityEnum.Complex)]
	public partial class Data : Vortex.Connector.IVortexObject, IData, IShadowData, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		Vortex.Connector.ValueTypes.OnlinerReal _IncrementDouble;
		public Vortex.Connector.ValueTypes.OnlinerReal IncrementDouble
		{
			get
			{
				return _IncrementDouble;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineReal IData.IncrementDouble
		{
			get
			{
				return IncrementDouble;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowReal IShadowData.IncrementDouble
		{
			get
			{
				return IncrementDouble;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerInt _IncrementInt;
		public Vortex.Connector.ValueTypes.OnlinerInt IncrementInt
		{
			get
			{
				return _IncrementInt;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineInt IData.IncrementInt
		{
			get
			{
				return IncrementInt;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowInt IShadowData.IncrementInt
		{
			get
			{
				return IncrementInt;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerReal _DoubleValue;
		public Vortex.Connector.ValueTypes.OnlinerReal DoubleValue
		{
			get
			{
				return _DoubleValue;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineReal IData.DoubleValue
		{
			get
			{
				return DoubleValue;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowReal IShadowData.DoubleValue
		{
			get
			{
				return DoubleValue;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerInt _IntValue;
		public Vortex.Connector.ValueTypes.OnlinerInt IntValue
		{
			get
			{
				return _IntValue;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineInt IData.IntValue
		{
			get
			{
				return IntValue;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowInt IShadowData.IntValue
		{
			get
			{
				return IntValue;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerString _Recipe;
		public Vortex.Connector.ValueTypes.OnlinerString Recipe
		{
			get
			{
				return _Recipe;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineString IData.Recipe
		{
			get
			{
				return Recipe;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowString IShadowData.Recipe
		{
			get
			{
				return Recipe;
			}
		}

		public void LazyOnlineToShadow()
		{
			IncrementDouble.Shadow = IncrementDouble.LastValue;
			IncrementInt.Shadow = IncrementInt.LastValue;
			DoubleValue.Shadow = DoubleValue.LastValue;
			IntValue.Shadow = IntValue.LastValue;
			Recipe.Shadow = Recipe.LastValue;
		}

		public void LazyShadowToOnline()
		{
			IncrementDouble.Cyclic = IncrementDouble.Shadow;
			IncrementInt.Cyclic = IncrementInt.Shadow;
			DoubleValue.Cyclic = DoubleValue.Shadow;
			IntValue.Cyclic = IntValue.Shadow;
			Recipe.Cyclic = Recipe.Shadow;
		}

		public PlainData CreatePlainerType()
		{
			var cloned = new PlainData();
			return cloned;
		}

		protected PlainData CreatePlainerType(PlainData cloned)
		{
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

		public void FlushPlainToOnline(Plc.PlainData source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(Plc.PlainData source)
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

		public void FlushOnlineToPlain(Plc.PlainData source)
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

		public Data(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
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
			_IncrementDouble = @Connector.Online.Adapter.CreateREAL(this, "", "IncrementDouble");
			_IncrementInt = @Connector.Online.Adapter.CreateINT(this, "", "IncrementInt");
			_DoubleValue = @Connector.Online.Adapter.CreateREAL(this, "", "DoubleValue");
			_IntValue = @Connector.Online.Adapter.CreateINT(this, "", "IntValue");
			_Recipe = @Connector.Online.Adapter.CreateSTRING(this, "", "Recipe");
			AttributeName = "";
			parent.AddChild(this);
			parent.AddKid(this);
			PexConstructor(parent, readableTail, symbolTail);
		}

		public Data()
		{
			PexPreConstructorParameterless();
			_IncrementDouble = Vortex.Connector.IConnectorFactory.CreateREAL();
			_IncrementInt = Vortex.Connector.IConnectorFactory.CreateINT();
			_DoubleValue = Vortex.Connector.IConnectorFactory.CreateREAL();
			_IntValue = Vortex.Connector.IConnectorFactory.CreateINT();
			_Recipe = Vortex.Connector.IConnectorFactory.CreateSTRING();
			AttributeName = "";
			PexConstructorParameterless();
		}
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainData
	{
		public void CopyPlainToCyclic(Plc.Data target)
		{
			target.IncrementDouble.Cyclic = IncrementDouble;
			target.IncrementInt.Cyclic = IncrementInt;
			target.DoubleValue.Cyclic = DoubleValue;
			target.IntValue.Cyclic = IntValue;
			target.Recipe.Cyclic = Recipe;
		}

		public void CopyPlainToCyclic(Plc.IData target)
		{
			this.CopyPlainToCyclic((Plc.Data)target);
		}

		public void CopyPlainToShadow(Plc.Data target)
		{
			target.IncrementDouble.Shadow = IncrementDouble;
			target.IncrementInt.Shadow = IncrementInt;
			target.DoubleValue.Shadow = DoubleValue;
			target.IntValue.Shadow = IntValue;
			target.Recipe.Shadow = Recipe;
		}

		public void CopyPlainToShadow(Plc.IShadowData target)
		{
			this.CopyPlainToShadow((Plc.Data)target);
		}

		public void CopyCyclicToPlain(Plc.Data source)
		{
			IncrementDouble = source.IncrementDouble.LastValue;
			IncrementInt = source.IncrementInt.LastValue;
			DoubleValue = source.DoubleValue.LastValue;
			IntValue = source.IntValue.LastValue;
			Recipe = source.Recipe.LastValue;
		}

		public void CopyCyclicToPlain(Plc.IData source)
		{
			this.CopyCyclicToPlain((Plc.Data)source);
		}

		public void CopyShadowToPlain(Plc.Data source)
		{
			IncrementDouble = source.IncrementDouble.Shadow;
			IncrementInt = source.IncrementInt.Shadow;
			DoubleValue = source.DoubleValue.Shadow;
			IntValue = source.IntValue.Shadow;
			Recipe = source.Recipe.Shadow;
		}

		public void CopyShadowToPlain(Plc.IShadowData source)
		{
			this.CopyShadowToPlain((Plc.Data)source);
		}
	}
}
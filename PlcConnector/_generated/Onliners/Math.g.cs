using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace Plc
{
#pragma warning disable SA1402, CS1591, CS0108, CS0067
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "Math", "Plc", TypeComplexityEnum.Complex)]
	public partial class Math : Vortex.Connector.IVortexObject, IMath, IShadowMath, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		Vortex.Connector.ValueTypes.OnlinerLReal _Sinus;
		public Vortex.Connector.ValueTypes.OnlinerLReal Sinus
		{
			get
			{
				return _Sinus;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineLReal IMath.Sinus
		{
			get
			{
				return Sinus;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowLReal IShadowMath.Sinus
		{
			get
			{
				return Sinus;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerLReal _NegativeSinus;
		public Vortex.Connector.ValueTypes.OnlinerLReal NegativeSinus
		{
			get
			{
				return _NegativeSinus;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineLReal IMath.NegativeSinus
		{
			get
			{
				return NegativeSinus;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowLReal IShadowMath.NegativeSinus
		{
			get
			{
				return NegativeSinus;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerLReal _Cosinus;
		public Vortex.Connector.ValueTypes.OnlinerLReal Cosinus
		{
			get
			{
				return _Cosinus;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineLReal IMath.Cosinus
		{
			get
			{
				return Cosinus;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowLReal IShadowMath.Cosinus
		{
			get
			{
				return Cosinus;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerLReal _Tangent;
		public Vortex.Connector.ValueTypes.OnlinerLReal Tangent
		{
			get
			{
				return _Tangent;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineLReal IMath.Tangent
		{
			get
			{
				return Tangent;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowLReal IShadowMath.Tangent
		{
			get
			{
				return Tangent;
			}
		}

		public void LazyOnlineToShadow()
		{
			Sinus.Shadow = Sinus.LastValue;
			NegativeSinus.Shadow = NegativeSinus.LastValue;
			Cosinus.Shadow = Cosinus.LastValue;
			Tangent.Shadow = Tangent.LastValue;
		}

		public void LazyShadowToOnline()
		{
			Sinus.Cyclic = Sinus.Shadow;
			NegativeSinus.Cyclic = NegativeSinus.Shadow;
			Cosinus.Cyclic = Cosinus.Shadow;
			Tangent.Cyclic = Tangent.Shadow;
		}

		public PlainMath CreatePlainerType()
		{
			var cloned = new PlainMath();
			return cloned;
		}

		protected PlainMath CreatePlainerType(PlainMath cloned)
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

		public void FlushPlainToOnline(Plc.PlainMath source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(Plc.PlainMath source)
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

		public void FlushOnlineToPlain(Plc.PlainMath source)
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

		public Math(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
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
			_Sinus = @Connector.Online.Adapter.CreateLREAL(this, "", "Sinus");
			_NegativeSinus = @Connector.Online.Adapter.CreateLREAL(this, "", "NegativeSinus");
			_Cosinus = @Connector.Online.Adapter.CreateLREAL(this, "", "Cosinus");
			_Tangent = @Connector.Online.Adapter.CreateLREAL(this, "", "Tangent");
			AttributeName = "";
			parent.AddChild(this);
			parent.AddKid(this);
			PexConstructor(parent, readableTail, symbolTail);
		}

		public Math()
		{
			PexPreConstructorParameterless();
			_Sinus = Vortex.Connector.IConnectorFactory.CreateLREAL();
			_NegativeSinus = Vortex.Connector.IConnectorFactory.CreateLREAL();
			_Cosinus = Vortex.Connector.IConnectorFactory.CreateLREAL();
			_Tangent = Vortex.Connector.IConnectorFactory.CreateLREAL();
			AttributeName = "";
			PexConstructorParameterless();
		}
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainMath
	{
		public void CopyPlainToCyclic(Plc.Math target)
		{
			target.Sinus.Cyclic = Sinus;
			target.NegativeSinus.Cyclic = NegativeSinus;
			target.Cosinus.Cyclic = Cosinus;
			target.Tangent.Cyclic = Tangent;
		}

		public void CopyPlainToCyclic(Plc.IMath target)
		{
			this.CopyPlainToCyclic((Plc.Math)target);
		}

		public void CopyPlainToShadow(Plc.Math target)
		{
			target.Sinus.Shadow = Sinus;
			target.NegativeSinus.Shadow = NegativeSinus;
			target.Cosinus.Shadow = Cosinus;
			target.Tangent.Shadow = Tangent;
		}

		public void CopyPlainToShadow(Plc.IShadowMath target)
		{
			this.CopyPlainToShadow((Plc.Math)target);
		}

		public void CopyCyclicToPlain(Plc.Math source)
		{
			Sinus = source.Sinus.LastValue;
			NegativeSinus = source.NegativeSinus.LastValue;
			Cosinus = source.Cosinus.LastValue;
			Tangent = source.Tangent.LastValue;
		}

		public void CopyCyclicToPlain(Plc.IMath source)
		{
			this.CopyCyclicToPlain((Plc.Math)source);
		}

		public void CopyShadowToPlain(Plc.Math source)
		{
			Sinus = source.Sinus.Shadow;
			NegativeSinus = source.NegativeSinus.Shadow;
			Cosinus = source.Cosinus.Shadow;
			Tangent = source.Tangent.Shadow;
		}

		public void CopyShadowToPlain(Plc.IShadowMath source)
		{
			this.CopyShadowToPlain((Plc.Math)source);
		}
	}
}
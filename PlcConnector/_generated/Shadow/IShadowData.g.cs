using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace Plc
{
	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowData : Vortex.Connector.IVortexShadowObject
	{
		Vortex.Connector.ValueTypes.Shadows.IShadowReal IncrementDouble
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowInt IncrementInt
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowReal DoubleValue
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowInt IntValue
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowString Recipe
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		Plc.PlainData CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(Plc.PlainData source);
	}
}
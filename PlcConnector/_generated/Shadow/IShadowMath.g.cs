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
	public partial interface IShadowMath : Vortex.Connector.IVortexShadowObject
	{
		Vortex.Connector.ValueTypes.Shadows.IShadowLReal Sinus
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowLReal NegativeSinus
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowLReal Cosinus
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowLReal Tangent
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		Plc.PlainMath CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(Plc.PlainMath source);
	}
}
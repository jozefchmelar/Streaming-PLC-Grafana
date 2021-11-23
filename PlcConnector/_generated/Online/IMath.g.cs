using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace Plc
{
	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IMath : Vortex.Connector.IVortexOnlineObject
	{
		Vortex.Connector.ValueTypes.Online.IOnlineLReal Sinus
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineLReal NegativeSinus
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineLReal Cosinus
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineLReal Tangent
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		Plc.PlainMath CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(Plc.PlainMath source);
		void FlushOnlineToPlain(Plc.PlainMath source);
	}
}
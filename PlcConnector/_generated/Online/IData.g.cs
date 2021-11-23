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
	public partial interface IData : Vortex.Connector.IVortexOnlineObject
	{
		Vortex.Connector.ValueTypes.Online.IOnlineReal IncrementDouble
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineInt IncrementInt
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineReal DoubleValue
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineInt IntValue
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineString Recipe
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		Plc.PlainData CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(Plc.PlainData source);
		void FlushOnlineToPlain(Plc.PlainData source);
	}
}
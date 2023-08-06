using System.Collections.Generic;

namespace ASP.NET_API.Hypermedia.Abstract
{
	public interface ISuportHyperMedia
	{
		List<HyperMediaLink> Links { get; set; }
	}
}

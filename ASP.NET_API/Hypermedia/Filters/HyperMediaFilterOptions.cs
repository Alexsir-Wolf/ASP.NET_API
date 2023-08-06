using ASP.NET_API.Hypermedia.Abstract;
using System.Collections.Generic;

namespace ASP.NET_API.Hypermedia.Filters
{
	public class HyperMediaFilterOptions
	{
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}

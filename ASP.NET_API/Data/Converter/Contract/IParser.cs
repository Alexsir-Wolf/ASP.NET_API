﻿using System.Collections.Generic;

namespace ASP.NET_API.Data.Converter.Contract
{
	public interface IParser<Origem, Destino>
	{
		Destino Parse(Origem origem);
		List<Destino> Parse(List<Origem> origem);
	}
}

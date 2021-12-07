using HttpServerAsp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpServerAsp.Interfaces
{
	public interface IBaseServerController
	{
		Input input { get; set; }
		Output output { get; set; }
	}
}

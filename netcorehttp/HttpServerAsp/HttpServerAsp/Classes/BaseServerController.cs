using HttpServerAsp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpServerAsp.Classes
{
	public class BaseServerController : IBaseServerController
	{
		public BaseServerController()
		{
			input = new Input();
			output = new Output();
		}


		public Input input { get; set; }
		public Output output { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HttpServerAsp.Classes;
using HttpServerAsp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HttpServerAsp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ServerController : ControllerBase
    {
		private readonly ILogger<ServerController> _logger;
		private readonly ISerializer _serializer;
        private readonly IBaseServerController _baseServerController;

        private Input _input;
        private Output _output;

        public ServerController(ILogger<ServerController> logger, ISerializer serializer, IBaseServerController baseServerController)
		{
			_logger = logger;
			_serializer = serializer;
            _baseServerController = baseServerController;

            _input = _baseServerController.input;
            _output = _baseServerController.output;
		}

		[HttpGet]
		[Route("ping")]
		public IActionResult Index()
		{
			return Ok(true);
		}

        [HttpGet]
        [Route("stop")]
        public void Stop()
		{
            Environment.Exit(0);
		}

        [HttpPost]
        [Route("postinputdata")]
        public async Task<IActionResult> PostInputData()
		{
            using var streamReader = new StreamReader(Request.Body);
            var body = await streamReader.ReadToEndAsync();
            body = body.Split("\r\n")[3];

            try
			{
                _input = _serializer.DeserializeJson<Input>(body);
                _output = _input.Process();

                //save
                _baseServerController.input = _input;
                _baseServerController.output = _output;
			}
            catch(Exception ex)
			{
                return Ok(ex.Message + " " + body);
			}
            return Ok(body);
        }

        [HttpGet]
        [Route("getanswer")]
        public IActionResult GetAnswer()
        {
            try
            {
                var response = _serializer.SerializeJson(_output);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
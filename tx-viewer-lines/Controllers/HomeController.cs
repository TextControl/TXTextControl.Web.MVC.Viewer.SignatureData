using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using tx_viewer_lines.Models;
using TXTextControl.Web.MVC.DocumentViewer.Models;

namespace tx_viewer_lines.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}

		public IActionResult Index() {
			return View();
		}

		public IActionResult Privacy() {
			return View();
		}

		[HttpPost]
		public string HandleSignature([FromBody] SignatureData data)
		{
			// convert data.SignatureLines to a JSON string camel case
			// and return it to the client
			return JsonConvert.SerializeObject(data.SignatureLines, 
				Formatting.Indented, 
				new JsonSerializerSettings { 
					ContractResolver = new CamelCasePropertyNamesContractResolver()
				});
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
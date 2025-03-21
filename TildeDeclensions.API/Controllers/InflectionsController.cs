using Microsoft.AspNetCore.Mvc;
using TildeDeclensions.Business.DeclensionServices;
using TildeDeclensions.Business;

namespace TildeDeclensions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InflectionsController : ControllerBase
    {
        private IDeclensionHandler _handler;
        public InflectionsController(Func<IDeclensionHandler> handlerFactory)
        {
            _handler = handlerFactory();
        }

        [HttpGet]
        public IActionResult GetInflections(string word)
        {
            try
            {
                return Ok(_handler.Handle(word));
            }
            catch (UndeterminedDeclensionException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception)
            {
                return BadRequest(new { error = "An unexpected error occurred." });
            }
        }
    }
}

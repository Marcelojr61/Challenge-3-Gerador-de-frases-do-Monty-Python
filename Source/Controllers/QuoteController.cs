
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;

        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        // GET api/quote
        [HttpGet]
        public ActionResult<QuoteView> GetAnyQuote()
        {
            var quote = _service.GetAnyQuote();

            return new QuoteView { Actor = quote.Actor, Id = quote.Id, Detail = quote.Detail };
        }

        // GET api/quote/{actor}
        [HttpGet("{actor}")]
        public ActionResult<QuoteView> GetAnyQuote(string actor)
        {
            var quote = _service.GetAnyQuote(actor);

            if (quote == null)
            {
                return NotFound();
            }
            else
            {
                return new QuoteView { Actor = quote.Actor, Id = quote.Id, Detail = quote.Detail };
            }             
            
                        
        }

    }
}

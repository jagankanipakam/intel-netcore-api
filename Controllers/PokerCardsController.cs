using System;
using System.Collections.Generic;
using System.Linq;
using intel_netcore_api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace intel_netcore_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokerCardsController : ControllerBase
    {
        private readonly ILogger<PokerCardsController> _logger;
        private readonly PokerCardsService _pokerCardsService;
        public PokerCardsController(ILogger<PokerCardsController> logger, PokerCardsService pokerCardsService)
        {
            _logger = logger;
            _pokerCardsService = pokerCardsService;
        }

        [HttpPost("sortcards")]
        public IActionResult SortCards(List<string> cards)
        {
            try
            {
                var result = this._pokerCardsService.SortCards(cards);
                return Ok(new { status = "SUCCESS", response = result });

            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                return StatusCode(500);
            }
        }
    }
}

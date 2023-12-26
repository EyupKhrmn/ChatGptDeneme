using AIService.CQRS.AskQuestionCommand;
using AIService.Entities;
using AIService.GeneralRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenAI_API;
using OpenAI_API.Completions;

namespace AIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GptController : ControllerBase
    {

        private readonly IGeneralRepository _generalRepository; 
        private readonly IMediator _mediator;

        public GptController(IGeneralRepository generalRepository, IMediator mediator)
        {
            _generalRepository = generalRepository;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("ChatGPT")]
        public async Task<IActionResult> AskQuestionForYourself([FromQuery] AskQuestionRequest query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("AskRandonQuestion")]
        public async Task<IActionResult> AskRandomQuestion([FromQuery] AskRandomQuestionRequest query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}

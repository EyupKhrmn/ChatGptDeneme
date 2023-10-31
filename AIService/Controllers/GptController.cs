using AIService.Entities;
using AIService.GeneralRepository;
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

        public GptController(IGeneralRepository generalRepository)
        {
            _generalRepository = generalRepository;
        }

        [HttpGet]
        [Route("ChatGPT")]
        public async Task<IActionResult> UseChatGpt(string query)
        {
            var user = await _generalRepository.Query<User>().FirstOrDefaultAsync(_=>_.Id == 61); // Gelen kullanıcının ıd si gelecek.
            
            var baseQuery = $"Ben 85 kilo, 175 boyunda, 21 yaşında, erkek cinsiyetli biriyim. ";

            string sendQuery = $"{baseQuery} {query}";

            string outputResult = await _generalRepository.AskGpt(sendQuery);

            return Ok(outputResult);
        }
    }
}

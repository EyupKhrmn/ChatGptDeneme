using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace AIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GptController : ControllerBase
    {
        [HttpGet]
        [Route("ChatGPT")]
        public async Task<IActionResult> UseChatGpt(string query)
        {
            string outputResult = "";

            var opanai = new OpenAIAPI("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");
            CompletionRequest request = new CompletionRequest();
            request.Prompt = query;
            request.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = await opanai.Completions.CreateCompletionAsync(request);

            foreach (var completion in completions.Completions)
            {
                outputResult += completion.Text;
            }

            return Ok(outputResult);
        }
    }
}

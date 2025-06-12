using Bl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dal.models;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromptController : ControllerBase
    {
        private readonly IPromptService _promptService;

        public PromptController(IPromptService promptService)
        {
            _promptService = promptService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitPromptAsync([FromBody] Prompt prompt)
        {
            var lesson = await _promptService.SubmitPrompt(prompt); // המתנה לפונקציה אסינכרונית

            return Ok(lesson);       }


        
    }
}

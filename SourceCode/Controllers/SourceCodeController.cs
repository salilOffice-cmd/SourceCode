using Microsoft.AspNetCore.Mvc;
using SourceCode.Services;

namespace SourceCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SourceCodeController : ControllerBase
    {

        private readonly SourceCodeService SourceCodeService;

        public SourceCodeController()
        {
            SourceCodeService = new SourceCodeService();    
        }

        [HttpGet("{url}")]
        public async Task<IActionResult> GetSourceCodeAsync([FromRoute] string url)
        {
            var gotSourceCode = await SourceCodeService.GetSourceCodeService(url);
            return Ok(gotSourceCode);
        }
    }
}
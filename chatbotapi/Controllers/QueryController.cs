using Microsoft.AspNetCore.Mvc;
using chatbotapi.Models;

namespace chatbotapi.Controllers;

[ApiController]
[Route("api")]
public class QueryController : ControllerBase
{
    private readonly ChatbotContext _ChatbotContext;

    public QueryController(ChatbotContext chatbotContext)
    {
        this._ChatbotContext = chatbotContext;
    }

    [HttpGet, Route("")]
    public IActionResult GetAll()
    {
        var query = this._ChatbotContext.Queries.ToList();
        return Ok(query);
    }
}

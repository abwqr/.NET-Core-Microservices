using Microsoft.AspNetCore.Mvc;
using tutoroo.Models;

namespace tutoroo.Controllers;

[ApiController]
[Route("api")]
public class EmployeeController : ControllerBase
{

    private readonly HmsContext _HmsContext;

    public EmployeeController(HmsContext hmsContext)
    {
        this._HmsContext = hmsContext;
    }

    [HttpGet, Route("")]
    public IActionResult GetAll()
    {
        var employee = this._HmsContext.Employees.ToList();
        return Ok(employee);
    }
}

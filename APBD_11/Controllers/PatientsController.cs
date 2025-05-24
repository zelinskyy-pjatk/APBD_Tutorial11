using APBD_11.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IDbService _service;
    public PatientsController(IDbService service) => _service = service;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientDetails(int id)
    {
        var result = await _service.GetPatientDetailsAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }
}
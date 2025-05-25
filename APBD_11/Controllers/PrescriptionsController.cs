using APBD_11.DTOs;
using APBD_11.Models;
using APBD_11.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APBD_11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IDbService _service;
    public PrescriptionsController(IDbService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] AddPrescriptionRequest request)
    {
        try
        {
            await _service.AddPrescriptionAsync(request);
            return Created();
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
}
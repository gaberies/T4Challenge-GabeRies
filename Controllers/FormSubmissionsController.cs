using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T4Challenge.Data;
using T4Challenge.Models;

[Route("api/[controller]")]
[ApiController]
public class FormSubmissionsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FormSubmissionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/FormSubmissions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FormSubmission>>> GetFormSubmissions()
    {
        return await _context.FormSubmissions.ToListAsync();
    }

    // POST: api/FormSubmissions
    [HttpPost]
    public async Task<ActionResult<FormSubmission>> PostFormSubmission([FromBody] FormSubmission formData)
    {
        try
        {
            _context.FormSubmissions.Add(formData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormSubmissions", new { id = formData.Id }, formData);
        }
        catch (Exception ex)
        {
            // Log the exception
            return BadRequest($"Error: {ex.Message}");
        }
    }
}

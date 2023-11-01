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

    [HttpPost]
    public async Task<ActionResult<FormSubmission>> PostFormSubmission([FromBody] FormSubmission formData)
    {
        try
        {
            formData.SubmissionDate = DateTime.Now;
            _context.FormSubmissions.Add(formData);
            await _context.SaveChangesAsync();

            // Save dynamic fields separately
            var dynamicFields = formData.DynamicFields;
            if (dynamicFields != null && dynamicFields.Count > 0)
            {
                Console.WriteLine($"Dynamic Fields Count: {dynamicFields.Count}");
                foreach (var field in dynamicFields)
                {
                    field.Id = Guid.NewGuid();
                    Console.WriteLine($"Adding dynamic field: {field.FieldName} - {field.FieldValue}");
                    field.FormSubmissionId = formData.Id;
                    _context.DynamicFields.Add(field);
                }
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetFormSubmissions", new { id = formData.Id }, formData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest($"Error: {ex.Message}");
        }
    }

}

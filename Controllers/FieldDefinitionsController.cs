using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T4Challenge.Data;
using T4Challenge.Models;

[Route("api/[controller]")]
[ApiController]
public class FieldDefinitionsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FieldDefinitionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    private bool FieldDefinitionExists(int id)
    {
        return _context.FormSubmissions.Any(e => e.Id == id);
    }

    [HttpGet]
    public ActionResult<IEnumerable<FieldDefinition>> GetFieldDefinitions()
    {
        try
        {
            var fieldDefinitions = _context.FieldDefinitions.ToList();
            return Ok(fieldDefinitions);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<FieldDefinition>> PostFieldDefinition([FromBody] FieldDefinition newField)
    {
        try
        {
            // Add validation logic if needed

            _context.FieldDefinitions.Add(newField);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFieldDefinitions", new { id = newField.Id }, newField);
        }
        catch (Exception ex)
        {
            // Log the exception
            return BadRequest($"Error: {ex.Message}");
        }
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<FieldDefinition>> PutFieldDefinition(int id, [FromBody] FieldDefinition fieldDefinition)
    {
        if (id != fieldDefinition.Id)
        {
            return BadRequest();
        }

        _context.Entry(fieldDefinition).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FieldDefinitionExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok(fieldDefinition); // Return the updated field definition as JSON
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFieldDefinition(int id)
    {
        try
        {
            var fieldDefinition = await _context.FieldDefinitions.FindAsync(id);
            if (fieldDefinition == null)
            {
                return NotFound();
            }

            _context.FieldDefinitions.Remove(fieldDefinition);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
}

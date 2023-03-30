using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBoletimServer.API.Controllers;

[Route("Person")]
[ApiController]
public class PersonController : ControllerBase
{
    private IPersonService _person;
    public PersonController(IPersonService person)
    {
        _person = person;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonById(int id)
    {
        try
        {
            var person = await _person.GetById(id);
            if (person != null) return StatusCode(200, person);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("List/{roleId}")]
    public async Task<IActionResult> GetPersonByRoleId(int roleId)
    {
        try
        {
            var person = await _person.GetPersonByRoleId(roleId);
            if (person != null) return StatusCode(200, person);
            return StatusCode(404, "Não encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("Insert")]
    public async Task<IActionResult> InsertPerson(Person person)
    {
        try
        {
            var result = await _person.Insert(person);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("Update")]
    public async Task<IActionResult> UpdatePerson(Person person)
    {
        try
        {
            var result = await _person.Update(person);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeletePerson(Person person)
    {
        try
        {
            var result = await _person.Delete(person);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}/Delete")]
    public async Task<IActionResult> DeletePersonById(int id)
    {
        try
        {
            var result = await _person.DeleteById(id);
            return StatusCode(result.Code, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


}
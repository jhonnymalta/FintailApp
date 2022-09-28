using Microsoft.AspNetCore.Mvc;
using tailfinAPI.Data;
using tailfinAPI.models;

namespace tailfinAPI.Controllers;

[ApiController]
[Route("categories")]
public class CategoryController : ControllerBase
{

    [HttpGet("")]
    public IActionResult Get(
        [FromServices] AppDbContext context
    )
    {
        return Ok(context.categorias.ToList());
    }

    [HttpGet("/{id:int}")]
    public IActionResult GetById(
        [FromRoute] int id,
        [FromServices] AppDbContext context
    )
    {
        var categoria = context.categorias.FirstOrDefault(x => x.ID == id);
        if (categoria is null)
        {
            return StatusCode(404, "Categoria não cadastrada!");
        }
        return Ok(categoria);
    }

    [HttpPost("")]
    public IActionResult Post(
        [FromServices] AppDbContext context,
        [FromBody] Category model
    )
    {
        context.categorias.Add(model);
        context.SaveChanges();
        return StatusCode(201, model);
    }
    [HttpPut("/{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody] Category model,
        [FromServices] AppDbContext context
    )
    {
        var targetCategory = context.categorias.FirstOrDefault(x => x.ID == id);
        if (targetCategory is null)
        {
            return StatusCode(404, "Categoria não encontrada");
        }
        targetCategory.Title = model.Title;
        targetCategory.Description = model.Description;

        context.categorias.Update(targetCategory);
        context.SaveChanges();
        return StatusCode(200, targetCategory);

    }

    [HttpDelete("/{id:int}")]
    public IActionResult Delete(
        [FromRoute] int id,
        [FromServices] AppDbContext context
    )
    {
        var CategoryToDelete = context.categorias.FirstOrDefault(x => x.ID == id);
        if (CategoryToDelete is null) return StatusCode(404, "Categoria não encontrada!");
        context.categorias.Remove(CategoryToDelete);
        context.SaveChanges();

        return StatusCode(200, CategoryToDelete);
    }


}
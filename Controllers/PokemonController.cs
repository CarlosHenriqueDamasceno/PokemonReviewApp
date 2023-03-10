using Microsoft.AspNetCore.Mvc;
using Models;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : Controller
{
    private readonly IPokemonRepository _repository;
    public PokemonController(IPokemonRepository repository)
    {
        _repository = repository;

    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetPokemons()
    {
        var pokemons = _repository.GetPokemons();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(pokemons);
    }
}
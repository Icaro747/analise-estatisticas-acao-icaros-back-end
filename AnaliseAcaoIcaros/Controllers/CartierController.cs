using AnaliseAcaoIcaros.Data;
using AnaliseAcaoIcaros.Data.Dtos;
using AnaliseAcaoIcaros.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnaliseAcaoIcaros.Controllers;

[ApiController]
[Route("[controller]")]
public class CartierController : ControllerBase
{

    private AnaliseAcaoContext _context;
    private IMapper _mapper;

    public CartierController(AnaliseAcaoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateCarteira([FromBody] CreateCarteira carteiraDto)
    {
            Carteira carteira = _mapper.Map<Carteira>(carteiraDto);
            _context.Carteiras.Add(carteira);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GatCarteiraById), new {id = carteira.Id}, carteira);
    }

    [HttpGet]
    public IActionResult GetAllCarteira()
    {
        return Ok(_context.Carteiras);
    }

    [HttpGet("{id}")]
    public IActionResult GatCarteiraById(Guid id)
    {
        Carteira carteira = _context.Carteiras.Include(x => x.Papels).SingleOrDefault(c => c.Id == id);
        return carteira != null ? Ok(carteira) : NotFound();
    }

    [HttpGet("PapelsGroupedByClasses")]
    public IActionResult GatPapelsGroupedByClasses([FromQuery] Guid idCarteira)
    {
        var PapelsGroupedByClasses = _context.Papels
            .Where(p => p.IdCarteira == idCarteira)
            .GroupBy(p => p.Classe)
            .Select(g => new {
                Classe = g.Key,
                SomaQtd = g.Sum(p => p.Qtd),
                SomaValor = g.Sum(p => p.Valor) 
            }).ToList();
        return Ok(PapelsGroupedByClasses);
    }

    [HttpGet("PapelsGroupedByTitulo")]
    public IActionResult GatPapelsByTituloFilterByClasse([FromQuery] Guid idCarteira)
    {
        var PapelsByTituloFilterByClasse = _context.Papels
            .Where(p => p.IdCarteira == idCarteira)
            .GroupBy(p => p.Titulo)
            .Select(g => new {
                Titulo = g.Key,
                SomaQtd = g.Sum(p => p.Qtd),
                SomaValor = g.Sum(p => p.Valor)
            }).ToList();

        return Ok(PapelsByTituloFilterByClasse);
    }

    [HttpGet("PapelsByCarteira")]
    public IActionResult GatPapelsByCarteira([FromQuery] Guid idCarteira)
    {
        var PapelsByCarteira = _context.Papels
            .Where(p => p.IdCarteira == idCarteira).ToList();

        return Ok(PapelsByCarteira);
    }

    [HttpPut]
    public IActionResult UpdataCarteira([FromBody] UpdataCarteira upCarteira)
    {
        Carteira carteira = _context.Carteiras.FirstOrDefault(x => x.Id == upCarteira.Id);

        if (carteira != null)
        {
            _mapper.Map(upCarteira, carteira);
            _context.SaveChanges();
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}

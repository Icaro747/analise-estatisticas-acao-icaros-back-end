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
        var papels = _context.Papels
            .Include(p => p.movimentacoes)
            .Where(p => p.IdCarteira == idCarteira)
            .ToList();

        var papelsGroupedByClasses = papels
            .GroupBy(p => p.Classe)
            .Select(g => new SelectPapelsGroupedByClasses
            {
                Classe = g.Key,
                Quantidade = g.SelectMany(p => p.movimentacoes).Sum(m => m.Qtd),
                Valor = g.SelectMany(p => p.movimentacoes).Sum(m => m.Valor)
            });

        return Ok(papelsGroupedByClasses);
    }


    [HttpGet("PapelsGroupedByTituloFilterByClasse")]
    public IActionResult GatPapelsByTituloFilterByClasse([FromQuery] Guid idCarteira, string classe)
    {
        var papels = _context.Papels
           .Include(p => p.movimentacoes)
           .Where(p => p.IdCarteira == idCarteira && p.Classe == classe)
           .ToList();

        var PapelsByTituloFilterByClasse = papels
            .GroupBy(p => p.Titulo)
            .Select(g => new SelectPapelsByTituloFilterByClasse
            {
                Titulo = g.Key,
                Quantidade = g.Sum(p => p.movimentacoes.Sum(m => m.Qtd)),
                Valor = g.Sum(p => p.movimentacoes.Sum(m => m.Valor))
            });

        return Ok(PapelsByTituloFilterByClasse);
    }

    [HttpGet("GetDividendosByCarteira")]
    public IActionResult GetDividendosByCarteira([FromQuery] Guid idCarteira)
    {
        var dividendosByCarteira = _context.Papels
            .Include(p => p.Dividendos)
            .Where(p => p.IdCarteira == idCarteira)
            .Select(p => new
            {
                p.Titulo,
                Dividendos = p.Dividendos.Select(d => new
                {
                    d.Data,
                    d.Valor
                })
            })
            .ToList();

        return Ok(dividendosByCarteira);
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

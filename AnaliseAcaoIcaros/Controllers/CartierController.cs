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
        var query = from papel in _context.Papels
            join movimentacao in _context.Movimentacao on papel.Id equals movimentacao.IdPapel
            where papel.IdCarteira == idCarteira
            group movimentacao by papel.Classe into g
            select new SelectPapelsGroupedByClasses
            {
                Classe = g.Key,
                Quantidade = g.Sum(m => m.Qtd),
                Valor = g.Sum(m => m.Valor)
            };

        return Ok(query.ToList());
    }


    [HttpGet("PapelsGroupedByTituloFilterByClasse")]
    public IActionResult GatPapelsByTituloFilterByClasse([FromQuery] Guid idCarteira, string classe)
    {
        var query = from papel in _context.Papels
            join movimentacao in _context.Movimentacao on papel.Id equals movimentacao.IdPapel
            where papel.IdCarteira == idCarteira && papel.Classe == classe
            group new { movimentacao.Qtd, movimentacao.Valor } by papel.Titulo into resultadoGrupo
            select new SelectPapelsByTituloFilterByClasse
            {
                Titulo = resultadoGrupo.Key,
                Quantidade = resultadoGrupo.Sum(r => r.Qtd),
                Valor = resultadoGrupo.Sum(r => r.Valor)
            };

        return Ok(query.ToList());
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

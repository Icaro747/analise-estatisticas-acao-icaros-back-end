using AnaliseAcaoIcaros.Data;
using AnaliseAcaoIcaros.Data.Dtos;
using AnaliseAcaoIcaros.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AnaliseAcaoIcaros.Controllers;

[ApiController]
[Route("[controller]")]
public class CarteiraController : ControllerBase
{

    private AnaliseAcaoContext _context;
    private IMapper _mapper;

    public CarteiraController(AnaliseAcaoContext context, IMapper mapper)
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

        var papels = _context.Papels
            .Include(p => p.movimentacoes)
            .Where(p => p.IdCarteira == idCarteira)
            .ToList();

        var PapelsByCarteira = papels
            .GroupBy(p => p.Id)
            .Select(g => new
            {
                id = g.Key,
                titulo = g.Select(p => p.Titulo).FirstOrDefault(),
                classe = g.Select(p => p.Classe).FirstOrDefault(),
                setor = g.Select(p => p.Setor).FirstOrDefault(),
                Valor = g.Sum(p => p.movimentacoes.Sum(m => m.Valor)),
                ValorRel = g.Sum(
                    p => p.movimentacoes.Sum(m => m.Qtd)
                    * _context.CotacoesAcoes
                        .Where(c => c.Acao == p.Titulo)
                        .OrderByDescending(c => c.DataObtida)
                        .Select(c => c.ValorAtual)
                        .FirstOrDefault()
                )
            })
            .ToList();

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

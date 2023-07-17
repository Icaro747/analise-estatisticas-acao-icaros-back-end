using AnaliseAcaoIcaros.Data;
using AnaliseAcaoIcaros.Data.Dtos;
using AnaliseAcaoIcaros.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnaliseAcaoIcaros.Controllers;

[ApiController]
[Route("[controller]")]
public class PapelController : ControllerBase
{
    private AnaliseAcaoContext _context;
    private IMapper _mapper;

    public PapelController(AnaliseAcaoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreatePapel([FromBody] CreatePepel palelDto)
    {
        try
        {
            Papel palel = _mapper.Map<Papel>(palelDto);
            _context.Papels.Add(palel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaPapelID), new { id = palel.Id }, palel);
        }
        catch (Exception e)
        {
            return NotFound(e);
        }
    }

    [HttpGet]
    public IActionResult GetPapels()
    {
        return Ok(_context.Papels);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaPapelID(Guid id)
    {
        Papel papel = _context.Papels.SingleOrDefault(p => p.Id == id);
        return papel != null ? Ok(papel) : NotFound();
    }

    [HttpGet("AllData")]
    public IActionResult RecuperaPapelIDAllData([FromQuery] Guid id)
    {
        Papel papel = _context.Papels.Include(p => p.movimentacoes).Include(p => p.Dividendos).SingleOrDefault(p => p.Id == id);
        return papel != null ? Ok(papel) : NotFound();
    }

    [HttpGet("GroupedByClasses")]
    public IActionResult GetPapelsGroupedByClasses([FromQuery] Guid idCarteira)
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

    [HttpGet("GroupedBySertoFilterByClasses")]
    public IActionResult GetPapelsGroupedBySertoFilterByClasses([FromQuery] Guid idCarteira, string classe)
    {
        var papels = _context.Papels
            .Include(p => p.movimentacoes)
            .Where(p => p.IdCarteira == idCarteira && p.Classe == classe)
            .ToList();

        var papelsGroupedByClasses = papels
            .GroupBy(p => p.Setor)
            .Select(g => new SelectPapelsGroupedByClasses
            {
                Classe = g.Key,
                Quantidade = g.SelectMany(p => p.movimentacoes).Sum(m => m.Qtd),
                Valor = g.Sum(
                    p => p.movimentacoes.Sum(
                        m => m.Qtd * _context.CotacoesAcoes
                            .Where(c => c.Acao == p.Titulo)
                            .OrderByDescending(c => c.DataObtida)
                            .Select(c => c.ValorAtual)
                            .FirstOrDefault()
                    )
                )
            });

        return Ok(papelsGroupedByClasses);
    }

    [HttpGet("GroupedByTituloFilterByClasseAndSetor")]
    public IActionResult GetPapelsGroupedByTituloFilterByClasseAndSetor([FromQuery] Guid idCarteira, string classe, string setor)
    {
        var papels = _context.Papels
           .Include(p => p.movimentacoes)
           .Where(p => p.IdCarteira == idCarteira && p.Classe == classe && p.Setor == setor)
           .ToList();

        var PapelsByTituloFilterByClasse = papels
            .GroupBy(p => p.Titulo)
            .Select(g => new SelectPapelsByTituloFilterByClasse
            {
                Titulo = g.Key,
                Quantidade = g.Sum(p => p.movimentacoes.Sum(m => m.Qtd)),
                Valor = g.Sum(
                    p => p.movimentacoes.Sum(
                        m => m.Qtd * _context.CotacoesAcoes
                            .Where(c => c.Acao == p.Titulo)
                            .OrderByDescending(c => c.DataObtida)
                            .Select(c => c.ValorAtual)
                            .FirstOrDefault()
                    )
                )
            });

        return Ok(PapelsByTituloFilterByClasse);
    }

    [HttpGet("AllClasse")]
    public IActionResult GetAllClasse()
    {
        var AllClasse = _context.Papels.GroupBy(x => x.Classe).Select(g => new { classe = g.Key }).ToList();
        return Ok(AllClasse);
    }

    [HttpGet("AllTitulo")]
    public IActionResult GetAllTitulo()
    {
        var AllTitulo = _context.Papels.GroupBy(x => x.Titulo).Select(g => new { titulo = g.Key }).ToList();
        return Ok(AllTitulo);
    }

    [HttpGet("AllSetor")]
    public IActionResult GetAllSetor()
    {
        var AllSetor = _context.Papels.GroupBy(x => x.Setor).Select(g => new { setor = g.Key }).ToList();
        return Ok(AllSetor);
    }
}

using AnaliseAcaoIcaros.Data;
using AnaliseAcaoIcaros.Data.Dtos;
using AnaliseAcaoIcaros.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnaliseAcaoIcaros.Controllers;

[ApiController]
[Route("[controller]")]
public class CotacaoController : ControllerBase
{
    private AnaliseAcaoContext _context;
    private IMapper _mapper;

    public CotacaoController(AnaliseAcaoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateCotacao([FromBody] CreateCotacao controllerDto)
    {
        CotacoesAcoes cotacao = _mapper.Map<CotacoesAcoes>(controllerDto);
        _context.CotacoesAcoes.Add(cotacao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCotacaoById), new { id = cotacao.Id }, cotacao);
    }

    [HttpGet]
    public IActionResult GetAllCotacao()
    {
        return Ok(_context.CotacoesAcoes);
    }

    [HttpGet("{id}")]
    public IActionResult GetCotacaoById(Guid id)
    {
        CotacoesAcoes cotacao = _context.CotacoesAcoes.SingleOrDefault(c => c.Id == id);
        return cotacao != null ? Ok(cotacao) : NotFound();
    }

    [HttpGet("Acao")]
    public IActionResult GetCotacaoByName([FromQuery] string acao)
    {
        var cotacoes = _context.CotacoesAcoes
            .Where(c => c.Acao == acao)
            .OrderByDescending(c => c.DataObtida)
            .FirstOrDefault();
        return Ok(cotacoes);
    }
}

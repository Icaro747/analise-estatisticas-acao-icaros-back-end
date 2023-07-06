using AnaliseAcaoIcaros.Data;
using AnaliseAcaoIcaros.Data.Dtos;
using AnaliseAcaoIcaros.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnaliseAcaoIcaros.Controllers;

[ApiController]
[Route("[controller]")]
public class MovimentacaoController : ControllerBase
{
    private AnaliseAcaoContext _context;
    private IMapper _mapper;

    public MovimentacaoController(AnaliseAcaoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateMovimentacao([FromBody] CreateMovimentacao MovimentacaoDto)
    {
        try
        {
            Movimentacao movimentacao = _mapper.Map<Movimentacao>(MovimentacaoDto);
            _context.Movimentacao.Add(movimentacao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaMovimentacaoID), new { id = movimentacao.Id }, movimentacao);
        }
        catch (Exception e)
        {
            return NotFound(e);
        }
    }

    [HttpGet]
    public IActionResult GetMovimentacao()
    {
        return Ok(_context.Movimentacao);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaMovimentacaoID(Guid id)
    {
        Movimentacao movimentacao = _context.Movimentacao.SingleOrDefault(m => m.Id == id);
        return movimentacao != null ? Ok(movimentacao) : NotFound();
    }
}

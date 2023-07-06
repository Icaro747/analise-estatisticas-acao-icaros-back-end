using AnaliseAcaoIcaros.Data;
using AnaliseAcaoIcaros.Data.Dtos;
using AnaliseAcaoIcaros.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnaliseAcaoIcaros.Controllers;

[ApiController]
[Route("[controller]")]
public class DividendosController : ControllerBase
{
    private AnaliseAcaoContext _context;
    private IMapper _mapper;

    public DividendosController(AnaliseAcaoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateDividendos([FromBody] CreateDividendos dividendosDto)
    {
        Dividendos dividendos = _mapper.Map<Dividendos>(dividendosDto);
        _context.Dividendos.Add(dividendos);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GatDividendosById), new { id = dividendos.Id }, dividendos);
    }

    [HttpGet]
    public IActionResult GetAllDividendos()
    {
        return Ok(_context.Dividendos);
    }

    [HttpGet("{id}")]
    public IActionResult GatDividendosById(Guid id)
    {
        Dividendos dividendos = _context.Dividendos.SingleOrDefault(c => c.Id == id);
        return dividendos != null ? Ok(dividendos) : NotFound();
    }

}

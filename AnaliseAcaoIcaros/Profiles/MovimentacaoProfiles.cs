using AnaliseAcaoIcaros.Data.Dtos;
using AnaliseAcaoIcaros.Models;
using AutoMapper;

namespace AnaliseAcaoIcaros.Profiles;

public class MovimentacaoProfiles : Profile
{
    public MovimentacaoProfiles()
    {
        CreateMap<CreateMovimentacao, Movimentacao>();
    }
}

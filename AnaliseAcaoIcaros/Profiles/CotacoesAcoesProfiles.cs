using AnaliseAcaoIcaros.Data.Dtos;
using AnaliseAcaoIcaros.Models;
using AutoMapper;

namespace AnaliseAcaoIcaros.Profiles;

public class CotacoesAcoesProfiles : Profile
{
    public CotacoesAcoesProfiles()
    {
        CreateMap<CreateCotacao, CotacoesAcoes>();
    }
}

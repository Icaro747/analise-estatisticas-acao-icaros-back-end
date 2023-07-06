using AnaliseAcaoIcaros.Data.Dtos;
using AnaliseAcaoIcaros.Models;
using AutoMapper;

namespace AnaliseAcaoIcaros.Profiles;

public class DividendosProfiles : Profile
{
    public DividendosProfiles()
    {
        CreateMap<CreateDividendos, Dividendos>();
    }
}

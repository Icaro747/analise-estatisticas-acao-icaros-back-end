using AnaliseAcaoIcaros.Data.Dtos;
using AnaliseAcaoIcaros.Models;
using AutoMapper;

namespace AnaliseAcaoIcaros.Profiles;

public class CarteiraProfiles : Profile
{
    public CarteiraProfiles()
    {
        CreateMap<CreateCarteira, Carteira>();
        CreateMap<UpdataCarteira, Carteira>();
    }
}

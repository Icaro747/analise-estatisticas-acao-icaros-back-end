﻿using AnaliseAcaoIcaros.Data.Dtos;
using AnaliseAcaoIcaros.Models;
using AutoMapper;

namespace AnaliseAcaoIcaros.Profiles;

public class PapelProfiles : Profile
{
    public PapelProfiles()
    {
        CreateMap<CreatePepel, Papel>();
    }
}

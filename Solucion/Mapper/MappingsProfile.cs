using Application.DTO;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Cliente, ClientDTO>().ReverseMap();
            CreateMap<Cuenta, AccountDTO>().ReverseMap();
            CreateMap<Persona, PersonDTO>().ReverseMap();
            CreateMap<Movimiento, TransactionDTO>().ReverseMap();
        }
    }
}

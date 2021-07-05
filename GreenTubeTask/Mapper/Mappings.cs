using AutoMapper;
using GreenTubeTask.Models;
using GreenTubeTask.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomagochi.BLL.DTO;
using Tomagochi.DAL.Entities;
using AutoMapper;

namespace Tomagochi.BLL.Profiles
{
    public class PetProfile:Profile
    {
        public PetProfile()
        {
            CreateMap<PetDTO, Pet>()
                .ForMember(p => p.Name, opt => opt.MapFrom(petDTO => petDTO.Name))
                .ForMember(p => p.BodyPath, opt => opt.MapFrom(petDTO => petDTO.Body))
                .ForMember(p => p.EyesPath, opt => opt.MapFrom(petDTO => petDTO.Eye))
                .ForMember(p => p.NosePath, opt => opt.MapFrom(petDTO => petDTO.Nose))
                .ForMember(p => p.MouthPath, opt => opt.MapFrom(petDTO => petDTO.Mouth));
                
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dadata_service.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<List<AddressRequest>, AddressResponse>()
                .ForMember(dest => dest.source, opt => opt.MapFrom(src => src.Select(det => det.source).Single())) 
                .ForMember(dest => dest.result, opt => opt.MapFrom(src => src.Select(det => det.result).Single()))
                .ForMember(dest => dest.postal_code, opt => opt.MapFrom(src => src.Select(det => det.postal_code).Single()))
                .ForMember(dest => dest.country, opt => opt.MapFrom(src => src.Select(det => det.country).Single()))
                .ForMember(dest => dest.house, opt => opt.MapFrom(src => src.Select(det => det.house).Single()))
                .ForMember(dest => dest.region, opt => opt.MapFrom(src => src.Select(det => det.region).Single()))
                .ForMember(dest => dest.street, opt => opt.MapFrom(src => src.Select(det => det.street).Single()));
        }
    }
}

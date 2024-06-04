﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Weather_site.Core.Entities;
using Weather_site.Service.DTOS;


namespace Weather_site.Service
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Weather, WeatherModel>().ReverseMap();
            CreateMap<Weather, WeatherAdd>().ReverseMap();
            CreateMap<CityDTO, City>().ReverseMap();
            CreateMap<City, CityAdd>().ReverseMap();
            CreateMap<CountryDTO, Country>().ReverseMap();
            CreateMap<Country, CountryAdd>().ReverseMap();
            CreateMap<WindDTO, Wind>().ReverseMap();
            CreateMap<Wind, WindAdd>().ReverseMap();
        }
        
    }
}
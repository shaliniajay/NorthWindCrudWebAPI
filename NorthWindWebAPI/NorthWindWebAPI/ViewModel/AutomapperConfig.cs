using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NorthWindWebAPI.DataModel;

namespace NorthWindWebAPI.ViewModel
{
    public static class AutomapperConfig
    {
        
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Customer, CustomerViewModel>().ReverseMap());
            //or
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerViewModel>());
        
        }
    }
}
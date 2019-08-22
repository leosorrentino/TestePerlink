using AutoMapper;
using EP.CursoMVC.Application.ViewModels;
using EP.CursoMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(i =>
            {
                i.AddProfile<DomainToViewModelMappingProfile>();
                //i.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }

  
}

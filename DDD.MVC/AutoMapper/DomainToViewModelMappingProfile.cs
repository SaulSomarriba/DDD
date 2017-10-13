using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DDD.Dominio.Entidad;
using DDD.MVC.ViewModels;

namespace DDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {

            Mapper.CreateMap<TipoBancoViewModel, TipoBanco>();
            Mapper.CreateMap<BancoViewModel, Banco>();
        }
    }
}
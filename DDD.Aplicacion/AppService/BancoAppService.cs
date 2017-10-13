using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Aplicacion.Interface;
using DDD.Dominio.Entidad;
using DDD.Dominio.Interface.Services;

namespace DDD.Aplicacion.AppService
{
    public class BancoAppService : AppServiceBase<Banco>, IBancoAppService
    {
        private readonly IBancoService _bancoService;

        public BancoAppService(IBancoService bancoService): base(bancoService)
        {
            _bancoService = bancoService;
        }
    }
}

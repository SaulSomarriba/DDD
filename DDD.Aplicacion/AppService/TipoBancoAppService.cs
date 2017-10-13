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
    public class TipoBancoAppService : AppServiceBase<TipoBanco>, ITipoBancoAppService
    {
        private readonly ITipoBancoService _tipoBancoService;

        public TipoBancoAppService(ITipoBancoService tipoBancoService): base(tipoBancoService)
        {
            _tipoBancoService = tipoBancoService;
        }
    }
}

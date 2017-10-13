using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Dominio.Entidad;
using DDD.Dominio.Interface.Repositories;
using DDD.Dominio.Interface.Services;

namespace DDD.Dominio.Servicio
{
    public class TipoBancoService : ServiceBase<TipoBanco>, ITipoBancoService
    {
        private readonly ITipoBancoRepository _tipoBancoRepository;

        public TipoBancoService(ITipoBancoRepository tipoBancoRepository): base(tipoBancoRepository)
        {
            _tipoBancoRepository = tipoBancoRepository;
        }
    }
}

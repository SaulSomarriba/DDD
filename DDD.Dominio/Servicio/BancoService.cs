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
    public class BancoService : ServiceBase<Banco>, IBancoService
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoService(IBancoRepository bancoRepository): base(bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Dominio.Entidad;
using DDD.Dominio.Interface;
using DDD.Dominio.Interface.Repositories;

namespace DDD.Infra.Data.Repositorios
{
    public  class TipoBancoRepository : RepositoryBase<TipoBanco>, ITipoBancoRepository
    {
    }
}

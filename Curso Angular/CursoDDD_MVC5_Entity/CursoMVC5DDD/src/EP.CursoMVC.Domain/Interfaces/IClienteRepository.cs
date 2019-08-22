using EP.CursoMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EP.CursoMVC.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>, IRepositoryWrite<Cliente>
    {
        Cliente ObterPorCPF(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterAtivos();
    }
}

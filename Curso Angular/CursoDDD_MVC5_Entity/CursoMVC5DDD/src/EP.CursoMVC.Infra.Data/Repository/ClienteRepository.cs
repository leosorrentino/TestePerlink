using Dapper;
using EP.CursoMVC.Domain.Interfaces;
using EP.CursoMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository() : base()
        {

        }
        public IEnumerable<Cliente> ObterAtivos()
        {
            //throw new Exception("Testando tratamento de erros");

            var sql = @"Select * from Clientes c " +    
                        "Where c.Excluido = 0 and c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente>(sql);
        }
        public override Cliente ObterPorId(Guid id)
        {
            var sql = @"Select * from Clientes c " +
                       "left join Enderecos e " +
                       "on c.id = e.ClienteId " +
                       "Where c.Id = @uid and c.Excluido = 0 and c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) =>
                {
                    c.Enderecos.Add(e);
                    return c;
                }, new { uid = id }).FirstOrDefault();

        }
        public Cliente ObterPorCPF(string cpf)
        {
            return Buscar(c => c.CPF == cpf && c.Ativo && !c.Excluido).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email && c.Ativo && !c.Excluido).FirstOrDefault();
        }

        //Removendo logicamente, apenas na classe Cliente.
        public override void Remove(Guid id)
        {
            var cliente = ObterPorId(id);

            cliente.RemoverLogicamente();
            Atualizar(cliente);
        }
    }
}

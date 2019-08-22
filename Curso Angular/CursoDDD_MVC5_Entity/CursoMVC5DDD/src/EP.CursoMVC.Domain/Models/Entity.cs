using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Models
{
    // Super classe, classe base, herdando os campos dessa classe...
    // Vc não pode criar uma instancia dessa entidade, só herdar dela...
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public void AdicionarErroValidacao(string Erro)
        {
            //Add erro na lista de erros...
        }

        // Todas as classe que herdarem a classe Entity teram que imoplemtentar o método é 'EhValido'.
        public abstract bool EhValido();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TestePerlink.Domain.Repository;

namespace TestePerlink.Domain.Service
{
    public class NumeroService : INumeroService
    {

        private readonly INumeroRepository numeroRepository;

        public NumeroService(INumeroRepository numeroRepository)
        {
            this.numeroRepository = numeroRepository;
        }
        public Action ObterNumeroFeliz()
        {
            return numeroRepository.ObterNumeroFeliz();
        }
    }
}

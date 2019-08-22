using System;
using System.Collections.Generic;

namespace EP.CursoMVC.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }

        //Propriedade de navegação do EF... 
        public virtual ICollection<Endereco> Enderecos { get; private set; }

        // Construtor vazio para o E.F.
        public Cliente()
        {
            this.Enderecos = new List<Endereco>();
        }

        public Cliente(   
            string nome,
            string email,
            string cpf,
            DateTime dataCadastro,
            DateTime dataNascimento,
            bool ativo,
            bool excluido)
        {
            this.Nome = nome;
            this.Email = email;
            this.CPF = cpf;
            this.DataCadastro = dataCadastro;
            this.DataNascimento = dataNascimento;
            this.Ativo = ativo;
            this.Excluido = excluido;
            this.Enderecos = new List<Endereco>();
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            if (!endereco.EhValido())
                return;

            Enderecos.Add(endereco);
        }
        
        public void DefinirComoAtivo()
        {
            this.Ativo = true;
            this.Excluido = false;
        }

        public void RemoverLogicamente()
        {
            this.Ativo = false;
            this.Excluido = true;
        }
        public override bool EhValido()
        {
            return true;
        }
    }
}
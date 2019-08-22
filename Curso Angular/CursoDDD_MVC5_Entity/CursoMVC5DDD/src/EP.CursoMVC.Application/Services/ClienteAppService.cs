using AutoMapper;
using EP.CursoMVC.Application.Interfaces;
using EP.CursoMVC.Application.ViewModels;
using EP.CursoMVC.Domain.Interfaces;
using EP.CursoMVC.Domain.Models;
using EP.CursoMVC.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        protected IClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos()); // Transformar Cliente em ClienteViewModel
        }

        public ClienteViewModel ObterPorCPF(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCPF(cpf));
        }
        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }
        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }
        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }
        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Clientes);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.Enderecos);

            cliente.DefinirComoAtivo();
            cliente.AdicionarEndereco(endereco);

            _clienteRepository.Adicionar(cliente);

            return clienteEnderecoViewModel;
        }
        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);

            _clienteRepository.Atualizar(cliente);

            return clienteViewModel;
        }
        public void Remove(Guid id)
        {
            _clienteRepository.Remove(id);
        }
        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}

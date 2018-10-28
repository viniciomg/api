using Piovezana.Domain.Entities;
using Piovezana.Domain.Interfaces.Repositories;
using Piovezana.Infra.Persistencia.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piovezana.Infra.Persistencia.Repositories
{
    public class RepositoryUsuario : IRepositoryUsuario

    {

        private readonly PiovezanaContexto _contexto;

        public RepositoryUsuario(PiovezanaContexto contexto)
        {
            _contexto = contexto;
        }
            

        public bool Existe(string Email)
        {
            return _contexto.Usuarios.Any(x => x.Email.Endereco == Email);
        }

        public Usuario Obter(Guid Id)
        {
            return _contexto.Usuarios.FirstOrDefault(x => x.Id==Id);
        }

        public Usuario Obter(string Email, string Senha)
        {
            return _contexto.Usuarios.FirstOrDefault(x => x.Email.Endereco == Email && x.Senha == Senha);
        }

        public void Salvar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
        }
    }
}

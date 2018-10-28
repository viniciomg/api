using Piovezana.Domain.Entities;
using System;

namespace Piovezana.Domain.Interfaces.Repositories
{
  public  interface IRepositoryUsuario
    {
        Usuario Obter(Guid Id);
        Usuario Obter(string Email, string Senha);
        void Salvar(Usuario usuario);
        bool Existe(String Email);

    }
}

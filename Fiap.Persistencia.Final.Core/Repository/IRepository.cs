using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Persistencia.Final.Core.Repository
{
    public interface IRepository<T>
    {
        void Incluir(T entity);
        void Remover(T entity);
        void Atualizar(T entity);
        ICollection<T> Listar();
        T Buscar(int id);
    }
}

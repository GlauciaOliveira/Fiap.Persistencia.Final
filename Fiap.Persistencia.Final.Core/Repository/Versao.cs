using System;
using System.Collections.Generic;
using System.Text;
using Fiap.Persistencia.Final.Core.Models;
using Fiap.Persistencia.Final.Core.Data;
using System.Linq;

namespace Fiap.Persistencia.Final.Core.Repository
{
    public class Versao : IRepository<Models.Versao>, IDisposable
    {
        public Context db = null;

        public Versao(Context context)
        {
            db = context;
        }

        public void Incluir(Models.Versao entity)
        {
            db.Versao.Add(entity);
            db.SaveChanges();
        }

        public void Remover(Models.Versao entity)
        {
            db.Versao.Remove(entity);
            db.SaveChanges();
        }

        public void Atualizar(Models.Versao entity)
        {
            db.SaveChanges();
        }

        ICollection<Models.Versao> IRepository<Models.Versao>.Listar()
        {
            var result = db.Versao.ToList();
            return result;
        }

        Models.Versao IRepository<Models.Versao>.Buscar(int id)
        {
            var result = db.Versao.Find(id);
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (null != db)
                    db.Dispose();

                db = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

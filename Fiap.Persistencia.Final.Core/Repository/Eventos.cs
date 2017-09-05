using Fiap.Persistencia.Final.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Fiap.Persistencia.Final.Core.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Persistencia.Final.Core.Repository
{
    public class Eventos : IRepository<Models.Eventos>, IDisposable
    {
        public Context db = null;

        public Eventos(Context context)
        {
            db = context;
        }

        public void Incluir(Models.Eventos entity)
        {
            db.Eventos.Add(entity);
            db.SaveChanges();
        }

        public void Remover(Models.Eventos entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Atualizar(Models.Eventos entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public ICollection<Models.Eventos> Listar()
        {
            var result = db.Eventos.ToList();
            return result;
        }

        public Models.Eventos Buscar(int id)
        {
            var result = db.Eventos.Find(id);
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

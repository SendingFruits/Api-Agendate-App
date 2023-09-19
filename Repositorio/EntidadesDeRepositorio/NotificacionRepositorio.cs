using Repositorio.IRepositorio;
using Logic.Data;
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Repositorio.EntidadesDeRepositorio
{
    public class NotificacionRepositortio : Repositorio<Notificacion>, INotificaciones
    {
        private readonly DataContext _db;
        public NotificacionRepositortio(DataContext db) : base(db)
        {
            _db = db;
        }

        //public Task<Notificacion> Actualizar(Notificacion entidad)
        //{

        //    //throw new NotImplementedException();
        //    //var notificacionesBD = _db.Notificacion.FirstOrDefault(s => s.);
        //    //if (notificacionesBD != null)
        //    //{
        //    //    ActualizarAtributos(ref clienteBD, p_entidad);
        //    //    await Modificar(clienteBD);
        //    //}

        //    //return p_entidad;
        //    return await entidad;
        //}


    }
}
using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.IRepositorio
{
    public interface INotificacion : IRepositorio<Notificaciones>
    {

        //Task<Notificacion> Actualizar(Notificacion entidad);
    }
}
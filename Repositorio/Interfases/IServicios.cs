﻿using Logic.Entities;
using Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfases
{
    public interface IServicios: IRepositorio<Servicio>
    {

        Task<Servicio> Actualizar(Servicio entidad);


    }
}

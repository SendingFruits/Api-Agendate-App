﻿
using Logic.Entities;
using Repositorio.EntidadesDeRepositorio;
using Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfases
{
    public interface IEmpresa:IRepositorio<Empresa>
    {

        public  Task<Empresa> Actualizar(Empresa entidad);


    }
}

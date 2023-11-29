﻿using Logic.Data;
using Logic.Entities;
using Repositorio.IRepositorio;

namespace Repositorio.EntidadesDeRepositorio
{
    public class UsuarioRepositorio : Repositorio<Usuarios>, IUsuario
    {
        private readonly DataContext _db;

        public UsuarioRepositorio(DataContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Usuarios> Actualizar(Usuarios n)
        {
            _db.Entry(n).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _db.SaveChangesAsync();
            return n;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IngresoNotasLibrary.Models;

namespace IngresoNotasAPI.Models
{
    public class IngresoNotasDBContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Materia> Materias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>().MapToStoredProcedures(sp =>
            sp.Insert(i => i.HasName("InsertAlumno")
                .Parameter(a => a.Carnet, "Carnet")
                .Parameter(a => a.Nombres, "Nombres")
                .Parameter(a => a.Apellidos, "Apellidos")
                .Parameter(a => a.Fecha_Ingreso, "Fecha_Ingreso")
                .Parameter(a => a.CarreraId, "CarreraId"))
            .Update(u => u.HasName("UpdateAlumno")
                .Parameter(a => a.Carnet, "Carnet")
                .Parameter(a => a.Nombres, "Nombres")
                .Parameter(a => a.Apellidos, "Apellidos")
                .Parameter(a => a.Fecha_Ingreso, "Fecha_Ingreso")
                .Parameter(a => a.CarreraId, "CarreraId"))
            .Delete(d => d.HasName("DeleteAlumno")
                .Parameter(a => a.Carnet, "Carnet")));
            modelBuilder.Entity<Carrera>().ToTable("Carreras");
            modelBuilder.Entity<Materia>().ToTable("Materias");
        }
    }

}
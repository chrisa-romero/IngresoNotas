using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IngresoNotasAPI.Models;
using IngresoNotasLibrary.Models;

namespace IngresoNotasAPI.Controllers
{
    public class AlumnosController : ApiController
    {
        private readonly IngresoNotasDBContext db = new IngresoNotasDBContext();

        [HttpGet]
        public IEnumerable<Alumno> GetAlumnos()
        {
            return db.Database.SqlQuery<Alumno>("SELECT * FROM Alumnos").ToList();
        }

        [HttpGet]
        public IHttpActionResult GetAlumno(string carnet)
        {
            var alumno = db.Alumnos.Find(carnet);
            if (alumno == null)
                return NotFound();
            return Ok(alumno);
        }

        [HttpPost]
        public IHttpActionResult AddAlumno(Alumno alumno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Alumnos.Add(alumno);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = alumno.Carnet }, alumno);
        }

        [HttpPut]
        public IHttpActionResult UpdateAlumno(string carnet, Alumno alumno)
        {
            if (carnet != alumno.Carnet)
                return BadRequest();

            db.Entry(alumno).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAlumno(string carnet)
        {
            var alumno = db.Alumnos.Find(carnet);
            if (alumno == null)
                return NotFound();

            db.Alumnos.Remove(alumno);
            db.SaveChanges();
            return Ok(alumno);
        }
    }

}

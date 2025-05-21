using IngresoNotasLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IngresoNotasApp
{
    public partial class AddAlumno : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]) };
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            var newAlumno = new Alumno
            {
                Carnet = txtCarnet.Text,
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                Fecha_Ingreso = DateTime.Parse(txtFechaIngreso.Text),
                CarreraId = int.Parse(txtCarreraId.Text)
            };

            await AddAlumnoAsync(newAlumno);

            Response.Redirect("Alumnos.aspx"); // Redirect to the list page after adding
        }

        public static async Task AddAlumnoAsync(Alumno alumno)
        {
            string json = JsonConvert.SerializeObject(alumno);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("alumnos", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
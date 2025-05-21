using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IngresoNotasLibrary.Models;
using System.Configuration;
using System.Text;

namespace IngresoNotasApp
{
    public partial class Alumnos : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]) };
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadAlumnosAsync();
            }
        }

        private async Task LoadAlumnosAsync()
        {
            HttpResponseMessage response = await client.GetAsync("alumnos");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            List<Alumno> alumnos = JsonConvert.DeserializeObject<List<Alumno>>(content);

            GridViewAlumnos.DataSource = alumnos;
            GridViewAlumnos.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAlumno.aspx");
        }
        protected async void GridViewAlumnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string carnet = GridViewAlumnos.DataKeys[e.RowIndex].Value.ToString();
            GridViewRow row = GridViewAlumnos.Rows[e.RowIndex];

            var updatedAlumno = new Alumno
            {
                Carnet = carnet,
                Nombres = ((TextBox)row.Cells[1].Controls[0]).Text,
                Apellidos = ((TextBox)row.Cells[2].Controls[0]).Text,
                Fecha_Ingreso = DateTime.Parse(((TextBox)row.Cells[3].Controls[0]).Text),
                CarreraId = int.Parse(((TextBox)row.Cells[4].Controls[0]).Text)
            };

            await UpdateAlumnoAsync(updatedAlumno);
            GridViewAlumnos.EditIndex = -1;
            await LoadAlumnosAsync();
        }
        protected async void GridViewAlumnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string carnet = GridViewAlumnos.DataKeys[e.RowIndex].Value.ToString();
            await DeleteAlumnoAsync(carnet);
            await LoadAlumnosAsync();
        }
        protected void GridViewAlumnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewAlumnos.EditIndex = e.NewEditIndex; // Set edit mode for the selected row
            LoadAlumnosAsync().Wait(); // Reload data to reflect changes
        }
        protected void GridViewAlumnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewAlumnos.EditIndex = -1; // Reset edit index
            LoadAlumnosAsync().Wait(); // Reload data to reflect changes
        }

        public static async Task AddAlumnoAsync(Alumno alumno)
        {
            string json = JsonConvert.SerializeObject(alumno);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("alumnos", content);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAlumnoAsync(Alumno alumno)
        {
            string json = JsonConvert.SerializeObject(alumno);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("alumnos/" + alumno.Carnet, content);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAlumnoAsync(string carnet)
        {
            HttpResponseMessage response = await client.DeleteAsync("alumnos/" + carnet);
            response.EnsureSuccessStatusCode();
        }
    }
}
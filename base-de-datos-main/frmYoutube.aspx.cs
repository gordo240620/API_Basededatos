using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL;
using DAL;


namespace YoutubeAPI
{
    public partial class frmYoutube : System.Web.UI.Page
    {
        protected async void btnBuscar_Click(object sender, EventArgs e)
        {
            string query = txtBuscar.Text;

            // Guardar la búsqueda en la base de datos
            SQLDBHelper busquedasDAL = new SQLDBHelper();
            busquedasDAL.GuardarBusqueda(query); // Asegúrate de que el método recibe 'query' y lo inserta como 'informacion'

            BDYoutube_DAL youtubeDAL = new BDYoutube_DAL();
            List<BDYoutube_BLL> videos = await youtubeDAL.BuscarVideos(query);
            rptVideos.DataSource = videos;
            rptVideos.DataBind();
        }

    }
}

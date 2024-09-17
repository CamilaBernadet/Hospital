using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EC;
public partial class Estadísticas_ : System.Web.UI.Page
{
    List<Solicitud> _Solicitud = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        try { 
        if (!IsPostBack)
        {
            Session["Solicitudes"]=_Solicitud= Logica.FabricaLogica.GetLogicaSolicitud().ListarSolicitudes();
        }

        else
        {
           
            _Solicitud = (List<Solicitud>)Session["Solicitudes"];
            
        }
    }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {



            GvSolicitudesP.DataSource = (from unU in _Solicitud
                                         group unU by unU.Asistencia 
                               into grupo
                                      select new
                                      {
                                          TipoAsistencia = grupo.Key,
                                          CantidadSolicitudes = grupo.Count()
                                      }
                              ).ToList<object>();

            GvSolicitudesP.DataBind();

        





    }






    protected void BtnLista2_Click(object sender, EventArgs e)
    {//me da error
        //List<object> resultado = (from unC in (Logica.FabricaLogica.GetLogicaConsulta().ListarConsulta())
        //                          group unC by new { unC.MedicoNombre, unC.NumConsulta } into grupo
        //                          orderby grupo.Count() descending
        //                          select new
        //                          {
        //                              Policlinica = grupo.First().MedicoNombre,
        //                              Consultorio = grupo,
        //                              CantidadConsultas = grupo.Count()
        //                          }).ToList();
    }

    protected void GvLista1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EC;
using Logica;
public partial class Estadistica : System.Web.UI.Page
{


    List<Solicitud> _Solicitud = null;
    List<Consulta> _Consultas = null;
    List<Policlinica> _Policlinica = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                Session["Consultas"] = _Consultas = FabricaLogica.GetLogicaConsulta().ListarConsulta();
                Session["Solicitud"] = _Solicitud = FabricaLogica.GetLogicaSolicitud().ListarSolicitudes();

            }

            else
            {

                _Solicitud = (List<Solicitud>)Session["Solicitud"];
                _Consultas = (List<Consulta>)Session["Consultas"];
                _Policlinica = (List<Policlinica>)Session["Policlinica"];
            }
        }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }
    }

    protected void BtnEstadistica_Click(object sender, EventArgs e)
    {
        try
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
        catch(Exception ex)
        {
            LblError.Text = ex.Message;
        }

    }

    protected void BtnConsulta_Click(object sender, EventArgs e)
    {

        try
        {
            GvConsultas.DataSource = (from unC in _Consultas
                                      group unC by new { unC.UnConsultorio.UnaPol.Codigo, unC.UnConsultorio.NumConsultorio, unC.CanConsulta }
                                      into grupo
                                      orderby grupo.Count() descending
                                      select new
                                      {
                                          Policlinica = grupo.Key.Codigo,
                                          NumConsultorio = grupo.Key.NumConsultorio,
                                          CantidadConsultas = grupo.Count()
                                      }).ToList();

            GvConsultas.DataBind();

        }
        catch(Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}
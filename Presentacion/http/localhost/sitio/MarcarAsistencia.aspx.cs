using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EC;
using Logica;

public partial class MarcarAsistencia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                
                if (Session["Solicitudes"] == null)
                {
                    
                    List<Solicitud> _unaSoli = FabricaLogica.GetLogicaSolicitud().ListSinAsistir();
                    if (_unaSoli != null)
                    {
                       
                        Session["Solicitudes"] = _unaSoli;
                    }
                    
                }

                
                List<Solicitud> solicitudes = Session["Solicitudes"] as List<Solicitud>;
                if (solicitudes != null && solicitudes.Count > 0)
                {
                    GvSolicitudes.DataSource = solicitudes;
                    GvSolicitudes.DataBind();
                }
                else
                {
                    
                    LblError.Text = "No hay solicitudes disponibles.";
                }
            }
            catch (Exception ex)
            {
                
                LblError.Text =  ex.Message;
            }
        }
    }

    protected void GvSolicitudes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvSolicitudes.PageIndex = e.NewPageIndex;

        GvSolicitudes.DataSource = Session["Solicitudes"];
        GvSolicitudes.DataBind();
    }

    protected void GvSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (GvSolicitudes.SelectedRow != null)
        {
            
            int index = GvSolicitudes.SelectedIndex;

            
            List<Solicitud> solicitudes = Session["Solicitudes"] as List<Solicitud>;

            if (solicitudes != null && index >= 0 && index < solicitudes.Count)
            {
                
                Solicitud solicitudSeleccionada = solicitudes[index];

                
                ListBoxDetalles.Items.Clear();
                ListBoxDetalles.Items.Add("Detalles de Paciente: " + solicitudSeleccionada.UnP.NomCompleto.ToString());
                ListBoxDetalles.Items.Add("Consulta: " + solicitudSeleccionada.UnC.Especialidad);
                ListBoxDetalles.Items.Add("Asistencia: " + solicitudSeleccionada.Asistencia);

                
                CheckAsistencia.Checked = solicitudSeleccionada.Asistencia;
            }
        }
    }


    protected void BtnRefrescar_Click(object sender, EventArgs e)
    {
        GvSolicitudes.SelectedIndex = -1;
        LblError.Text = "";
        ListBoxDetalles.Items.Clear();
        //Session["Solicitudes"] = null;
        CheckAsistencia.Checked = false;

    }

    protected void CheckAsistencia_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            if (GvSolicitudes.SelectedRow != null)
            {

                int index = GvSolicitudes.SelectedIndex;


                List<Solicitud> solicitudes = Session["Solicitudes"] as List<Solicitud>;

                if (solicitudes != null && index >= 0 && index < solicitudes.Count)
                {

                    Solicitud solicitudSeleccionada = solicitudes[index];


                    solicitudSeleccionada.Asistencia = CheckAsistencia.Checked;


                    Session["Solicitudes"] = solicitudes;


                    FabricaLogica.GetLogicaSolicitud().MarcarSinAsistir(solicitudSeleccionada);

                    GvSolicitudes.DataSource = Session["Solicitudes"];
                    GvSolicitudes.DataBind();

                    LblError.Text = "Cambios guardados exitosamente.";
                }
                else
                {
                    LblError.Text = "La solicitud seleccionada no es válida.";
                }
            }
            else
            {
                LblError.Text = "No se ha seleccionado ninguna solicitud.";
            }
        }

        catch (Exception ex)
        {
            LblError.Text = (ex.Message);
        }
    }
}
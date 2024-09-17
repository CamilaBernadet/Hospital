using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EC;
public partial class AltaConsulta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if(!IsPostBack)
            {
                 
               List <Consultorio> _LisConsultorio  = FabricaLogica.GetLogicaConsultorio().ListarConsultorio();
                Session["Consultorio"] = _LisConsultorio;


                Session["Consultorio"] = _LisConsultorio;

                    DdlConsultorio.DataSource = _LisConsultorio;
                    DdlConsultorio.DataTextField = "NumConsultorio";
                    DdlConsultorio.DataBind();

                    DdlConsultorio.Items.Insert(0, "Seleccione");
                
                }
            else
            {
                LblError.Text = "No se pudieron Listar los Consultorios";
            }
            
        }
        catch (Exception ex)
        {
            
            LblError.Text = "Error: " + ex.Message;
        }
    }

    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        TxtCantidad.Text = "";
        TxtEspecialidad.Text = "";
        TxtFechaHora.Text = "";
        TxtNombre.Text = "";
        LblError.Text = "";
        
    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {

        try
        {
           
            
               Consultorio _unConsultorio = ((List<Consultorio>)Session["Consultorio"])[DdlConsultorio.SelectedIndex -1];
            if (_unConsultorio == null)
            LblError.Text = "Debe Seleccionar un Consultorio...";

            Consulta _unaConsulta = new Consulta(0,
                                              Convert.ToDateTime(TxtFechaHora.Text),
                                              Convert.ToInt32(TxtCantidad.Text),
                                              TxtNombre.Text.Trim(),
                                              TxtEspecialidad.Text.Trim(),
                                              _unConsultorio);

            FabricaLogica.GetLogicaConsulta().AltaConsulta(_unaConsulta);

            
            LblError.Text = "Alta con Éxito";
               
            }

        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }

        }
}
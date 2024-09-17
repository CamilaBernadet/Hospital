using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EC;

public partial class _Default : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        // Limpio la sesión
        Session["EmpleadoUss"] = null;
        try
        {
            if (!IsPostBack)
            {
                if (Session["LisConsulta"] == null)
                {
                    List<Consulta> unC = Logica.FabricaLogica.GetLogicaConsulta().ListarConsultaAFuturo();
                    
                    if (unC != null)
                    {
                        Session["LisConsulta"] = unC;
                    }
                    else
                    {
                        Session["LisConsulta"] = new List<Consulta>(); 
                    }
                }

                
                if (Session["LisConsulta"] is List<Consulta>)
                {
                    Gvconsulta.DataSource = Session["LisConsulta"];
                    Gvconsulta.DataBind();
                }
                else
                {
                    LblErrorGV.Text = "Error: La lista de consultas no es válida.";
                }
            }
        }
        catch (Exception ex)
        {
            LblErrorGV.Text = "Error al cargar la grilla: " + ex.Message;
        }
    }
        

   

    protected void BtnLogueo_Click(object sender, EventArgs e)
    {
        try
        {
            string NomUsu = TxtNomUSu.Text.Trim();
            string PasUsu = TxtPassUsu.Text.Trim(); 

            Empleado _unEmp = FabricaLogica.GetLogicaEmpleado().Logueo(NomUsu, PasUsu);

            if (_unEmp == null)
                LblErrorLogueo.Text = "Verifique los datos ingresados";

            else
            {
                Session["EmpleadoUss"] = _unEmp;
                Response.Redirect("~/AdministracionEmpleado.aspx");

                LblErrorLogueo.Text = " ";
            }
        }

        catch(Exception ex)
        {
            LblErrorLogueo.Text = ex.Message;
        }

    }

    protected void Gvconsulta_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
       
    }

    protected void Gvconsulta_SelectedIndexChanging1(object sender, GridViewSelectEventArgs e)
    {
        
    }

    protected void Gvconsulta_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gvconsulta.PageIndex = e.NewPageIndex;

        Gvconsulta.DataSource = Session["LisConsulta"];
        Gvconsulta.DataBind();
    }
}
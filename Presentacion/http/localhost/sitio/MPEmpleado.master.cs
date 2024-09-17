using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EC;


public partial class MPEmpleado : System.Web.UI.MasterPage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!(Session["EmpleadoUss"] is Empleado))
                {
                    Response.Redirect("~/Default.aspx");
                }

                else
                {

                    //Muestro Usuario
                    MostrarUsu();
                }
            }
            catch
            {
                Response.Redirect("~/Default.aspx");
            }
            }
       
    }

    protected void BtnSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
    private void MostrarUsu()
    {
        Empleado  unEmp = infoEmpleado();
        if(unEmp !=null)
        {
            string nombre = unEmp.NomUsu;

            LblNomUsu.Text = nombre + " - ";
        }

            
    }

    public Empleado infoEmpleado()
    {
        if(Session["EmpleadoUss"] != null)
        {
            return (Empleado)Session["EmpleadoUss"];
        }

        else
        {
            return null;
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {

    }
}

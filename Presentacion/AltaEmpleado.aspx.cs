using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EC;
using Logica;

public partial class AltaEmpleado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                this.Limpiar();
                BtnAlta.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }


    public  void Limpiar()
    {
        TxtNomUsu.Text = "";
        TxtPassUsu.Text = "";


        LblError.Text = "";
        BtnAlta.Enabled = false;
    }





    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        this.Limpiar();

        BtnAlta.Enabled = false;
        BtnBuscar.Enabled = true;
        TxtNomUsu.Enabled = true;
        
    }


    protected void BtnBuscar_Click1(object sender, EventArgs e)
    {
        try
        {
            //Buscamos Empleado

            Empleado _unE = null;
            _unE = Logica.FabricaLogica.GetLogicaEmpleado().BuscarEmpleado(Convert.ToString(TxtNomUsu.Text.Trim().ToUpper()));
            if (_unE == null)
            {
                this.ActivoBT();
                throw new Exception("Empleado no Encontrado puede Darle Alta");

               
            }

            else
            {
                Session["Empleado"] = _unE;
                TxtNomUsu.Text = _unE.NomUsu;
                TxtPassUsu.Text = _unE.PassUsu;
                BtnAlta.Enabled = false;
                this.DescativoBT();

            }
        }

        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }

    }


    protected void Btn_Click1(object sender, EventArgs e)
    {

    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {

            Empleado _unE = new Empleado(TxtNomUsu.Text.Trim(), TxtPassUsu.Text.Trim());
            Logica.FabricaLogica.GetLogicaEmpleado().AltaEmpleado(_unE);

            LblError.Text = "Alta con Exito";

            DescativoBT();
        }

        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    public void ActivoBT()
    {
        BtnAlta.Enabled = true;
        BtnBuscar.Enabled = false;
    }

    public void DescativoBT()
    {
        BtnBuscar.Enabled = true;
        BtnAlta.Enabled = false;
    }

    protected void BtnLimpiar_Click1(object sender, EventArgs e)
    {
        TxtNomUsu.Text = "";
        TxtPassUsu.Text = "";
        BtnAlta.Enabled = false;
        BtnBuscar.Enabled = true;
    }
}
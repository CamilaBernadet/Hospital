using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EC;
using Logica;

public partial class AltaPoliclinica : System.Web.UI.Page
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


    public void Limpiar()
    {
        TxtCodigo.Text = "";
        TxtNombre.Text = "";
        TxtDireccion.Text = "";


        LblError.Text = "";

        BtnAlta.Enabled = false;
    }
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            //Buscamos Policlinica  

            Policlinica _unP = null;
            _unP = Logica.FabricaLogica.GetLogicaPoliclinica().BuscarPoliclinica(Convert.ToString(TxtCodigo.Text));
            if (_unP == null)
            {
                BtnAlta.Enabled = true;
                BtnBuscar.Enabled = false;
                TxtCodigo.Enabled = false;
                throw new Exception("Policlinica no Encontrado puede Darle Alta");
            }
            else
            {
                Session["Policlinicas"] = _unP;
                TxtCodigo.Text = _unP.Codigo;
                TxtNombre.Text = _unP.Nombre;
                TxtDireccion.Text = _unP.Direccion;
                BtnAlta.Enabled = false;
            }
        }

        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        this.Limpiar();

        BtnAlta.Enabled = false;
        BtnBuscar.Enabled = true;
        TxtCodigo.Enabled = true;
    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {

            Policlinica _unp = new Policlinica(TxtCodigo.Text.Trim().ToUpper(), TxtNombre.Text.Trim(), TxtDireccion.Text.Trim());
            Logica.FabricaLogica.GetLogicaPoliclinica().AltaPoliclinica(_unp);

            LblError.Text = "Alta con Exito";
            BtnAlta.Enabled = false;

        }

        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    
}
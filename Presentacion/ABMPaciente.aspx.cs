using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EC;
using Logica;

public partial class ABMPaciente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.DesactivoBT();
        }
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Paciente _unP = null;
             _unP = Logica.FabricaLogica.GetLogicaPaciente().BuscarPaciente(TxtCi.Text.Trim());

            if (_unP == null)
            {
                BtnAlta.Enabled = true;
                throw new Exception("El Paciente no Existe- Puede Darle de Alta");
                this.ActivoAltaBt();
            }
            else
            {

                BtnModificar.Enabled = true;
                BtnEliminar.Enabled = true;
                Session["Paciente"] = _unP;
                TxtCi.Text = _unP.CiPaciente;
                TxtNombre.Text = _unP.NomCompleto.ToString();
               TxtFN.Text = _unP.FechaNacimiento.ToShortDateString();

                LblPatologia.DataSource = _unP.Patologias;
                LblPatologia.DataTextField = "Patologia";
                LblPatologia.DataBind();
                LblPatologia.SelectedIndex = -1;

            }
        }
        catch (Exception ex)
        {
            LBLError.Text = ex.Message;
        }
    }

    protected void BtnLimp_Click(object sender, EventArgs e)
    {
        LblPatologia.Items.Clear();
        TxtCi.Text = "";
        TxtFN.Text = "";
        TxtNombre.Text = "";
        TxtPatologia.Text = "";
        TxtCi.Enabled = true;

        BtnBuscar.Enabled = true;

        BtnAlta.Enabled = false;
        BtnModificar.Enabled = false;
        BtnEliminar.Enabled = false;

        LBLError.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TxtPatologia.Text.Trim().Length > 0)
        {
            LblPatologia.Items.Add(TxtPatologia.Text.Trim());
            TxtPatologia.Text = "";
            LBLError.Text = "Patologia agregada con Exito";
        }

        else
            LBLError.Text = "Error al listar la Patologia";
    }

    protected void BtnBajaPatologia_Click(object sender, EventArgs e)
    {
        //Rectifico si hay algo seleccionado para eliminar

        if(LblPatologia.SelectedIndex >=0)
        {
            LblPatologia.Items.RemoveAt(LblPatologia.SelectedIndex);
            LBLError.Text = "Se Elimino la patologia de la lista con Exito";

        }
        else
        {
            LBLError.Text = "Debe Seleccionar Alguna patologia para poder eliminar";
        }
    }

    private List<Patologia> CargoParologias()
    {
        List<Patologia> _list = new List<Patologia>();
        foreach (ListItem unaPatologia in LblPatologia.Items)
            _list.Add(new Patologia(unaPatologia.Text.Trim()));

        return _list;

    }
    protected void BtnAlta_Click(object sender, EventArgs e)
    {
       

        try
        {
            Paciente unPaciente  = null;

             unPaciente = new Paciente(TxtCi.Text.Trim(), TxtNombre.Text.Trim(),
                 Convert.ToDateTime(TxtFN.Text), CargoParologias());

            
            FabricaLogica.GetLogicaPaciente().AltaPaciente(unPaciente);

           
            LBLError.Text = "Alta con Éxito";

            this.DesactivoBT();
        }
        catch(Exception ex)
        {

            LBLError.Text = ex.Message;
        }
    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Paciente _unP = (Paciente)Session["Paciente"];
            _unP.NomCompleto = TxtNombre.Text.Trim();
            _unP.FechaNacimiento = Convert.ToDateTime(TxtFN.Text.Trim());
            _unP.Patologias = CargoParologias();


            FabricaLogica.GetLogicaPaciente().ModificarPaciente(_unP);
            TxtCi.Enabled = true;
            TxtCi.ReadOnly = false;

            LBLError.Text = "Se Modifico con Exito";

            this.DesactivoBT();
        }

        catch (Exception ex)
        {
            LBLError.Text = ex.Message;
        }
    }

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        try
        { 
        Paciente _unP = (Paciente)Session["Paciente"];
        FabricaLogica.GetLogicaPaciente().EliminarPaciente(_unP);


        TxtCi.Enabled = true;
        TxtCi.ReadOnly = false;
        LBLError.Text = "Paciente Eliminado con Exito";

            this.DesactivoBT();
            
        }

        catch (Exception ex)

        {
            LBLError.Text = ex.Message;
        }
    }

    private void  ActivoAltaBt()
    {
        BtnBuscar.Enabled = false;

        BtnAlta.Enabled = true;
        BtnModificar.Enabled = false;
        BtnEliminar.Enabled = false;
    }

    private void ActivoBM()
    {
        BtnBuscar.Enabled = false;

        BtnAlta.Enabled = false;
        BtnModificar.Enabled = true;
        BtnEliminar.Enabled = true;
    }

    private void DesactivoBT()
    {
        BtnBuscar.Enabled = true;

        BtnAlta.Enabled = false;
        BtnModificar.Enabled = false;
        BtnEliminar.Enabled = false;
    }
}
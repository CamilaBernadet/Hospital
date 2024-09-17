using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EC;
using Logica;

public partial class AltaSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                btnAltaSolicitud.Enabled = false;
                // Cargar Consultas
                List<Consulta> consultas = Logica.FabricaLogica.GetLogicaConsulta().ListarConsulta();
                if (consultas.Count > 0)
                {
                    DdlNroConsulta.DataSource = consultas;
                    DdlNroConsulta.DataTextField = "NumConsulta";
                    DdlNroConsulta.DataValueField = "NumConsulta";
                    DdlNroConsulta.DataBind();
                    DdlNroConsulta.Items.Insert(0, "Seleccione");

                    ddlTipoConsulta.DataSource = consultas;
                    ddlTipoConsulta.DataTextField = "Especialidad";
                    ddlTipoConsulta.DataValueField = "Especialidad";
                    ddlTipoConsulta.DataBind();
                    ddlTipoConsulta.Items.Insert(0, "Seleccione");


                    Session["listarConsulta"] = consultas;
                }
                else
                {
                    lblError.Text = "Error: No existe ninguna Consulta.";
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text =  ex.Message;
        }
    }





    protected void LimpioControles()
    {
        TxtPaciente.Text = "";
        LblPaciente.Text = "";
        lblError.Text = "";
    }

    protected void btnAltaSolicitud_Click(object sender, EventArgs e)
    {
        try
        {
            Consulta _unNConsulta = ((List<Consulta>)Session["listarConsulta"])[DdlNroConsulta.SelectedIndex - 1];

            if (_unNConsulta == null)
                lblError.Text = "Debe Seleccionar un Numero de Consulta";

            Consulta _unTConsulta = ((List<Consulta>)Session["listarConsulta"])[ddlTipoConsulta.SelectedIndex - 1];

            if (_unTConsulta == null)
                lblError.Text = "Debe Selecionar un tipo de Consulta";

            string pacienteCi = TxtPaciente.Text.Trim();
            if (pacienteCi.Length == 0)
            {
                lblError.Text = "Debe ingresar la CI del Paciente.";
                return;
            }

            Paciente _unP = Logica.FabricaLogica.GetLogicaPaciente().BuscarPaciente(pacienteCi);

            if (_unP == null)
            {
                lblError.Text = "El Paciente con la CI ingresada no existe.";
                return;
            }

            EC.Empleado empleadoLogueado = (EC.Empleado)Session["EmpleadoUss"];
            if (empleadoLogueado == null)
            {
                lblError.Text = "No se encontró el empleado logueado.";
                return;
            }

            // Crear la solicitud
            Solicitud _unaSol = new Solicitud(0, DateTime.Now, false, _unP, _unNConsulta, empleadoLogueado);
            Logica.FabricaLogica.GetLogicaSolicitud().AltaSolicitud(_unaSol);

            // Si llegó acá, la alta fue exitosa
            lblError.Text = "Alta con Éxito.";
            
        }
        catch (Exception ex)
        {
            lblError.Text = "Error: " + ex.Message;
        }
    }




    protected void BtnPaciente_Click(object sender, EventArgs e)
    {
        try
        {
            Paciente _unP = FabricaLogica.GetLogicaPaciente().BuscarPaciente(TxtPaciente.Text.Trim());

            if (_unP == null)
                throw new Exception("El Paciente no Existe");
            else
            {
                Session["Paciente"] = _unP;
                LblPaciente.Text = _unP.ToString();
                lblError.Text = "";
                BtnPaciente.Enabled = false;
                btnAltaSolicitud.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Error: " + ex.Message;
        }
    }

    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioControles();
        btnAltaSolicitud.Enabled = false;
        BtnPaciente.Enabled = true;
    }
}





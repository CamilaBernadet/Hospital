using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EC;
using Logica;


public partial class ABMConsultorio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                //Cargo policlinicas en el drop

                List<Policlinica> _unaP = FabricaLogica.GetLogicaPoliclinica().ListarPoliclinica();

                Session["Policlinica"] = _unaP;

                DdlPoliclinica.DataSource = _unaP;
                DdlPoliclinica.DataTextField = "Nombre";
                DdlPoliclinica.DataValueField = "Codigo"; 
                DdlPoliclinica.DataBind();

                DdlPoliclinica.Items.Insert(0, "Seleccione Policlinica");


            }
            
        }

        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
        }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            int _NumConsultorio = Convert.ToInt32(TxtNumero.Text);
            string _unP = DdlPoliclinica.SelectedValue;

            

            Consultorio _unConsultorio = FabricaLogica.GetLogicaConsultorio().BuscarConsultorio(_NumConsultorio, _unP);

            if (_unConsultorio != null)
            {
                TxtNumero.Text = _unConsultorio.NumConsultorio.ToString();
                TxtDescripcion.Text = _unConsultorio.Descripcion;

                Policlinica _unaP = _unConsultorio.UnaPol;

                
                DdlPoliclinica.SelectedValue = _unaP.Codigo;

                Session["Consultorio"] = _unConsultorio;

                this.ActivoBTBM();
            }
            else
            {
                LblError.Text = "El consultorio no existe o no señalo Policlinica";
                this.ActivoAltaBT();
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Consultorio _unConsultorio = (Consultorio)Session["Consultorio"];
            FabricaLogica.GetLogicaConsultorio().BajaConsultorio(_unConsultorio);

            LblError.Text = "Seliminaron los datos Correctamente";

            this.DesactivosBT();
        }

        catch (Exception ex)
        {
            LblError.Text = "No se puede eliminar";
        }
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            List<Policlinica> listaPoliclinicas = FabricaLogica.GetLogicaPoliclinica().ListarPoliclinica();

            
            int indexSeleccionado = DdlPoliclinica.SelectedIndex;

            
            if (indexSeleccionado > 0 && indexSeleccionado < listaPoliclinicas.Count + 1)
            {
                
                Policlinica policlinicaSeleccionada = listaPoliclinicas[indexSeleccionado - 1];

                
                Consultorio _unConsultorio = new Consultorio(
                    Convert.ToInt32(TxtNumero.Text),
                    TxtDescripcion.Text.Trim(),
                    policlinicaSeleccionada
                );

               
                FabricaLogica.GetLogicaConsultorio().AltaConsultorio(_unConsultorio);

                LblError.Text = "Alta con Éxito";

                this.DesactivosBT();
                
            }
            else
            {
                LblError.Text = "Error al dar de alta. Seleccione una policlínica válida.";

            }
        }
        

        catch(Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void Liempiar_Click(object sender, EventArgs e)
    {
        this.Limpio();
    }

    public void Limpio()
    {
        TxtNumero.Text = "";
        TxtDescripcion.Text = "";
        DdlPoliclinica.SelectedIndex = (0);
        LblError.Text = "";
        this.DesactivosBT();
    }

    public  void DesactivosBT()
    {
        btnAlta.Enabled = false;
        BtnBuscar.Enabled = true;
        BtnModificar.Enabled = false;
        BtnEliminar.Enabled = false;
        
    }
    public void ActivoAltaBT() 
    {
        btnAlta.Enabled = true;
        BtnBuscar.Enabled = false;
        BtnModificar.Enabled = false;
        BtnEliminar.Enabled = false;
    }
    public void ActivoBTBM()
    {
        btnAlta.Enabled = false;
        BtnBuscar.Enabled = false;
        BtnModificar.Enabled = true;
        BtnEliminar.Enabled = true;
    }



    protected void BtnModificar_Click(object sender, EventArgs e)
    {

    }
}

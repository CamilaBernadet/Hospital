using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Logica;
using EC;

public partial class ListadodeCosnultas : System.Web.UI.Page
{

    List<Consulta> _unaCons = null;
    List<Solicitud> _unaSol = null;
    List<Consulta> _ConsPorPoliclinica = null;

    List<Policlinica> _unaP = null;//Verificaar creo q no necesito
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {   

                _unaCons = Logica.FabricaLogica.GetLogicaConsulta().ListarConsultaAFuturo();

                //Arrglar Solicitudes el listar por consultas

                _unaSol = FabricaLogica.GetLogicaSolicitud().ListarSolicitudes();

                _unaP = FabricaLogica.GetLogicaPoliclinica().ListarPoliclinica();

                CargoTodo();
            }

            else
            {
                _unaCons = (List<Consulta>)Session["LisConsulta"];
                _unaSol = (List<Solicitud>)Session["Solicitud"];
                _unaP = (List<Policlinica>)Session["Policlinica"];
                _ConsPorPoliclinica = (List<Consulta>)Session["ConsPorPoliclinica"];
            }
        }
        catch (Exception ex)
        {
            LblError.Text =  ex.Message;
        }
    }


    private void CargoTodo()
    {
        DdlConsulta.DataSource = _unaCons;
        DdlConsulta.DataTextField = "NumConsulta";
        DdlConsulta.DataBind();
        DdlConsulta.Items.Insert(0, "Seleccione Consulta");


        DdlPoliclinica.DataSource = _unaP;
        DdlPoliclinica.DataTextField = "Codigo";
        DdlPoliclinica.DataValueField = "Codigo";
        DdlPoliclinica.DataBind();
        DdlPoliclinica.Items.Insert(0, "Seleccione Policlinica");

        Gvconsulta.DataSource = _unaCons;
        Gvconsulta.DataBind();
    }


   
    protected void Gvconsulta_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gvconsulta.PageIndex = e.NewPageIndex;

        Gvconsulta.DataSource = Session["LisConsulta"];
        Gvconsulta.DataBind();
    }

    protected void BtnFiltrar_Click(object sender, EventArgs e)
    {
        try
        {
            List<Solicitud> _LsitSol = (List<Solicitud>)Session["Solicitud"];

            if(DdlConsulta.SelectedIndex >0)
            {
                Consulta unC = _unaCons[DdlConsulta.SelectedIndex - 1];

                _LsitSol = (from unS in _LsitSol
                            where unS.UnC.NumConsulta == unC.NumConsulta
                            select unS).ToList();
            }


            //Policlinica

            if (DdlPoliclinica.SelectedIndex > 0)
            {
                Policlinica unaP = _unaP[DdlPoliclinica.SelectedIndex - 1];

                _LsitSol = (from unS in _LsitSol
                            where unS.UnC.UnConsultorio.UnaPol.Codigo == unaP.Codigo
                            select unS).ToList();

            }

            //Mes Año

            if (TxtMes.Text.Trim().Length > 0 && TxtAños.Text.Trim().Length > 0)
            {
                int unMes = Convert.ToInt32(TxtMes.Text);
                int unAño = Convert.ToInt32(TxtAños.Text);

                if (unMes >= 1 && unMes <= 12 && unAño >= 2000 && unAño <= DateTime.Now.Year)
                {
                    _LsitSol = (from unC in _LsitSol
                                where unC.FechaHora.Month == unMes && unC.FechaHora.Year == unAño
                                select unC).ToList();
                }
                else
                    throw new Exception("Error al ingresar mes Año");
            }


            //Resultado de lo filtrado
            Gvconsulta.DataSource = _LsitSol;
            Gvconsulta.DataBind();
        }

        catch(Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void DdlConsulta_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {


            if (DdlConsulta.SelectedIndex > 0)
            {

                Consulta unaCons = _unaCons[DdlConsulta.SelectedIndex - 1];


                Session["ConsPorPoliclinica"] = _ConsPorPoliclinica
                             .Where(C => C.UnConsultorio.UnaPol.Codigo == unaCons.UnConsultorio.UnaPol.Codigo).ToList();



                DdlPoliclinica.DataSource = Session["ConsPorPoliclinica"];
                DdlPoliclinica.DataTextField = "Codigo";
                DdlPoliclinica.DataValueField = "Codigo";
                DdlPoliclinica.DataBind();
                DdlPoliclinica.Items.Insert(0, "Seleccione Policlinica");


            }

            else
            {

                DdlPoliclinica.DataSource = _unaP;
                DdlPoliclinica.DataTextField = "Codigo";
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

    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        Gvconsulta.DataSource = null;
        Gvconsulta.DataBind();

        GvSolicitudes.DataSource = null;
        GvSolicitudes.DataBind();

        DdlConsulta.SelectedIndex = 0;
        DdlPoliclinica.SelectedIndex = 0;

        TxtAños.Text = "";
        TxtMes.Text = "";

        CargoTodo();

       
    }


}

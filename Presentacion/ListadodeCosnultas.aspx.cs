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

    List<Consulta> _Consultas = null;
    List<Policlinica> _Policlinicas = null;
    List<Solicitud> _Solicitudes = null;  // Lista para solicitudes



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                // Cargar datos en la sesión
                Session["Consultas"] = _Consultas = Logica.FabricaLogica.GetLogicaConsulta().ListarConsulta();
                Session["Policlinicas"] = _Policlinicas = Logica.FabricaLogica.GetLogicaPoliclinica().ListarPoliclinica();
                
                Session["Solicitudes"] = _Solicitudes = Logica.FabricaLogica.GetLogicaSolicitud().ListarSolicitudes(); 

                CargoTodo();
            }
            else
            {
                _Consultas = (List<Consulta>)Session["Consultas"];
                _Policlinicas = (List<Policlinica>)Session["Policlinicas"];
                _Solicitudes = (List<Solicitud>)Session["Solicitudes"];
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }


    private void CargoTodo()
    {

        // Cargar consultas en el DropDownList
        DdlConsulta.DataSource = _Consultas;
        DdlConsulta.DataTextField = "NumConsulta";
        DdlConsulta.DataValueField = "NumConsulta";
        DdlConsulta.DataBind();
        DdlConsulta.Items.Insert(0, "Seleccione Consulta");

        // Cargar policlínicas en el DropDownList
        DdlPoliclinica.DataSource = _Policlinicas;
        DdlPoliclinica.DataTextField = "Codigo";
        DdlPoliclinica.DataValueField = "Codigo";
        DdlPoliclinica.DataBind();
        DdlPoliclinica.Items.Insert(0, "Seleccione Policlinica");

        GvSolicitudes.DataSource = (List<Solicitud>)Session["Solicitudes"];
        GvSolicitudes.DataBind();

        Gvconsulta.DataSource = (List<Consulta>)Session["Consultas"];
        Gvconsulta.DataBind();
    }


   
    protected void Gvconsulta_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gvconsulta.PageIndex = e.NewPageIndex;
        Gvconsulta.DataSource = (List<Consulta>)Session["Consultas"];
        Gvconsulta.DataBind();
    }

    protected void BtnFiltrar_Click(object sender, EventArgs e)
    {
        try
        {
            List<Consulta> _ListC = (List<Consulta>)Session["Consultas"];

            // Filtrar por número de consulta
            if (DdlConsulta.SelectedIndex > 0)
            {
                string selectedConsultaNum = DdlConsulta.SelectedValue;
                _ListC = (from c in _ListC
                          where c.NumConsulta.ToString() == selectedConsultaNum
                          select c).ToList();
            }
             

            // Filtrar por policlínica
            if (DdlPoliclinica.SelectedIndex > 0)
            {
                string selectedPoliclinicaCodigo = DdlPoliclinica.SelectedValue;
                _ListC = (from c in _ListC
                          where c.UnConsultorio.UnaPol.Codigo == selectedPoliclinicaCodigo
                          select c).ToList();
            }
            

            // Filtrar por mes y año
            if (TxtMes.Text.Trim().Length > 0 && TxtAños.Text.Trim().Length > 0)
            {
                int unMes = Convert.ToInt32(TxtMes.Text.Trim());
                int unAño = Convert.ToInt32(TxtAños.Text.Trim());

                if (unMes >= 1 && unMes <= 12 && unAño >= 2000 && unAño <= DateTime.Now.Year)
                {
                    _ListC = (from c in _ListC
                              where c.FechaHoraConsulta.Month == unMes && c.FechaHoraConsulta.Year == unAño
                              select c).ToList();
                }
                else
                {
                    throw new Exception("Error al ingresar Mes / Año");
                }
            }

            // Mostrar las consultas filtradas en el GridView
            Gvconsulta.DataSource = _ListC;
            Gvconsulta.DataBind();
        }
        catch (Exception ex)
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
                string selectedConsultaNum = DdlConsulta.SelectedValue;
                Consulta selectedConsulta = _Consultas.First(c => c.NumConsulta.ToString() == selectedConsultaNum);

                if (selectedConsulta != null)
                {
                    // Filtrar las solicitudes asociadas a la consulta seleccionada
                    _Solicitudes = (from s in _Solicitudes
                                    where s.UnC.NumConsulta == selectedConsulta.NumConsulta
                                    select s).ToList();

                    // Mostrar las solicitudes en el GridView
                    GvSolicitudes.DataSource = _Solicitudes;
                    GvSolicitudes.DataBind();

                    // Actualizar el DropDownList de policlínicas según la consulta seleccionada
                    var policlinicas = (from p in _Policlinicas
                                        where _Consultas.Any(c => c.UnConsultorio.UnaPol.Codigo == p.Codigo && c.NumConsulta.ToString() == selectedConsultaNum)
                                        select p).ToList();

                    
                    Session["PoliclinicasFiltradas"] = policlinicas;

                    
                    DdlPoliclinica.DataSource = policlinicas;
                    DdlPoliclinica.DataTextField = "Codigo";
                    DdlPoliclinica.DataValueField = "Codigo";
                    DdlPoliclinica.DataBind();
                    DdlPoliclinica.Items.Insert(0, "Seleccione Policlinica");
                }
            }
            else
            {
                
                GvSolicitudes.DataSource = null;
                GvSolicitudes.DataBind();

             
                DdlPoliclinica.DataSource = _Policlinicas;
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
        try
        {
            // Limpiar filtros y recargar datos originales
            DdlConsulta.SelectedIndex = 0;
            DdlPoliclinica.SelectedIndex = 0;
            TxtAños.Text = "";
            TxtMes.Text = "";
            LblError.Text = "";

            // Mostrar todas las consultas y solicitudes
            Gvconsulta.DataSource = (List<Consulta>)Session["Consultas"];
            Gvconsulta.DataBind();

            GvSolicitudes.DataSource = (List<Solicitud>)Session["Solicitudes"];
            GvSolicitudes.DataBind();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }

    }



    protected void DdlPoliclinica_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void GvSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }

    protected void GvSolicitudes_PageIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void GvSolicitudes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvSolicitudes.PageIndex = e.NewPageIndex;
        GvSolicitudes.DataSource = (List<Solicitud>)Session["Solicitudes"];
        GvSolicitudes.DataBind();
    }
}

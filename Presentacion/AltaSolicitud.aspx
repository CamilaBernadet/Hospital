<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="AltaSolicitud.aspx.cs" Inherits="AltaSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style13 {
            width: 723px;
        }
        .auto-style14 {
            width: 218px;
        }
        .auto-style15 {
            width: 221px;
        }
        .auto-style16 {
            width: 218px;
            height: 23px;
        }
        .auto-style17 {
            width: 221px;
            height: 23px;
        }
        .auto-style18 {
            height: 23px;
        }
        .auto-style19 {
            width: 723px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style13">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Alta Solicitud</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style13">
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style14">Seleccione Consultorio</td>
                        <td class="auto-style15">
                            <asp:DropDownList ID="DdlNroConsulta" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style14">&nbsp;</td>
                        <td class="auto-style15">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style14">Tipo de Consulta</td>
                        <td class="auto-style15">
                            <asp:DropDownList ID="ddlTipoConsulta" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style16"></td>
                        <td class="auto-style17"></td>
                        <td class="auto-style18"></td>
                    </tr>
                    <tr>
                        <td class="auto-style14">Ingrese C.I de Paciente</td>
                        <td class="auto-style15">
                            <asp:TextBox ID="TxtPaciente" runat="server" Width="191px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="BtnPaciente" runat="server" OnClick="BtnPaciente_Click" Text="Buscar Paciente" Width="146px" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style16">Datos de Paciente </td>
                        <td class="auto-style17">
                            <asp:Label ID="LblPaciente" runat="server" ForeColor="#6600FF"></asp:Label>
                            </td>
                        <td class="auto-style18">
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style14">&nbsp;</td>
                        <td class="auto-style15">
                            &nbsp;</td>
                        <td>
                            
                            <asp:Button ID="btnAltaSolicitud" runat="server" Text="Agregar!" OnClick="btnAltaSolicitud_Click" />
                            
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18"></td>
            <td class="auto-style19">
                <asp:Button ID="BtnLimpiar" runat="server" OnClick="BtnLimpiar_Click" Text="Validar Formulario" Width="135px" />
            </td>
            <td class="auto-style18"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style13">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="AltaConsulta.aspx.cs" Inherits="AltaConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style12 {
        width: 260px;
    }
    .auto-style13 {
        width: 683px;
    }
    .auto-style14 {
        width: 193px;
    }
    .auto-style15 {
        width: 193px;
        height: 25px;
    }
    .auto-style16 {
        height: 25px;
    }
    .auto-style17 {
        margin-left: 0px;
    }
    .auto-style18 {
        width: 200px;
    }
    .auto-style19 {
        height: 25px;
        width: 200px;
    }
        .auto-style20 {
            width: 260px;
            height: 22px;
        }
        .auto-style21 {
            width: 683px;
            height: 22px;
        }
        .auto-style23 {
            width: 260px;
        }
        .auto-style24 {
            width: 260px;
            height: 9px;
        }
        .auto-style25 {
            width: 683px;
            height: 9px;
        }
        .auto-style27 {
            width: 260px;
            height: 41px;
        }
        .auto-style28 {
            width: 683px;
            height: 41px;
        }
        .auto-style29 {
            width: 260px;
            height: 481px;
        }
        .auto-style30 {
            width: 78%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td class="auto-style27"></td>
        <td class="auto-style28">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AltaConsulta</td>
    </tr>
    <tr>
        <td class="auto-style23"></td>
        <td class="auto-style13"></td>
    </tr>
    <tr>
        <td class="auto-style23"></td>
        <td class="auto-style13"></td>
    </tr>
    <tr>
        <td class="auto-style29">&nbsp;</td>
        <td class="auto-style13">
            <table class="auto-style30">
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style18">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style18">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">Nombre Medico:</td>
                    <td class="auto-style18">
                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style18">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">Especialidad:</td>
                    <td class="auto-style18">
                        <asp:TextBox ID="TxtEspecialidad" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style18">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style15">Fecha Hora Consulta:</td>
                    <td class="auto-style19">
                        <asp:TextBox ID="TxtFechaHora" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style16"></td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style18">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">Cantidad de Consultas:</td>
                    <td class="auto-style18">
                        <asp:TextBox ID="TxtCantidad" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style18">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">Consultorio:</td>
                    <td class="auto-style18">
                        <asp:DropDownList ID="DdlConsultorio" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style18">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style18">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style18">
                        <asp:Button ID="BtnLimpiar" runat="server" OnClick="BtnLimpiar_Click" Text="Limpiar Formulario" />
                    </td>
                    <td>
                        <asp:Button ID="BtnAlta" runat="server" CssClass="auto-style17" Text="Agregar" OnClick="BtnAlta_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="auto-style20"></td>
        <td class="auto-style21">
            <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style23"></td>
        <td class="auto-style13"></td>
    </tr>
    <tr>
        <td class="auto-style24"></td>
        <td class="auto-style25"></td>
    </tr>
</table>
</asp:Content>


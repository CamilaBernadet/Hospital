<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="ABMConsultorio.aspx.cs" Inherits="ABMConsultorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style13 {
        width: 172px;
    }
    .auto-style14 {
        width: 815px;
    }
    .auto-style15 {
        width: 172px;
        height: 24px;
    }
    .auto-style17 {
        width: 280px;
    }
    .auto-style18 {
        height: 24px;
        width: 280px;
    }
    .auto-style19 {
        width: 172px;
        height: 71px;
    }
    .auto-style20 {
        width: 280px;
        height: 71px;
    }
    .auto-style22 {
        margin-top: 0px;
    }
    .auto-style23 {
        height: 47px;
    }
    .auto-style24 {
        width: 815px;
        height: 47px;
    }
        .auto-style25 {
            width: 100%;
        }
        .auto-style26 {
            width: 265px;
        }
        .auto-style27 {
            height: 24px;
            width: 265px;
        }
        .auto-style28 {
            width: 265px;
            height: 71px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style23"></td>
        <td class="auto-style24">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ABM Consultorio</td>
        <td class="auto-style23"></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style14">
            <table class="auto-style25">
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td class="auto-style26">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">Numero Consultorio</td>
                    <td class="auto-style17">
                        <asp:TextBox ID="TxtNumero" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style26">
                        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style19">Descripcion</td>
                    <td class="auto-style20">
                        <asp:TextBox ID="TxtDescripcion" runat="server" CssClass="auto-style22" Height="59px" Width="320px"></asp:TextBox>
                    </td>
                    <td class="auto-style28"></td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td class="auto-style26">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">Policlinica</td>
                    <td class="auto-style17">
                        <asp:DropDownList ID="DdlPoliclinica" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style26">
                        <asp:Button ID="Liempiar" runat="server" Text="LimpiarF" OnClick="Liempiar_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td class="auto-style26">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style17">
                        <asp:Button ID="btnAlta" runat="server" Text="Agregar" OnClick="btnAlta_Click" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" />
                        <asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClick="BtnModificar_Click" />
                    </td>
                    <td class="auto-style26">&nbsp;</td>
                </tr>
            </table>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style14">
            <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>


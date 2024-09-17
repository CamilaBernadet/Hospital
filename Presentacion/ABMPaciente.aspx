<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="ABMPaciente.aspx.cs" Inherits="ABMPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style13 {
            width: 793px;
        }
    .auto-style14 {
        height: 26px;
    }
    .auto-style15 {
        width: 793px;
        height: 26px;
    }
    .auto-style16 {
        width: 162px;
    }
    .auto-style17 {
        width: 280px;
    }
    .auto-style18 {
        width: 162px;
        height: 85px;
    }
    .auto-style19 {
        width: 280px;
        height: 85px;
    }
    .auto-style20 {
        height: 85px;
    }
    .auto-style22 {
        width: 162px;
        height: 26px;
    }
    .auto-style23 {
        width: 280px;
        height: 26px;
    }
        .auto-style24 {
            width: 252px;
        }
        .auto-style25 {
            width: 252px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td class="auto-style24">&nbsp;</td>
        <td class="auto-style13">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ABM Paciente</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style24">&nbsp;</td>
        <td class="auto-style13">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style25"></td>
        <td class="auto-style15">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">Ci:</td>
                    <td class="auto-style17">
                        <asp:TextBox ID="TxtCi" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">Nombre:</td>
                    <td class="auto-style17">
                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="BtnLimp" runat="server" Text="LimpiarF" OnClick="BtnLimp_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">Fecha Nacimiento:</td>
                    <td class="auto-style17">
                        <asp:TextBox ID="TxtFN" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style22"></td>
                    <td class="auto-style23"></td>
                    <td class="auto-style14"></td>
                </tr>
                <tr>
                    <td class="auto-style22"></td>
                    <td class="auto-style23">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Patologia</td>
                    <td class="auto-style14"></td>
                </tr>
                <tr>
                    <td class="auto-style18">
                        <asp:Button ID="BtnBajaPatologia" runat="server" OnClick="BtnBajaPatologia_Click" Text="Eliminar Patologia" />
                    </td>
                    <td class="auto-style19">
                        <asp:ListBox ID="LblPatologia" runat="server" Width="258px"></asp:ListBox>
                    </td>
                    <td class="auto-style20">
                        <asp:TextBox ID="TxtPatologia" runat="server"></asp:TextBox>
                        <asp:Button ID="AltaPatologia" runat="server" OnClick="Button1_Click" Text="Nueva Patologia" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style17">
                        <asp:Button ID="BtnAlta" runat="server" Text="Agregar" OnClick="BtnAlta_Click" />
                        <asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClick="BtnModificar_Click" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </td>
        <td class="auto-style14">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style24">&nbsp;</td>
        <td class="auto-style13">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style24">&nbsp;</td>
        <td class="auto-style13">
            <asp:Label ID="LBLError" runat="server" ForeColor="Red"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>


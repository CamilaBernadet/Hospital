<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="AltaEmpleado.aspx.cs" Inherits="AltaEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style11 {
        width: 100%;
    }
    .auto-style12 {
        width: 837px;
    }
    .auto-style13 {
        width: 173px;
    }
        .auto-style16 {
            width: 160px;
            height: 19px;
        }
        .auto-style17 {
            width: 837px;
            height: 19px;
        }
        .auto-style19 {
            width: 160px;
        }
        .auto-style20 {
            width: 837px;
        }
        .auto-style22 {
            width: 837px;
            height: 68px;
        }
        .auto-style23 {
            width: 160px;
            height: 68px;
        }
        .auto-style26 {
            width: 837px;
            height: 24px;
        }
        .auto-style27 {
            width: 160px;
            height: 24px;
        }
        .auto-style30 {
            width: 837px;
            height: 85px;
        }
        .auto-style31 {
            width: 160px;
            height: 85px;
        }
        .auto-style33 {
            width: 160px;
            height: 28px;
        }
        .auto-style34 {
            width: 837px;
            height: 28px;
        }
        .auto-style37 {
            width: 837px;
            height: 13px;
        }
        .auto-style39 {
            height: 13px;
            width: 160px;
        }
        .auto-style41 {
            width: 837px;
            height: 15px;
        }
        .auto-style43 {
            width: 160px;
            height: 18px;
        }
        .auto-style44 {
            width: 837px;
            height: 18px;
        }
        .auto-style46 {
            width: 160px;
            height: 16px;
        }
        .auto-style47 {
            width: 837px;
            height: 16px;
        }
        .auto-style50 {
            width: 160px;
            height: 7px;
        }
        .auto-style51 {
            width: 837px;
            height: 7px;
        }
        .auto-style53 {
            width: 100%;
            height: 471px;
            margin-right: 0px;
            margin-bottom: 0px;
        }
        .auto-style54 {
            height: 15px;
            width: 160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style53">
    <tr>
        <td class="auto-style23"></td>
        <td class="auto-style22">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ALta Empleado</td>
    </tr>
    <tr>
        <td class="auto-style27"></td>
        <td class="auto-style26"></td>
    </tr>
    <tr>
        <td class="auto-style16"></td>
        <td class="auto-style17"></td>
    </tr>
    <tr>
        <td class="auto-style19"></td>
        <td class="auto-style20"></td>
    </tr>
    <tr>
        <td class="auto-style31"></td>
        <td class="auto-style30">
            <table class="auto-style11">
                <tr>
                    <td class="auto-style13">Nombre de Usuario</td>
                    <td>
                        <asp:TextBox ID="TxtNomUsu" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click1" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style13">Contraseña</td>
                    <td>
                        <asp:TextBox ID="TxtPassUsu" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="auto-style33"></td>
        <td class="auto-style34">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnAlta" runat="server" OnClick="BtnAlta_Click" Text="Agregar" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td class="auto-style39"></td>
        <td class="auto-style37"></td>
    </tr>
    <tr>
        <td class="auto-style54"></td>
        <td class="auto-style41">
            <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style43"></td>
        <td class="auto-style44"></td>
    </tr>
    <tr>
        <td class="auto-style19"></td>
        <td class="auto-style20"></td>
    </tr>
    <tr>
        <td class="auto-style46"></td>
        <td class="auto-style47"></td>
    </tr>
    <tr>
        <td class="auto-style50"></td>
        <td class="auto-style51"></td>
    </tr>
    <tr>
        <td class="auto-style19"></td>
        <td class="auto-style20"></td>
    </tr>
</table>
</asp:Content>


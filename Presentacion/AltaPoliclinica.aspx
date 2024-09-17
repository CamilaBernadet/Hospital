<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="AltaPoliclinica.aspx.cs" Inherits="AltaPoliclinica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style13 {
            width: 813px;
        }
        .auto-style14 {
            width: 260px;
        }
        .auto-style15 {
            height: 33px;
        }
        .auto-style17 {
            height: 33px;
            width: 135px;
        }
        .auto-style18 {
            width: 135px;
        }
        .auto-style19 {
            width: 250px;
        }
        .auto-style20 {
            height: 33px;
            width: 250px;
        }
        .auto-style21 {
            width: 135px;
            height: 29px;
        }
        .auto-style22 {
            width: 250px;
            height: 29px;
        }
        .auto-style23 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Alta Policlinica</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style19">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style21">Codig:</td>
                        <td class="auto-style22">
                            <asp:TextBox ID="TxtCodigo" runat="server" Width="186px"></asp:TextBox>
                        </td>
                        <td class="auto-style23">
                            <asp:Button ID="BtnBuscar" runat="server" OnClick="BtnBuscar_Click" Text="Buscar" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style19">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style18">Nombre:</td>
                        <td class="auto-style19">
                            <asp:TextBox ID="TxtNombre" runat="server" Width="184px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="BtnLimpiar" runat="server" OnClick="BtnLimpiar_Click" Text="LimpiarF" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17"></td>
                        <td class="auto-style20"></td>
                        <td class="auto-style15"></td>
                    </tr>
                    <tr>
                        <td class="auto-style18">Direccion:</td>
                        <td class="auto-style19">
                            <asp:TextBox ID="TxtDireccion" runat="server" Width="183px"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style19">
                            <asp:Button ID="BtnAlta" runat="server" OnClick="BtnAlta_Click" Text="Agregar" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">
                <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="Estadísticas .aspx.cs" Inherits="Estadísticas_" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style13 {
            height: 173px;
        }
        .auto-style14 {
            width: 352px;
            height: 34px;
        }
        .auto-style15 {
            margin-right: 0px;
            margin-left: 214px;
        }
        .auto-style16 {
            height: 34px;
        }
        .auto-style17 {
            height: 173px;
            width: 352px;
        }
        .auto-style18 {
            height: 34px;
            width: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="height: 100px; width: 100px">
            <table style="width:100%;">
                <tr>
                    <td colspan="4">Listado comparativo de cantidad de solicitudes</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GvSolicitudesP" runat="server" OnSelectedIndexChanged="GvLista1_SelectedIndexChanged1">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        Estadistica por asistencia
                    </td>
                    <td class="auto-style18">
                        <asp:Button ID="BtnEstadistica1" runat="server" OnClick="Button1_Click" Text="Filtrar" CssClass="auto-style15" Width="61px" />
                    </td>
                    <td class="auto-style16">
                        &nbsp;</td>
                    <td class="auto-style16">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">Listado comparativo de cantidad de consultas por consultorio</tr>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="LblError" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
            </table>
        &nbsp;&nbsp;&nbsp;
    </p>
</asp:Content>


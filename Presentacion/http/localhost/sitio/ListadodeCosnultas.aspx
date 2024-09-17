<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="ListadodeCosnultas.aspx.cs" Inherits="ListadodeCosnultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style13 {
        width: 178px;
    }
    .auto-style14 {
        width: 665px;
    }
    .auto-style15 {
        width: 178px;
        height: 28px;
    }
    .auto-style16 {
        width: 665px;
        height: 28px;
    }
    .auto-style17 {
        height: 28px;
    }
        .auto-style19 {
            width: 85px;
        }
        .auto-style21 {
            width: 644px;
        }
        .auto-style26 {
            height: 60px;
        }
        .auto-style27 {
            height: 60px;
            width: 644px;
        }
        .auto-style28 {
            height: 60px;
            width: 85px;
        }
        .auto-style29 {
            height: 61px;
        }
        .auto-style30 {
            height: 61px;
            width: 644px;
        }
        .auto-style31 {
            height: 61px;
            width: 85px;
        }
        .auto-style33 {
            height: 69px;
            width: 644px;
        }
        .auto-style34 {
            height: 69px;
            width: 85px;
        }
        .auto-style35 {
            height: 69px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td class="auto-style14">Listado de consultas</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td class="auto-style14">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27">Selecione Consulta:
                        <asp:DropDownList ID="DdlConsulta" runat="server" Height="16px" Width="224px" OnSelectedIndexChanged="DdlConsulta_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style28"></td>
                </tr>
                <tr>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Seleccione una Policlinica:
                        <asp:DropDownList ID="DdlPoliclinica" runat="server" Height="16px" Width="224px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style31"></td>
                </tr>
                <tr>
                    <td class="auto-style35"></td>
                    <td class="auto-style33">
                        <asp:Button ID="BtnFiltrar" runat="server" Text="Filtrar" OnClick="BtnFiltrar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mes:&nbsp;
&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TxtMes" runat="server" Width="80px"></asp:TextBox>
                        &nbsp;&nbsp;Año:&nbsp;&nbsp;<asp:TextBox ID="TxtAños" runat="server" Height="18px" Width="77px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="auto-style34"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style21">
                        <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar Filtros" Width="106px" OnClick="BtnLimpiar_Click" />
            <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td class="auto-style19">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style21">Listado:</td>
                    <td class="auto-style19">Solicitudes</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style21">
                        <asp:GridView ID="Gvconsulta" runat="server" Width="621px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" OnPageIndexChanging="Gvconsulta_PageIndexChanging">
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                        </asp:GridView>
                    </td>
                    <td class="auto-style19">
                        <asp:GridView ID="GvSolicitudes" runat="server" Width="535px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" OnPageIndexChanging="Gvconsulta_PageIndexChanging">
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td class="auto-style14">
                        &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style15"></td>
        <td class="auto-style16">
        </td>
        <td class="auto-style17"></td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td class="auto-style14">
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style13">&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>


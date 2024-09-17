<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1002px;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            height: 55px;
        }
        .auto-style4 {
            width: 1002px;
            height: 55px;
        }
        .auto-style5 {
            height: 55px;
            width: 265px;
        }
        .auto-style6 {
            width: 265px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style5" style="background-color: #FFFFCC"></td>
                    <td class="auto-style4" style="background-color: #FFFFCC">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mutualista&nbsp;</td>
                    <td class="auto-style3" style="background-color: #FFFFCC">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lgueo Empleado</td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">&nbsp;</td>
                    <td style="background-color: #FFFFCC">Usuario:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TxtNomUSu" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">&nbsp;</td>
                    <td style="background-color: #FFFFCC">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">&nbsp;</td>
                    <td style="background-color: #FFFFCC">Contraseña:&nbsp;&nbsp;
                        <asp:TextBox ID="TxtPassUsu" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Consulas no Realizadas</td>
                    <td style="background-color: #FFFFCC">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BtnLogueo" runat="server" OnClick="BtnLogueo_Click" Text="Iniciar Sesión" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LblErrorLogueo" runat="server" ForeColor="Red"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">&nbsp;</td>
                    <td style="background-color: #FFFFCC">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">
                        <asp:GridView ID="Gvconsulta" runat="server" Width="934px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style2" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanging="Gvconsulta_SelectedIndexChanging1" OnPageIndexChanging="Gvconsulta_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="FechaHoraConsulta" HeaderText="Fecha Hora" />
                                <asp:BoundField DataField="MedicoNombre" HeaderText="Medico" />
                                <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                                <asp:BoundField DataField="CanConsulta" HeaderText="Numero de Consulta" />
                                <asp:BoundField DataField="UnConsultorio.UnaPol.Direccion" HeaderText="Policlinica" />
                            </Columns>
                            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                            <RowStyle BackColor="White" ForeColor="#330099" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                            <SortedAscendingCellStyle BackColor="#FEFCEB" />
                            <SortedAscendingHeaderStyle BackColor="#AF0101" />
                            <SortedDescendingCellStyle BackColor="#F6F0C0" />
                            <SortedDescendingHeaderStyle BackColor="#7E0000" />
                        </asp:GridView>
                    </td>
                    <td style="background-color: #FFFFCC">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">&nbsp;</td>
                    <td style="background-color: #FFFFCC">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">
                        <asp:Label ID="LblErrorGV" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="background-color: #FFFFCC">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">&nbsp;</td>
                    <td style="background-color: #FFFFCC">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">&nbsp;</td>
                    <td style="background-color: #FFFFCC">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">&nbsp;</td>
                    <td style="background-color: #FFFFCC">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6" style="background-color: #FFFFCC">&nbsp;</td>
                    <td class="auto-style1" style="background-color: #FFFFCC">&nbsp;</td>
                    <td style="background-color: #FFFFCC">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="GTI.Especiales.Aprendizaje.Client.EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">

    function getValue()
    {

        var _gridheight= document.getElementById("CounterSection").clientHeight;
        alert(_gridheight);

    }
   
    </script>

    <style type="text/css">
        section{
            margin-top: 5em;
        }
        td, th{
          text-align: center;
        }
        .hiper-link img
        {
            width: 16px;
            height: 17px;
            margin-bottom: 10px;
        }
        table{
            letter-spacing: .5px;
            font-size: 16px;
            border: .5px solid #CCC;
            border-radius: 4px;
            border: none;

        }
        td {
                border: none;
            }
        table tbody tr td table tbody tr td{
              color: black;
              padding: 8px 12px;
              font-size: 16px;
              font-weight: bold;
        }
        table tbody tr td table tbody tr td a{
              color: #54b4eb;
              font-weight: normal;:
        }
        table tbody tr td table{
              border: none;
        }
        table tbody tr th{
            border-bottom: 2px solid #dee2e6;
        }
        table tbody tr th{
            border-top: none;
            border: none;
        }
        table tbody tr th a{
            color: black;
            font-weight: bold;
        }
        .btn-group{
              padding: 0 1em 0 0;
              margin: 0;
              width: 100%;
              font-family: inherit;
              font-size: 16px;
              cursor: inherit;
              line-height: inherit;
              height: 4.5rem;
              letter-spacing: 2px;
              border: .5px solid #CCC;
              border-radius: 4px;
        }
        .counters{
            width: 162px;
            padding: 1.5em;
            padding: 1em;
            letter-spacing: 3px;
            font-size: 12px;
            border: .5px solid #CCC;
            border-radius: 4px;
            position: absolute;
            z-index: -1;
            left: 114em;
            top: 56.5em;
        }
        .label-mostrar{
            font-size: 17px;
            letter-spacing: 1px;
        }
        .btn{
            padding: .8em 1em;
            font-size: 16px;
            letter-spacing: .8px;
        }
        .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            padding: 1.5em;
        }
    </style>
    <div>

        <section>
            <div>
                <hgroup>
                    <h2><%: Page.Title %></h2>
                </hgroup>
                    <asp:Label class="label-mostrar" runat="server">Mostrar</asp:Label>
                <div style="display:grid; grid-template-columns:1fr 1fr">
                    <asp:UpdatePanel runat="server">
                         <ContentTemplate>
                           <asp:DropDownList ID="DisplayActive"
                                AutoPostBack="True"
                                runat="server"
                                class="btn-group">
                                <asp:ListItem Text="Todos" Value="" />
                                <asp:ListItem Text="Activos" />
                                <asp:ListItem Text="Inactivos" />
                           </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true"/>
                    <div class="text-right">
                        <button type="button" style="background-color:#007bff" class="btn" >
                            <asp:HyperLink NavigateUrl="~/AddEmployee" style="color:#fff" Text="Crear Empleado" runat="server"/>
                        </button>
                    </div>
                </div>

                <br /><br />
                <%--<asp:TextBox ID="TxtSearch" runat="server" CssClass="txt"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="buttongr" /> --%>
                <asp:UpdatePanel ID="updPanel" runat="server">
                    <ContentTemplate>
                        <div>
                                <asp:GridView
                                    AllowSorting="true"
                                    emptydatatext="No hay información disponible." 
                                    allowpaging="true"
                                    PageSize="5"
                                    startRowIndex="1"
                                    maximumRows="10"
                                    runat="server" ID="employeeList"
                                    ItemType="GTI.Especiales.Aprendizaje.Client.Models.Employee" DataKeyNames="EmployeeID" 
                                    SelectMethod="GetEmployees" DeleteMethod="EmployeeGrid_DeleteItem"
                                    AutoGenerateColumns="false" class="table" Width="1323px">
                                    <Columns>
                                        <asp:DynamicField DataField="EmployeeID" AccessibleHeaderText="Empleado ID" ShowHeader="False" HeaderText="Id" />
                                        <asp:DynamicField ItemStyle-CssClass="text-align: left" DataField="EmployeeName" HeaderText="Nombre" />
                                        <asp:DynamicField DataField="RFC" />
                                        <asp:DynamicField DataField="Salary" HeaderText="Salario"/>    
                                        <asp:DynamicField DataField="Active" HeaderText="Activo" />
                                        <asp:TemplateField>
                                            <ItemTemplate>  
                                                <asp:HyperLink class="hiper-link" ImageUrl="~/Images/edit.png" ID="HyperLink2" runat="server" NavigateUrl='<%#String.Format("~/AddEmployee.aspx?id={0}", Eval("EmployeeID"))%>' ToolTip="Editar" />
                                                <asp:ImageButton runat="server" enabled='<%#Eval("Active")%>'  ImageUrl='<%#Convert.ToBoolean(Eval("Active"))?"~/Images/delete.png" : "~/Images/delete-transparent.png"%>' OnClientClick="return confirm('¿Estás seguro(a) que deseas eliminar el empleado?');" CommandName="Delete" ToolTip='<%#Convert.ToBoolean(Eval("Active"))?"Inactivar" : "Empleado inactivo"%>' Width="20px" Height="20px"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                               <div id="CounterSection" runat="server" class="counters" >
                                    <asp:Label runat="server">Total <%= this.TotalEmployees %></asp:Label>
                                    <br />
                                    <asp:Label runat="server">Activos <%= this.ActiveEmployees %></asp:Label>
                                    <br />
                                    <asp:Label runat="server">Inacivos <%= this.DisabledEmployees %></asp:Label>
                                </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>
    </div>
</asp:Content>
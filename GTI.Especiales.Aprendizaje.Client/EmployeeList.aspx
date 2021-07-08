<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="GTI.Especiales.Aprendizaje.Client.EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        td, th{
          text-align: center;
        }
        .hiper-link img
        {
            width: 16px;
            height: 17px;
            margin-bottom: 10px;
        }
    </style>

    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
                <asp:Label runat="server">Mostrar</asp:Label>
            <div style="display:grid; grid-template-columns:1fr 1fr">
               <asp:DropDownList ID="DysplayActive"
                    AutoPostBack="True"
                    runat="server"
                    class="btn-group">
                    <asp:ListItem Text="Todos" Value="" />
                    <asp:ListItem Text="Activos" />
                    <asp:ListItem Text="Inactivos" />
               </asp:DropDownList>
                <div     class="text-right">
                    <button type="button" style="background-color:#007bff" class="btn" >
                        <asp:HyperLink NavigateUrl="~/AddEmployee" style="color:#fff" Text="Crear Empleado" runat="server"/>
                    </button>
                </div>
            </div>

            <br /><br />
            <asp:UpdatePanel ID="updPanel" runat="server">
                <ContentTemplate>
                    <asp:GridView
                        AllowSorting="true"
                        emptydatatext="No data available." 
                        allowpaging="true"
                        startRowIndex="1"
                        maximumRows="10"
                        runat="server" ID="employeeList"
                        ItemType="GTI.Especiales.Aprendizaje.Client.Models.Employee" DataKeyNames="EmployeeID" 
                        SelectMethod="GetEmployees" DeleteMethod="EmployeeGrid_DeleteItem"
                        AutoGenerateColumns="false" class="table table-striped" Width="1323px">
                        <Columns>
                            <asp:DynamicField DataField="EmployeeID" AccessibleHeaderText="Empleado ID" ShowHeader="False" HeaderText="Id" />
                            <asp:DynamicField ItemStyle-CssClass="text-align: left" DataField="EmployeeName" HeaderText="Nombre" />
                            <asp:DynamicField DataField="RFC" />
                            <asp:DynamicField DataField="Salary" HeaderText="Salario"/>    
                            <asp:DynamicField DataField="Active" HeaderText="Activo" />
                            <asp:TemplateField>
                                <ItemTemplate>  
                                    <asp:HyperLink class="hiper-link" ImageUrl="~/Images/edit.png" ID="HyperLink2" runat="server" NavigateUrl='<%#String.Format("~/AddEmployee.aspx?id={0}", Eval("EmployeeID"))%>' ToolTip="Editar" />
                                    <asp:ImageButton runat="server" enabled='<%#Eval("Active")%>'  ImageUrl='<%#Convert.ToBoolean(Eval("Active"))?"~/Images/delete.png" : "~/Images/delete-transparent.png"%>' OnClientClick="return confirm('¿Estás seguro(a) que deseas eliminar el empleado?');" CommandName="Delete" ToolTip="Eliminar" Width="20px" Height="20px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
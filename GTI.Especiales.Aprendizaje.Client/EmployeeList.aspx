<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="GTI.Especiales.Aprendizaje.Client.EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        td, th{
          text-align: center;
        
        }
    </style>

    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
            <div style="display:grid; grid-template-columns:1fr 1fr">
               <asp:DropDownList ID="DysplayActive"
                    AutoPostBack="True"
                    runat="server"
                    class="btn-group">
                  <asp:ListItem Selected="True" Value="White"> Mostrar </asp:ListItem>
                  <asp:ListItem Value="Silver"> Activos </asp:ListItem>
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
                        runat="server" ID="employeeList"
                        ItemType="GTI.Especiales.Aprendizaje.Client.Models.Employee" DataKeyNames="EmployeeID" 
                        SelectMethod="GetEmployees"
                        AutoGenerateColumns="false" class="table" OnSelectedIndexChanged="employeeList_SelectedIndexChanged">
                        <Columns>
                            <asp:DynamicField DataField="EmployeeID" AccessibleHeaderText="Empleado ID" ShowHeader="False" HeaderText="Id" />
                            <asp:DynamicField ItemStyle-CssClass="text-align: left" DataField="EmployeeName" HeaderText="Nombre" />
                            <asp:DynamicField DataField="RFC" />
                            <asp:DynamicField DataField="Salary" HeaderText="Salario"/>    
                            <asp:DynamicField DataField="Active" HeaderText="Activo" />
                            <asp:HyperLinkField Text="Editar" DataNavigateUrlFormatString="~/AddEmployee.aspx?id={0}"
                                DataNavigateUrlFields="EmployeeID" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton CommandArgument='<%#Eval("EmployeeID")%>' ImageUrl="~/Images/edit.png" runat="server" ToolTip="Edit" Width="20px" Height="20px"/>
                                    <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
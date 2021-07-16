<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="GTI.Especiales.Aprendizaje.Client.EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Styles/EmployeeList.css" type="text/css" rel="stylesheet" />
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
                                    AutoGenerateColumns="false" class="table" Width="1323px" ShowFooter="True">
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
                                            <footertemplate>
                                                <div class="counters">
                                                    <asp:Label runat="server">Total <%= this.TotalEmployees %></asp:Label>
                                                    <br />
                                                    <asp:Label runat="server">Activos <%= this.ActiveEmployees %></asp:Label>
                                                    <br />
                                                    <asp:Label runat="server">Inacivos <%= this.DisabledEmployees %></asp:Label>
                                                </div>
                                            </footertemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>
    </div>
</asp:Content>
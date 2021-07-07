<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="GTI.Especiales.Aprendizaje.Client.AddEmployee" %>
 <%-- 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <asp:FormView runat="server" ID="AddEmployeeForm" AllowPaging="True"
        ItemType="GTI.Especiales.Aprendizaje.Client.Models.EmployeeCommand"
        InsertMethod="AddEmployeeForm_InsertItem" DefaultMode="Insert" OnItemInserted="AddEmployeeForm_ItemInserted">
        <InsertItemTemplate>
            <fieldset>
                <ol>
                    <asp:DynamicEntity runat="server" Mode="Insert" />
                </ol>
                <div class="text-center">
                    <asp:Button runat="server" Text="Agregar" CommandName="Insert" Style="background-color: #007bff; color: #fff" class="btn" />
                    <asp:Button runat="server" Text="Cancelar" CausesValidation="false" OnClientClick=" return confirm_meth()" OnClick="CancelButton_Click" Style="background-color: #6c757d; color: #fff" class="btn" />
                </div>
            </fieldset>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
--%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <hr />
    <div class="row">
        <div class="col-md-8">
            <section>
                <div class="form-horizontal">

                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Nombre</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">RFC</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="RFC" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Salario</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Salary" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="Active" />
                                <asp:Label runat="server">Activo</asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="BtnAddUpdate" runat="server" OnClick="AddUpdateEmployeeForm_InsertItem" Text="Crear" Style="background-color: #0069d9; color: #fff" CssClass="btn" />
                            <asp:Button  ID="BtnDeleteCancel" runat="server" Text="Cancelar" OnClick="CancelButton_Click" Style="background-color: #6c757d; color: #fff" class="btn" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
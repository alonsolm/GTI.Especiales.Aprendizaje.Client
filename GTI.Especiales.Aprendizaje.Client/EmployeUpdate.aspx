<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeUpdate.aspx.cs" Inherits="GTI.Especiales.Aprendizaje.Client.EmployeUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <asp:FormView runat="server" ID="UpdateEmployeForm"
        InsertMethod="UpdateEmployeForm_InsertItem" DefaultMode="Insert"
        RenderOuterTable="false" OnItemInserted="UpdateEmployeForm_ItemInserted"
        >
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    </asp:FormView>

</asp:Content>

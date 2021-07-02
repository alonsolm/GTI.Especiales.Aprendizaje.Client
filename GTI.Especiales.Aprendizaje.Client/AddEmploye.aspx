<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmploye.aspx.cs" Inherits="GTI.Especiales.Aprendizaje.Client.AddEmploye" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
    <asp:FormView runat="server" ID="AddEmployeForm"
        ItemType="GTI.Especiales.Aprendizaje.Client.Models.Employe" 
        InsertMethod="AddEmployeForm_InsertItem" DefaultMode="Insert"
        RenderOuterTable="false" OnItemInserted="AddEmployeForm_ItemInserted"
        >
        <InsertItemTemplate>
            <fieldset>
                <ol>
                    <asp:DynamicEntity runat="server" Mode="Insert" />
                </ol>
                <asp:Button runat="server" Text="Insert" CommandName="Insert" />
                <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="CancelButton_Click" />
            </fieldset>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>

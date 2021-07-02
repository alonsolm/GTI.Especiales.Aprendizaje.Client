<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="GTI.Especiales.Aprendizaje.Client.ForeignKeyField" %>

<asp:HyperLink ID="HyperLink1" runat="server"
    Text="<%# GetDisplayString() %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />


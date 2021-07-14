﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="GTI.Especiales.Aprendizaje.Client.AddEmployee" %>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <script>
    $(document).ready(function(){
      $('[data-toggle="tooltip"]').tooltip();   
    });
    </script>
    <style type="text/css">
        .checkbox{
            bottom: 9px
        }
        .checkboxActive{
            margin-left: 26px;
        }
        .btn-create{
            background-color: #007bff;
            padding: .85em 2.5527em;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            letter-spacing: .8px;
        }
        .btn-create:hover{
            text-decoration: underline ;
        }
        .btn-cancel:hover{
            text-decoration: underline ;
        }
        .btn-cancel{
            background-color: #6c757d;
            padding: .85em 1.802em;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            letter-spacing: .8px;
        }
        span{
           font-size: 17px;
           letter-spacing: 1px;
        }
        .body-content{
            padding-top: 4em;
        }
        .container-buttons{
            margin-top: 1em;
        }
        .container-buttons input{
            color: white;
        }
        .form-control{
            height: 46px;
        }
    </style>
    <div class="row">
        <div class="col-md-8">
            <section>
                <div class="form-horizontal">

                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Nombre</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name" CssClass="text-danger" ErrorMessage="El Nombre es requerido." />
                            <asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator1" runat="server"  CssClass="text-danger" ControlToValidate="Name" ValidationExpression="^[A-Za-z_\s][A-Za-z0-9_\s]{0,253}$" ErrorMessage="El nombre solo permite un máximo de 255 letras." />

                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">RFC</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="RFC" CssClass="form-control" />
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RFCRequiredFieldValidator" runat="server" ControlToValidate="RFC" CssClass="text-danger" ErrorMessage="El RFC es requerido." />
                            <asp:RegularExpressionValidator Display="Dynamic"  ID="RFCRegularExpressionValidator" runat="server"  CssClass="text-danger" ControlToValidate="RFC" ValidationExpression="^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])([A-Z]|[0-9]){2}([A]|[0-9]){1})?$" ErrorMessage="El RFC es inválido.">
                            <p style="display: inherit" class="text-danger" >El RFC es inválido. </p>
                            <a href="https://www.eleconomista.com.mx/finanzaspersonales/que-es-el-rfc-20191203-0084.html" data-toggle="tooltip" title="Click aqui para más información!" target="_blank">
                                <svg style="margin-top: 1rem" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" width="25" height="14"><path d="M512,256c0,141.38-114.61,256-256,256S0,397.39,0,256,114.62,0,256,0,512,114.62,512,256Z" fill="#404041"/><path d="M28,139.52,139.52,28A257.1,257.1,0,0,0,28,139.52Z" fill="#4d4d4f"/><path d="M179.06,11.77,11.77,179.06a254.14,254.14,0,0,0-6.43,24.69L203.75,5.34A253.94,253.94,0,0,0,179.06,11.77Z" fill="#4d4d4f"/><path d="M231.24,1.2l-230,230Q.27,240.84.07,250.64L250.63.07Q240.84.27,231.24,1.2Z" fill="#4d4d4f"/><path d="M273.44.6.6,273.43q.56,8.39,1.66,16.63L290.05,2.26Q281.83,1.17,273.44.6Z" fill="#4d4d4f"/><path d="M309.94,5.71,5.71,309.95q1.59,7.41,3.6,14.66L324.6,9.31Q317.35,7.3,309.94,5.71Z" fill="#4d4d4f"/><path d="M342.32,14.93,14.94,342.33Q17.32,349,20,355.47L355.46,20Q349,17.31,342.32,14.93Z" fill="#4d4d4f"/><path d="M371.41,27.44l-344,344q3,6,6.39,11.86L383.28,33.83Q377.44,30.48,371.41,27.44Z" fill="#4d4d4f"/><path d="M397.69,42.77,42.77,397.69q3.63,5.46,7.53,10.72L408.42,50.31Q403.16,46.4,397.69,42.77Z" fill="#4d4d4f"/><path d="M421.43,60.64,60.65,421.43q4.18,4.93,8.6,9.65L431.08,69.25Q426.36,64.82,421.43,60.64Z" fill="#4d4d4f"/><path d="M442.75,80.91,80.92,442.75q4.72,4.42,9.65,8.6L451.37,90.58Q447.18,85.64,442.75,80.91Z" fill="#4d4d4f"/><path d="M461.69,103.58,103.58,461.69q5.26,3.91,10.73,7.54L469.23,114.31Q465.59,108.85,461.69,103.58Z" fill="#4d4d4f"/><path d="M478.17,128.72,128.71,478.16q5.84,3.35,11.88,6.4l344-344Q481.51,134.56,478.17,128.72Z" fill="#4d4d4f"/><path d="M492,156.53,156.53,492q6.48,2.73,13.14,5.11L497.06,169.67Q494.68,163,492,156.53Z" fill="#4d4d4f"/><path d="M502.69,187.41,187.4,502.69q7.24,2,14.66,3.6L506.29,202.06Q504.7,194.65,502.69,187.41Z" fill="#4d4d4f"/><path d="M509.74,222,221.94,509.74q8.23,1.09,16.62,1.66L511.4,238.56Q510.83,230.18,509.74,222Z" fill="#4d4d4f"/><path d="M510.81,280.75q.92-9.59,1.13-19.38L261.37,511.93q9.79-.2,19.39-1.13Z" fill="#4d4d4f"/><path d="M332.92,500.23,500.23,332.92a254,254,0,0,0,6.42-24.68L308.23,506.66A254.22,254.22,0,0,0,332.92,500.23Z" fill="#4d4d4f"/><path d="M484,372.49,372.48,484A257.12,257.12,0,0,0,484,372.49Z" fill="#4d4d4f"/><path d="M332.09,192.77a48.62,48.62,0,0,1-5.46,23.32,73,73,0,0,1-12.54,16.84c-7.9,7.71-16.4,15.12-24.62,22.47a90.32,90.32,0,0,0-7.51,7.45,27.44,27.44,0,0,0-3.78,5.26l0,.08a26,26,0,0,0-1.9,4.77c-.89,3.07-1.58,6.34-2.27,9.47-2.13,11.56-9.33,18.27-21.3,18.27a21.88,21.88,0,0,1-15.52-6c-4.85-4.64-6.42-11-6.42-17.54,0-7.62,1.07-15.4,4.08-22.46A57.22,57.22,0,0,1,245.52,238a114.34,114.34,0,0,1,9.7-8.84c3.92-3.29,7.83-6.53,11.67-9.94,5.85-5.2,18.51-16.74,17.19-25.5-1.22-8.16-5-15.34-12.67-19.07-8.17-4-18.22-2.83-26.23,1A35.27,35.27,0,0,0,226,198.31c-3,11.33-10.43,19.33-22.68,19.33a22.46,22.46,0,0,1-16.64-7c-4.07-4.21-6.74-9.26-6.74-15.21,0-10.74,3.76-20.78,9.42-29.8,6.66-10.59,16.18-18.61,27.12-24.57,12.73-6.94,26.84-9.67,41.28-9.67,13.33,0,26.55,2.27,38.6,8.1,10.73,5.1,19.79,12.37,26.38,22.3A55.26,55.26,0,0,1,332.09,192.77Zm-79.8,124.65a32.33,32.33,0,0,0-23.16,9.42q-9.84,9.41-9.83,22.32t9.83,22.16a33.41,33.41,0,0,0,46.16,0q9.84-9.27,9.83-22.16t-9.83-22.32A32.12,32.12,0,0,0,252.29,317.43Z" fill="#fff"/></svg>
                            </a>
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Salario</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Salary" CssClass="form-control" />
                            <asp:RequiredFieldValidator Display="Dynamic" runat="server" Type="Integer" ControlToValidate="Salary" CssClass="text-danger" ErrorMessage="El Salario es requerido." />
                            <asp:RangeValidator Display="Dynamic" id="RangeValidator2" CssClass="text-danger" ControlToValidate="Salary" MinimumValue="1" MaximumValue="100000000000000000" Type="Double" Text="El Salario tiene que ser mayor a 0." runat="server"/>
                        </div>
                    </div>

                    <div id="ActiveSection" runat="server" class="form-group checkbox">
                        <div class="col-md-offset-2 col-md-10">
                            <div>
                                <asp:Label  Display="Dynamic" ID="lblActive" runat="server">Activo</asp:Label>
                                <asp:CheckBox  Display="Dynamic" class="checkboxActive" runat="server" ID="Active" />
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10 container-buttons">
                            <asp:Button ID="BtnAddUpdate" runat="server" OnClick="AddUpdateEmployeeForm_InsertItem" Text="Crear" class="btn-create" />
                            <asp:Button CausesValidation="false" ID="BtnDeleteCancel" runat="server" Text="Cancelar" OnClick="CancelButton_Click" class="btn-cancel" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
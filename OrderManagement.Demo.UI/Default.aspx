<%@ Page Title="Home Page" Async="true"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OrderManagement.Demo.UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>User Login</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                <div>
                    <table>
                        <tr>
                            <td style="width:10%">
                                Username:
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvUser" ForeColor="Red" ErrorMessage="Please enter Username" ControlToValidate="txtUserName" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Password:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPWD" runat="server" TextMode="Password" />
                                
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvPWD" runat="server" ForeColor="Red" ControlToValidate="txtPWD" ErrorMessage="Please enter Password" />
                            </td>
                        </tr>
                        
                    </table>
                </div>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server"  Text="Submit" OnClick="btnSubmit_Click" />
            </p>
        </div>
        

    <p>Error Messaage: <asp:Label runat="server" ID="lblError" ForeColor="Red" /></p>


    </div>
</asp:Content>

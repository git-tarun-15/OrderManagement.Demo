<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreditCard.aspx.cs" Inherits="OrderManagement.Payment.Service._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Credit Card Authorization </h1>
    </div>

    <div class="row">
      
            <div class="col-md-4">
                <h2>Getting started</h2>
                <p>
                    <div>

                        <table>
                            <tr>
                                <td >Card Number:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCard" runat="server" />                                      
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rvCard" ForeColor="Red" ErrorMessage="*" ControlToValidate="txtCard" runat="server"  />
                                <asp:RegularExpressionValidator id="revCard" ControlToValidate="txtCard" ForeColor="Red" ValidationExpression="^[1-9][0-9]{3}(-[0-9]{4}){3}$" Display="Static"
                                ErrorMessage="Invalid format" EnableClientScript="True" runat="server"/>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>Expiry Date:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMonth" runat="server" > 
                                        <asp:ListItem Value="0">-- Select Month --</asp:ListItem>
                                        <asp:ListItem Value="1">Jan</asp:ListItem>
                                        <asp:ListItem Value="2">Feb</asp:ListItem>
                                        <asp:ListItem Value="3">Mar</asp:ListItem>
                                        <asp:ListItem Value="4">Apr</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">June</asp:ListItem>
                                        <asp:ListItem Value="7">July</asp:ListItem>
                                        <asp:ListItem Value="8">Aug</asp:ListItem>
                                        <asp:ListItem Value="9">Sep</asp:ListItem>
                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                        <asp:ListItem Value="9">Nov</asp:ListItem>
                                        <asp:ListItem Value="10">Dec</asp:ListItem>
                                     </asp:DropDownList>
                                    </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rvMonth" ForeColor="Red" ErrorMessage="*" ControlToValidate="ddlMonth" runat="server" InitialValue="0" EnableClientScript="True" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlYear" runat="server" >  
                                        <asp:ListItem Value="0">-- Select Year --</asp:ListItem>
                                        <asp:ListItem Value="2021">2021</asp:ListItem>
                                        <asp:ListItem Value="2022">2022</asp:ListItem>
                                        <asp:ListItem Value="2023">2023</asp:ListItem>
                                        <asp:ListItem Value="2024">2024</asp:ListItem>
                                        <asp:ListItem Value="2025">2025</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rvYear" ForeColor="Red" ErrorMessage="*" ControlToValidate="ddlYear" runat="server" InitialValue="0" EnableClientScript="True" />
                                </td>
                            </tr>
                            <tr>
                                <td>CVV:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCVV" MaxLength="3" runat="server" />
                                    
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvCVV" ForeColor="Red" ErrorMessage="*" ControlToValidate="txtCVV" runat="server" />
                                    <asp:RegularExpressionValidator id="revCVV" ControlToValidate="txtCVV" ForeColor="Red" ValidationExpression="^[0-9]{3,4}$" Display="Static"
                                ErrorMessage="Invalid format" EnableClientScript="True" runat="server"/>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>

                        </table>
                    </div>
                </p>
                <p>
                    <asp:Button ID="btnPayment" runat="server" Text="Authorize Payment" OnClick="btnPayment_Click" />
                </p>
            </div>
            
        
    </div>

</asp:Content>

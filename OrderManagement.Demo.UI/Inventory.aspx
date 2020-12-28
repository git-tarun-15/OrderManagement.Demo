<%@ Page Title="Inventory" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="OrderManagement.Demo.UI.Inventory" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
       
        function openModal(url) {
            $("#divForAspxPage").dialog(
                {
                    bgiframe: true,
                    autoOpen: false,
                    resizable: false,
                    width: 1000,
                    height: 700,
                    modal: true,
                });

            $("#divForAspxPage").load(url);
            $("#divForAspxPage").dialog("open");
        }

        function closeModal(message) {

            if (message == "Dummy_Token") {
                $('#<%=lblMessage.ClientID%>').html("Card Authorized, go ahead for Payment.!");
                $('#<%=btnAuthPayment.ClientID%>').attr('value', 'Payment');
                $('#<%=hdnToken.ClientID%>').val(message);
            }
            $(".ui-dialog-titlebar-close").trigger('click');
        }
    </script>
     
    <div id="divForAspxPage"></div>       
    <div class="jumbotron">
        <h1>Inventory </h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Select Items: </h2>
            <p>
                <div>
                    <input type="hidden" id="hdnToken" runat="server" />
                    <table style="width:50%;height:30%">
                        <tr>
                            <td style="width:20%">
                                Inventory Items:
                            </td>
                            <td style="width:30%">
                                <asp:DropDownList ID="ddlInventory" runat="server" width="200px"/>
                            </td>
                            <td style="width:10%">
                                <asp:RequiredFieldValidator ID="rvInventory" ForeColor="Red" ErrorMessage="* Required" ControlToValidate="ddlInventory"  runat="server"   InitialValue="0" EnableClientScript="True"/>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                Quantity:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlQuantity" runat="server" width="200px">  
                                    <asp:ListItem Value="0">0</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="6">6</asp:ListItem>
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="8">8</asp:ListItem>
                                    <asp:ListItem Value="9">9</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rvQuantity" runat="server" ForeColor="Red" ControlToValidate="ddlQuantity" ErrorMessage="* Required"  InitialValue="0" EnableClientScript="True" />
                            </td>
                        </tr>
                        
                    </table>
                </div>
            </p>
            <p>
                <asp:Button ID="btnValidate" runat="server" Text="Check Inventory" OnClick="btnValidate_Click" />
            </p>
        </div>
        <div class="col-md-4">  
            <p><asp:Label runat="server" Font-Bold="true" ForeColor="ForestGreen" ID="lblMessage"  /></p> 
        </div>
        <div class="col-md-4" id="divPayment" runat="server">
            <h2>Start Payment</h2>  
            <p>
                <asp:Button ID="btnAuthPayment" runat="server" Text="Authorize Payment" OnClick="btnPayment_Click" />
            </p>
        </div>
        
    </div>
</asp:Content>

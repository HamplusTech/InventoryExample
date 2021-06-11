<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="main-wrapper">
    <div><h2>Sales Order</h2> &nbsp &nbsp <h4>Create Order</h4></div>
    <div><table>
                <tr>
        <td class="auto-style1"> Product Code</td>
        <td class="auto-style1"> Name Description</td>
        <td class="auto-style1"> Unity Price</td>
        <td class="auto-style1"> Quanty</td>
        <td class="auto-style1"> Quantity Price</td>
        <td class="auto-style1"> Discount</td>
        <td class="auto-style1"> Amount</td>
                </tr>
                <tr>
                  <td class="col-sm-1">
                      <asp:TextBox ID="txtCode" AutoPostBack="true" OnTextChanged="txtCode_TextChanged" runat="server" Width="100px"></asp:TextBox>
                      <br />
                      <br />
                   </td>
                     <td class="col-sm-2">
                      
                         <asp:TextBox ID="txtpname" runat="server" Width="100px"></asp:TextBox>
                         <br />
                         <br />
                   </td>
                   <td class="col-sm-1">
                      <asp:TextBox ID="txtunitprice" runat="server" Width="100px"></asp:TextBox>
                  &nbsp;</td>
                  <td class="col-sm-1">
                      <asp:TextBox ID="txtqty" runat="server" Width="100px"></asp:TextBox>
                  &nbsp;</td>
                   <td class="col-sm-1">
                      <asp:TextBox ID="txtprice" runat="server" Width="100px"></asp:TextBox>
                  &nbsp;</td>
                   <td class="col-sm-1">
                      <asp:TextBox ID="txtdiscount" runat="server" Width="100px"></asp:TextBox>
                  &nbsp;</td>
                     <td class="col-sm-1">
                      <asp:TextBox ID="txttotal" runat="server" Width="100px"></asp:TextBox>
                  &nbsp;</td>
                    
                    <td> 
                        <div class="col-xs-4">
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Item" />
                        </div>
                 
                   </td>
                </tr>
         </table></div>
        <div id="grid-view">

            <asp:GridView ID="xSale" runat="server" CssClass="table table-hover table-striped"  AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="ProductCode" DataField="ProductCode"  />
                    <asp:BoundField HeaderText="NameDescription" DataField="NameDescription" />
                    <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" />
                    <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                    <asp:BoundField HeaderText="Price" DataField="Price" />
                    <asp:BoundField HeaderText="Discount" DataField="Discount" />
                    <asp:BoundField HeaderText="Total" DataField="Total"/>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" Text="Post Order" Width="320px" />

        </div>
        </div>
    </div>
    </form>
</body>
</html>

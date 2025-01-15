<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMainMaster.Master" AutoEventWireup="true" CodeBehind="Gender.aspx.cs" Inherits="SMS.Gender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="frm1" runat="server">
        <ul>
            <li>
                <asp:Label ID="lblHeading" runat="server" Text="Gender"
                    ForeColor="Black"></asp:Label>
            </li>
            <li>
                <asp:Label ID="lblMessage" runat="server" Text="" Font-Bold="true" Font-Names="verdana"
                    Font-Size="10pt" ForeColor="#FF0000"></asp:Label>
            </li>
            <li>
                <div id="divView" runat="server" style="width: 100%; overflow: auto;">
                    <asp:DataGrid ID="dgCase" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        BackColor="#FFFFFF" BorderStyle="Solid" BorderColor="#365A72" BorderWidth="1pt"
                        CellPadding="5" CellSpacing="1" GridLines="Both" PageSize="20" Width="100%" OnItemCommand="dgCase_ItemCommand"
                        OnPageIndexChanged="dgCase_PageIndexChanged">
                        <HeaderStyle CssClass="GridHeaderAdmin" />
                        <ItemStyle CssClass="GridItemAdmin" />
                        <AlternatingItemStyle CssClass="GridAlternameItemAdmin" />
                        <PagerStyle CssClass="GridPagerAdmin" Mode="NumericPages" Position="Bottom" HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateColumn HeaderText="Gender ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridGenderID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Gender">
                                <HeaderStyle HorizontalAlign="Center" Width="100px" Wrap="false" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblGridGenderName" runat="server" CausesValidation="false" Width="100px"
                                        CommandName="cmd_edit" Text='<%# Bind("Name") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="IsActive" Visible="True">
                                <HeaderStyle HorizontalAlign="Center" Width="200px" Wrap="false" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="top" Width="200px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGridIsActive" runat="server" Width="200px" Text='<%# Bind("isActive") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>
                </div>
                <asp:Panel ID="pnlDataDetail" runat="server">
                    <div id="divAddEdit" runat="server" style="width: 100%; text-align: left;">
                        <table style="width: 100%; text-align: left;">
                            <tr>
                                <th>
                                    <asp:Label ID="lblName" runat="server" Text="Gender :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtname" runat="server" data-mini="true" data-inline="true" TextMode="SingleLine"></asp:TextBox>
                                </th>
                                <th>
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" CssClass="Error" ToolTip="Blank Field Not Acceptable"
                                        ErrorMessage="*" ControlToValidate="txtname" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblActive" runat="server" Text="IsActive :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:RadioButtonList ID="rblActive" runat="server" data-mini="true" data-inline="true"
                                        CellPadding="1" CellSpacing="1" RepeatColumns="2" RepeatDirection="Horizontal"
                                        RepeatLayout="Table">
                                        <asp:ListItem Selected="True" Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </th>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </li>
            <li>
                <div>
                    <asp:Button ID="btnAddGender" runat="server" Text="Add Gender" Visible="true"
                        CausesValidation="true" OnClick="btnAddGender_Click" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" Visible="false" CausesValidation="true"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="false" CausesValidation="true"
                        OnClick="btnEdit_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" CausesValidation="true"
                        OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnBack" runat="server" Text="Back" Visible="false" CausesValidation="false"
                        OnClick="btnBack_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" CausesValidation="false"
                        OnClick="btnCancel_Click" />
                </div>
            </li>
        </ul>
    </form>
</asp:Content>

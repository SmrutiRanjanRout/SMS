<%@ Page Title="" Language="C#" MasterPageFile="~/SMSMainMaster.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="SMS.Students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="frm1" runat="server">
        <ul>
            <li>
                <asp:Label ID="lblHeading" runat="server" Text="Students"
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
                            <asp:TemplateColumn HeaderText="Students ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblGridStudentsID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                             <asp:TemplateColumn HeaderText="Class">
                                <HeaderStyle HorizontalAlign="Center" Width="100px" Wrap="false" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGridClass" runat="server" Text='<%# Bind("Class") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Student Name">
                                <HeaderStyle HorizontalAlign="Center" Width="200px" Wrap="false" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="200px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblGridSubjectName" runat="server" CausesValidation="false" Width="100px"
                                        CommandName="cmd_edit" Text='<%# Bind("Name") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="City">
                                <HeaderStyle HorizontalAlign="Center" Width="150px" Wrap="false" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="150px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGridCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Pincode">
                                <HeaderStyle HorizontalAlign="Center" Width="100px" Wrap="false" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGridPincode" runat="server" Text='<%# Bind("Pincode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Mobile Number">
                                <HeaderStyle HorizontalAlign="Center" Width="150px" Wrap="false" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="150px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGridMobileNumber" runat="server" Text='<%# Bind("MobileNumber") %>'></asp:Label>
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
                                    <asp:Label ID="lblFirstName" runat="server" Text="First Name :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtfirstname" runat="server" data-mini="true" data-inline="true" TextMode="SingleLine"></asp:TextBox>
                                </th>
                                <th>
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" CssClass="Error" ToolTip="Blank Field Not Acceptable"
                                        ErrorMessage="*" ControlToValidate="txtfirstname" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </th>
                            </tr>
                            <tr>
                                 <th>
                                     <asp:Label ID="lblSurname" runat="server" Text="Surname :" CssClass="CommonCaption"></asp:Label>
                                 </th>
                                 <th>
                                     <asp:TextBox ID="txtSurname" runat="server" data-mini="true" data-inline="true" TextMode="SingleLine"></asp:TextBox>
                                 </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblTitle" runat="server" Text="Title :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:DropDownList ID="ddlTitle" runat="server" AutoPostBack="true" 
                                        data-role="none" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                </th> 
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblFathersName" runat="server" Text="Father's Name :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtFathersName" runat="server" data-mini="true" data-inline="true" TextMode="SingleLine"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblMothersName" runat="server" Text="Mother's Name :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtMothersName" runat="server" data-mini="true" data-inline="true" TextMode="SingleLine"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblClass" runat="server" Text="Class :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" 
                                        data-role="none" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblSection" runat="server" Text="Section :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="true" 
                                        data-role="none" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblAddress" runat="server" Text="Address :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtAddress" runat="server" data-mini="true" data-inline="true" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblCity" runat="server" Text="City :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtCity" runat="server" data-mini="true" data-inline="true" TextMode="SingleLine"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblState" runat="server" Text="State :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtState" runat="server" data-mini="true" data-inline="true" TextMode="SingleLine"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblPincode" runat="server" Text="Pincode :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtPincode" runat="server" data-mini="true" data-inline="true" TextMode="SingleLine"></asp:TextBox>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblGender" runat="server" Text="Gender :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Non Binary" Value="3"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblMobileNumber" runat="server" Text="Mobile Number :" CssClass="CommonCaption"></asp:Label>
                                </th>
                                <th>
                                    <asp:TextBox ID="txtMobileNumber" runat="server" data-mini="true" data-inline="true" TextMode="SingleLine"></asp:TextBox>
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
                    <asp:Button ID="btnAddStudents" runat="server" Text="Add Students" Visible="true"
                        CausesValidation="true" OnClick="btnAddStudents_Click" />
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


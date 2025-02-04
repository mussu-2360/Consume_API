<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registor.aspx.cs" Inherits="CRUD_API_Source.Registor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration form</title>
</head>
<body>
        <style>
        body {
            font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
            color: #333;
        }

        form {
            max-width: 500px;
            margin: 50px auto;
            padding: 30px;
            background: #fff;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            color: #444;
            margin-bottom: 20px;
        }

        div {
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin-bottom: 8px;
            font-weight: 600;
        }

        input[type="text"], input[type="email"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            font-size: 14px;
        }

        input[type="text"]:focus, input[type="email"]:focus {
            border-color: #0056b3;
            outline: none;
        }

        button, input[type="submit"] {
            width: 100%;
            padding: 12px;
            background-color: #0056b3;
            color: #fff;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            font-weight: bold;
            cursor: pointer;
        }

        button:hover, input[type="submit"]:hover {
            background-color: #003f7f;
        }

        .gridview {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
            font-size: 14px;
            text-align: left;
        }

        .gridview th, .gridview td {
            padding: 12px;
            border: 1px solid #ddd;
        }

        .gridview th {
            background-color: #0056b3;
            color: white;
            text-transform: uppercase;
        }

        .gridview tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .gridview tr:hover {
            background-color: #e6f2ff;
        }
    </style>
    <form runat="server">
     <div>
            <h2>Registration Form</h2>
            <div>
                <label>First Name :</label>
                <asp:Textbox runat="server" ID="txtfname"></asp:Textbox>
            </div>

            <div>
                <label>Last Name :</label>
                <asp:TextBox runat="server" ID="txtlname"></asp:TextBox>
            </div>

            <div>
                <label>Date of Birth :</label>
                <asp:TextBox runat="server" ID="txtdob"></asp:TextBox>
            </div>

            <div>
                <label>Email :</label>
                <asp:TextBox runat="server" ID="txtemail"></asp:TextBox>
            </div>

            <div>
                <label>Phone Number :</label>
                <asp:TextBox runat="server" ID="txtno"></asp:TextBox>
            </div>

            <div>
                <label>Address :</label>
                <asp:TextBox runat="server" ID="txtadd"></asp:TextBox>
            </div>

            <div>
                <asp:Button runat="server" Text="Submit" ID="sbmbtn" OnClick="sbmbtn_Click" />
                <asp:Label ID="lblmsg" Text="" runat="server" />
            </div>

            
            
            <div>
                <asp:GridView runat="server" ID="grd" CssClass="gridview" AutoGenerateColumns="false">
                    <Columns>                  

                        <asp:TemplateField HeaderText="StudentID" Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblStudentId" Text='<%# Eval("StudentId") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstName" Text='<%# Eval("FirstName") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="LastName">
                            <ItemTemplate>
                                <asp:Label ID="lblLastName" Text='<%# Eval("LastName") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="DateOfBirth">
                            <ItemTemplate>
                                <asp:Label ID="lblDateOfBirth" Text='<%# Eval("DateOfBirth") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" Text='<%# Eval("Email") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PhoneNumber">
                            <ItemTemplate>
                                <asp:Label ID="lblPhoneNumber" Text='<%# Eval("PhoneNumber") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" Text='<%# Eval("Address") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button id="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click1" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
                    </div>
        </form>
</body>
</html>

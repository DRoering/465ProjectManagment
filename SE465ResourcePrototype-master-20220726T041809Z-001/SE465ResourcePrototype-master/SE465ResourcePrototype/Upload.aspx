<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="SE465ResourcePrototype.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="FileLabel" runat="server" Text="Click 'Choose File' to select the file, then 'Submit File' to upload."></asp:Label><br /><br />
            <asp:FileUpload ID="FileUpload1" runat="server" /><br /><br />
            <asp:Button ID="FileSubmit" runat="server" Text="Submit File" CssClass="auto-style1" OnClick="FileSubmit_Click" style="height: 26px" UseSubmitBehavior="False" /><br />
            
        </div>
    </form>
</body>
</html>

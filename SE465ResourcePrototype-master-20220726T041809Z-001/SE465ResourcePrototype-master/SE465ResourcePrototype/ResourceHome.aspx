<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResourceHome.aspx.cs" Inherits="SE465ResourcePrototype.ResourceHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="resourceCSS.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="Scripts/popoutBox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="hover_bkgr_fricc">
                <span class="helper"></span>
                <div>
                    <div class="popupCloseButton">X</div>
                    <object type="text/html" data="Upload.aspx" class="upload_page"></object>
                </div>
            </div>
            <div align="right">
                Welcome, Admin<br />
                <a href="resManageHistory">Usage History</a>
            </div>
            <h3>Resource Management</h3>
            <br />
            <table style="width: 80%">
                <tr>
                    <td>
                        <input type="text" name="searchtext">
                        <input type="submit" value="Search">
                        <button type='button' class="trigger_popup_fricc">Upload New Resource</button>
                        <button>Add Selected to User/Project</button>
                    </td>
                </tr>
            </table>

            <div id="testTable" runat="server"></div>

            <table style="width: 80%">
                <tr>
                    <td>
                        <asp:Button ID="FileDelete" runat="server" Text="Delete Selected" OnClientClick="confirm('Are you sure you wish to permanently delete these files?');" OnClick="FileDelete_Click" UseSubmitBehavior="True" />
                    </td>
                </tr>
                <tr>
                    <td colspan="100%" align="center">
                        <a href=""><</a> Displaying Results 1 to 2 (of 2) <a href="">></a>
                    </td>
                </tr>
            </table>
        </div>
    </form>

    <script src="Scripts/popoutBox.js"></script>
</body>
</html>

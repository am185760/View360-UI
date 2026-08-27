<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="CCMSUI.Data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
       

        function openWindowWithPost(url, data) {
            var form = document.createElement("form");
            form.target = "_blank";
            form.method = "POST";
            form.action = url;
            form.style.display = "none";

            for (var key in data) {
                var input = document.createElement("input");
                input.type = "hidden";
                input.name = key;
                input.value = data[key];
                form.appendChild(input);
            }
            document.body.appendChild(form);
            form.submit();
            document.body.removeChild(form);
        }

        function doProc() {
            openWindowWithPost("reportPopup.aspx", {
                param1: "value1",
                param2: "value2",
                //:
            });
//            window.open('reportPopup.aspx');

        }
        function load() {
            window.setTimeout(doProc, 2000);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="Literal_Script" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>

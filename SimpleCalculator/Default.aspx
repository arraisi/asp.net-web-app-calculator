<%@ Page Language="C#" Inherits="SimpleCalculator.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Calculator</title>
    <link href="Style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <header>
      <h2>ABDUL RAHMAN ARRAISI | XTREMAX</h2>
    </header>
    <section>
          <nav>
            <ul>
             <img width="100%" src="../../Assets/Images/Screen Shot 2019-09-17 at 20.31.48.png"/>
            </ul>
          </nav>
          <content>
            <form id="form1" runat="server">
            <div class="calculator-holder">
                <table class="calculator" id="calc">
                    <tr>
                        <td colspan="4" class="calc_td_result">
                            <input type="text" readonly="readonly" runat="server" name="calc_result" id="calculationText" class="calc_result"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="calc_td_btn">
                            <asp:Button id="Button7" runat="server" class="calc_btn" Text="7" OnClick="Button7_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="Button8" runat="server" class="calc_btn" Text="8" OnClick="Button8_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="Button9" runat="server" class="calc_btn" Text="9" OnClick="Button9_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="ButtonMinus" runat="server" class="calc_btn" Text="/" OnClick="ButtonDivide_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="calc_td_btn">
                            <asp:Button ID="Button4" runat="server" class="calc_btn" Text="4" OnClick="Button4_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="Button5" runat="server" class="calc_btn" Text="5" OnClick="Button5_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="Button6" runat="server" class="calc_btn" Text="6" OnClick="Button6_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="ButtonMultiply" runat="server" class="calc_btn" Text="x" OnClick="ButtonMultiply_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="calc_td_btn">
                            <asp:Button ID="Button1" runat="server" class="calc_btn" Text="1" OnClick="Button1_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="Button2" runat="server" class="calc_btn" Text="2" OnClick="Button2_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="Button3" runat="server" class="calc_btn" Text="3" OnClick="Button3_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="ButtonDivide" runat="server" class="calc_btn" Text="-" OnClick="ButtonMinus_Click"/>
                        </td>
                    </tr>
                     <tr>
                        <td class="calc_td_btn">
                            <asp:Button id="Button0" runat="server" class="calc_btn" Text="0" OnClick="Button0_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="ButtonBracketsOpen" runat="server" class="calc_btn" Text="(" OnClick="ButtonBracketsOpen_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="ButtonBracketsClose" runat="server" class="calc_btn" Text=")" OnClick="ButtonBracketsClose_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="ButtonPlus" runat="server" class="calc_btn" Text="+" OnClick="ButtonPlus_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="calc_td_btn">
                            <asp:Button id="ButtenC" runat="server" class="calc_btn" Text="C" OnClick="ButtonC_Click"/>
                        </td>
                        <td class="calc_td_btn">
                            <asp:Button ID="ButtonCE" runat="server" class="calc_btn" Text="CE" OnClick="ButtonCE_Click" />
                        </td>
                        <td class="calc_td_btn" colspan="2">
                            <asp:Button ID="ButtonEquals" runat="server" class="calc_btn" Text="Enter" style="width:95%;" OnClick="ButtonEquals_Click"/>
                        </td>
                    </tr>
   
                </table>
            </div>
        </form>
          </content>
            
    </section>
</body>
</html>

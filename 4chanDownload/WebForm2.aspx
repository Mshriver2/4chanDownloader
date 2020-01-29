<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="_4chanDownload.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<table class="nav-justified">
		<tr>
			<td>
				<asp:Label ID="Label2" runat="server" Text="Select 4chan or 4channel"></asp:Label>
			</td>
			<td>
				<asp:Label ID="Label1" runat="server" Text="Enter thread number:"></asp:Label>
			</td>
			<td>
				<asp:Label ID="Label3" runat="server" Text="Enter board letter:"></asp:Label>
			</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td style="height: 67px">
				<asp:RadioButton ID="chan" runat="server" Text="4chan" />
				<asp:RadioButton ID="channel" runat="server" Text="4channel" />
			</td>
			<td style="height: 67px">
				<asp:TextBox ID="TextBox1" runat="server" Width="190px"></asp:TextBox>
				<textarea id="TextArea1" name="S1" rows="2" style="width: 508px" runat="server"></textarea></td>
			<td style="height: 67px">
				<asp:TextBox ID="txtBoardLetter" runat="server"></asp:TextBox>
			</td>
			<td style="height: 67px">
				<asp:Button ID="btnDownload" runat="server" OnClick="btnDownload_Click" Text="Download Thread" Width="113px" />
			</td>
		</tr>
	</table>
</asp:Content>

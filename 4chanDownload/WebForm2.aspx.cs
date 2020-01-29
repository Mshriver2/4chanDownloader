using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4chanDownload
{
	public partial class WebForm2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnDownload_Click(object sender, EventArgs e)
		{
			string threadNumber = TextBox1.Text;
			string boardLetter = txtBoardLetter.Text;

			WebClient client = new WebClient();
			string downloadString = client.DownloadString("http://boards.4channel.org/" + boardLetter + "/thread/" + threadNumber);

			TextArea1.Value = downloadString;
		}
	}
}
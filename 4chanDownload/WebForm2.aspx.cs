using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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

			//downloads the full threads html
			WebClient client = new WebClient();
			string downloadString = client.DownloadString("http://boards.4channel.org/" + boardLetter + "/thread/" + threadNumber);

			//used to capture image urls from html
			string regexValue = ("<img[^>]*?src\\s*=\\s*[\"\"']?([^'\"\" >]+?)[ '\"\"][^>]*?>");

			//matchs based on regexValue
			MatchCollection matches = Regex.Matches(downloadString, @regexValue);

			txtBoardLetter.Text = Convert.ToString(matches.Count);
			var totalMatchs = "";
			//runs as many times as the number of image url's
			for (var i=1;i>matches.Count;i++)
			{
				totalMatchs = totalMatchs + Convert.ToString(matches[i]);
			}

			TextArea1.Value = totalMatchs;
		}

		protected void testBtn_Click(object sender, EventArgs e)
		{
			string threadNumber = TextBox1.Text;
			string boardLetter = txtBoardLetter.Text;
			string html;
			using (WebClient client = new WebClient())
			{
				html = client.DownloadString("http://boards.4channel.org/" + boardLetter + "/thread/" + threadNumber);
			}
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);
			
			List<string> imageUrls = new List<string>();
			foreach (HtmlNode img in doc.DocumentNode.SelectNodes("//img"))
			{
				imageUrls.Add(img.GetAttributeValue("src", null));
			}
			TextArea1.Value = string.Join(" ", imageUrls);
		}
	}
}
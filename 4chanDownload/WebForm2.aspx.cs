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
			string html;

			//downloads the complete html from the thread
			using (WebClient client = new WebClient())
			{
				html = client.DownloadString("http://boards.4channel.org/" + boardLetter + "/thread/" + threadNumber);
			}
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);

			//generates list to store imageurls
			List<string> imageUrls = new List<string>();

			//adds all images from html into the imageUrls list
			foreach (HtmlNode img in doc.DocumentNode.SelectNodes("//img"))
			{
				imageUrls.Add(img.GetAttributeValue("src", null));
			}

			//runs once for every image in the imageUrls list
			for (int o = 0; o < imageUrls.Count; o++)
			{
				//debugLabel.Text = Server.MapPath(".");
				ImageDownload(imageUrls[o], Convert.ToString(o));
			}

			TextArea1.Value = string.Join(" ", imageUrls);
		}


		//Method to download the image files
		string ImageDownload(string fileName, string k)
		{
			
			using (WebClient client = new WebClient())
			{
				client.DownloadFile(new Uri("https:" + fileName), @"C:\Users\Max Shriver\Documents\Programming\4chanDownload\4chanDownload\temp\" + k + ".jpg");
			}
			return "complete";
		}
	}
}
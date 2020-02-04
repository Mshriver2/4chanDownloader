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
			string radioSelection = "";

			//checks if WebClient should use 4chan or 4channel in the url
			if (channelRadio.Checked)
			{
				radioSelection = "4channel";
			} else if (chanRadio.Checked){
				radioSelection = "4chan";
			}

			//downloads the complete html from the thread
			using (WebClient client = new WebClient())
			{
				html = client.DownloadString("https://boards." + radioSelection + ".org/" + boardLetter + "/thread/" + threadNumber);
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

			//cleans up the image urls' removes 's' from the end of url
			//for (int l = 2; l < imageUrls.Count; l++)
			//{
			//imageUrls[l] = imageUrls[l].Substring(fileName.Length - 3);
			//}

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
			//generates the correct file ending, extracted from end of fileName
			string result = fileName.Substring(fileName.Length - 3);

			using (WebClient client = new WebClient())
			{
				client.DownloadFile(new Uri("https:" + fileName), @"C:\Users\Max Shriver\Documents\Programming\4chanDownload\4chanDownload\temp\" + k + "." + result);
			}
			return "complete";
		}

		
	}
}
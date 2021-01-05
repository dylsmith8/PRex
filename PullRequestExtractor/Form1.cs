using Newtonsoft.Json;
using PullRequestExtractor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestExtractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string personalAccessToken = "63uprlttlpmgddqxvifqob4mnoxznfmidapy23uayw73xkulreha";
            string orgName = "LNSA-BSS";

			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(
						new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
						Convert.ToBase64String(
							System.Text.ASCIIEncoding.ASCII.GetBytes(
								string.Format("{0}:{1}", "", personalAccessToken))));



					using (HttpResponseMessage response = await client.GetAsync($"https://dev.azure.com/{orgName}/_apis/projects"))
					{
						response.EnsureSuccessStatusCode();
						string responseBody = await response.Content.ReadAsStringAsync();
						MessageBox.Show(responseBody);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

        private async void button2_Click(object sender, EventArgs e)
        {
			try
			{
				string personalAccessToken = "63uprlttlpmgddqxvifqob4mnoxznfmidapy23uayw73xkulreha";
				string orgName = "LNSA-BSS";

				using (HttpClient client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(
						new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
						Convert.ToBase64String(
							System.Text.ASCIIEncoding.ASCII.GetBytes(
								string.Format("{0}:{1}", "", personalAccessToken))));



					using (HttpResponseMessage response = await client.GetAsync($"https://dev.azure.com/{orgName}/Lexis®Gateway/_apis/git/pullrequests?api-version=6.0"))
					{
						response.EnsureSuccessStatusCode();
						string responseBody = await response.Content.ReadAsStringAsync();
						Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(responseBody);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
        }
    }
}

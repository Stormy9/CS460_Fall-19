using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using CS460_Hwk07.Models;

namespace CS460_Hwk07.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            // except it doesn't.....   [=
        }
        //===============================================================================
        public ActionResult User()
        {
            // do something -- and what is that warning message about/mean, exactly??
            // --- 'HomeController.User()' hides inherited member 'Controller.User'.
            // ---   use the 'new' keyword if hiding was intended
            return View();
        }
        //-------------------------------------------------------------------------------
        public ActionResult Repos()
        {
            // do something -- this doesn't get that weird warning message.....
            return View();
        }
        //-------------------------------------------------------------------------------
        public ActionResult Commits()
        {
            // do something -- this one doesn't have warning message either.....
            return View();
        }

        //===============================================================================
        // from Lab Sheet => 
        //                "Here's some code to (make GET requests from C# to Github API)"
        private string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            // passed in as param..... user info is: https://api.github.com/user
            //                   repo info is: https://api.github.com/user/Stormy9/repos
            //                                    can add ?per_page = 100 to the end
            //                   commits for a repo is: repos/Stormy9/footle/commits

            request.Headers.Add("Authorization", "token " + credentials);
                                                            // passed in as param

            // Required, see: https://developer.github.com/v3/#user-agent-required
            request.UserAgent = username;           // gets passed in as param
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }
        // At this point you get back data from the GitHub API as a JSON string. 
        // Now you need to parse it.  I highly recommend using Json.NET.
        //
        // It's already installed in your default MVC app. I've used both their regular 
        //   deserializer as well as their LINQ-to-JSON and both will work well here. 
        //      https://www.newtonsoft.com/json/help/html/DeserializeObject.htm
        //      https://www.newtonsoft.com/json/help/html/QueryJson.htm
        //
        //   Be as efficient as possible. Follow KISS -- you don't need every piece
        //   of data from the json returned by GitHub, just extract what you need.
        //
        //===============================================================================
        //===============================================================================
        //
        // We show in class one way to generate JSON from an action method. 
        // Here's another way to do it when you have a normal C# object:
        //    (from lab sheet)
        public ActionResult ApiMethod(string someInput)
        {
            // Do what is needed to obtain a C# object containing data you wish to convert to JSON
            IEnumerable<CommitModel> commits = getIt();

            return new ContentResult
            {
                // serialize C# object "commits" to JSON using Newtonsoft.Json.JsonConvert
                Content = JsonConvert.SerializeObject(commits),
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };
        }
        //-------------------------------------------------------------------------------
        private IEnumerable<CommitModel> getIt()
        {
            throw new NotImplementedException();
        }
        //===============================================================================
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Gov_il
{
    public class GetApi
    {
        public void GetLanguageTitle()
        {
            string language = "/en";
            string chackReg = "^[\u0000-\u007F]+$";
;

            RestClient restClient = new RestClient("https://www.gov.il");
            RestRequest restRequest = new RestRequest(language, Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;
            string title = Regex.Match(content, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
            RegexOptions.IgnoreCase).Groups["Title"].Value;
            var isMatch = Regex.IsMatch(title, chackReg);
            Assert.AreEqual(true, isMatch);
        }
    }
}


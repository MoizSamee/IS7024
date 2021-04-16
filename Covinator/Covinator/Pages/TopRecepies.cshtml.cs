using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using QuickType;

namespace Covinator.Pages
{
    public class TopRecepiesModel : PageModel
    {
        public void OnGet()
        {

            using (var webClient = new WebClient())
            {
                string recepies = webClient.DownloadString("https://momsspaghetti.azurewebsites.net/?getMostSearched=true");


                JArray recepiesjsonArray = JArray.Parse(recepies);

                var result = Welcome.FromJson(recepiesjsonArray.ToString());

                /*ViewData["Recepies"] = recepiesjsonArray.ToString();*/
                ViewData["Recepies"] = result;

            }
        }
    }
}

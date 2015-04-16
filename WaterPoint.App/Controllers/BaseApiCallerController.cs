using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaterPoint.App.ApiClient.ApiCaller.Interfaces;

namespace WaterPoint.App.Controllers
{
    public class BaseApiCallerController<T> : Controller where T : IApiCaller
    {


    }
}
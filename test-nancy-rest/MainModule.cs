using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.ModelBinding;

namespace Test.Nancy.Rest
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = parameter => { return View["index", Request.Url]; };
        }

    }

}

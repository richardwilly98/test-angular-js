using Nancy;

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

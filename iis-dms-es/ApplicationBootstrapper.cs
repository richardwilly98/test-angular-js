using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Conventions;

namespace Test.Nancy.Rest
{
    public class ApplicationBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("views", @"views")); 
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("scripts", @"scripts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("content", @"content"));
            base.ConfigureConventions(nancyConventions);
        }
    }
}

using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using littleleagueService.DataObjects;
using littleleagueService.Models;
using System;

namespace littleleagueService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new littleleagueInitializer());
        }
    }

    public class littleleagueInitializer : DropCreateDatabaseIfModelChanges<littleleagueContext>
    {
        protected override void Seed(littleleagueContext context)
        {
            List<User> users = new List<User>
            {
                new User { Id = "1", Name = "Dave" },
                new User { Id = "2", Name = "John" }
              
            };
            List<Activity> activities = new List<Activity>
            {
                new Activity { Id = "1", ActivityName = "Squash", Date=DateTime.Now, Player1=users[0], Player2=users[1], Player1Score=2, Player2Score=3 }
              
            };
            foreach (User user in users)
            {
                context.Set<User>().Add(user);
            }
            foreach (Activity activity in activities)
            {
                context.Set<Activity>().Add(activity);
            }
            base.Seed(context);
        }
    }
}


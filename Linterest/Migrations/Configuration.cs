using Linterest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Linterest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Linterest.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Linterest.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var userStore = new UserStore<LinterestUser>(context);
            var userManager = new UserManager<LinterestUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(context);



            if (!context.Users.Any(x => x.UserName == "lsat@gmail.com"))
            {
                var Luke = new LinterestUser
                {
                    Handle = "LukeS",
                    Email = "lsat@gmail.com",
                    UserName = "lsat@gmail.com",
                };
                userManager.Create(Luke, "MyP@ssw0rd!");


                var Ann = new LinterestUser
                {
                    Handle = "AnnM",
                    Email = "ama@gmail.com",
                    UserName = "ama@gmail.com",
                };
                userManager.Create(Ann, "OmyGoodness3$");


                var Jerry = new LinterestUser
                {
                    Handle = "JerryB",
                    Email = "odo@gmail.com",
                    UserName = "odo@gmail.com",
                };
                userManager.Create(Jerry, "comeHome56*");


                var Izzy = new LinterestUser
                {
                    Handle = "IzzyS",
                    Email = "izz@gmail.com",
                    UserName = "izz@gmail.com",
                };
                userManager.Create(Izzy, "passwordT90#*");

                //users adding info
                Luke.Lins.Add(new Lin()
                {
                    Author = Luke,
                    CreatedOn = DateTime.Now.AddDays(-1),
                    Text = "How not to be an idiot",
                    ImageUrl = "http://i.imgur.com/Fjs7div.jpg",
                    PinImageUrl = "http://i.imgur.com/Fjs7div.jpg",
                });
                Luke.Lins.Add(new Lin()
                {
                    Author = Luke,
                    CreatedOn = DateTime.Now,
                    Text = "I am loving this, hoping to start my first developer job soon",
                    ImageUrl = "http://i.imgur.com/rX5jvWY.png",
                    PinImageUrl = "http://i.imgur.com/rX5jvWY.png"
                });
                Luke.Lins.Add(new Lin()
                {
                    Author = Luke,
                    CreatedOn = DateTime.Now.AddDays(-3),
                    Text = "Omg my dog ate all my grilled chicken and drunk all my vodka",
                    ImageUrl = "http://cx.aos.ask.com/question/aq/1400px-788px/can-dogs-eat-turkey-bones_ddee09800a124de9.jpg",
                    PinImageUrl = "http://cx.aos.ask.com/question/aq/1400px-788px/can-dogs-eat-turkey-bones_ddee09800a124de9.jpg",
                });
                Ann.Lins.Add(new Lin()
                {
                    Author = Ann,
                    CreatedOn = DateTime.Now,
                    Text = "I love this dress, but the price tag is hefty"
                });
                Ann.Lins.Add(new Lin()
                {
                    Author = Ann,
                    CreatedOn = DateTime.Now,
                    Text = "I have such an awesome cat, i adore you nickred"
                });
                Ann.Lins.Add(new Lin()
                {
                    Author = Ann,
                    CreatedOn = DateTime.Now.AddHours(-5),
                    Text = "Clinton for president, Sander for vice, woman power, got to rule the world"
                });
                Jerry.Lins.Add(new Lin()
                {
                    Author = Jerry,
                    CreatedOn = DateTime.Now.AddHours(3),
                    Text =
                        "How could Barcelona loose this game, they better call Merci to book, cant pay all this money for nothing"
                });
                Jerry.Lins.Add(new Lin()
                {
                    Author = Jerry,
                    CreatedOn = DateTime.Now.AddDays(-1),
                    Text = "Ronaldo better bring his game on today, Real Madrib better nail Manchester United bad"
                });
                Jerry.Lins.Add(new Lin()
                {
                    Author = Jerry,
                    CreatedOn = DateTime.Now,
                    Text = "Footbal state of mind"
                });
                Jerry.Lins.Add(new Lin()
                {
                    Author = Jerry,
                    CreatedOn = DateTime.Now.AddDays(-5),
                    Text =
                        "Heading to New York to watch NYC FC vs NY Generals, MAY THE ODDS BE IN THE BEST TEAMS FAVOR "
                });
                Izzy.Lins.Add(new Lin()
                {
                    Author = Izzy,
                    CreatedOn = DateTime.Now,
                    Text = "bATMAN vs sUPERMAN...EPIC MOVIE..."
                });
                Izzy.Lins.Add(new Lin()
                {
                    Author = Izzy,
                    CreatedOn = DateTime.Now,
                    Text = "Ironyard Little Rock graduation in 4 weeks, gonna turn up"
                });
                Izzy.Lins.Add(new Lin()
                {
                    Author = Izzy,
                    CreatedOn = DateTime.Now.AddHours(-10),
                    Text = "i love me some ice cream, who is with me"
                });

                Izzy.Following.Add(Luke);
                Izzy.Following.Add(Jerry);
                Izzy.Following.Add(Ann);

                Luke.Following.Add(Izzy);
                Luke.Following.Add(Jerry);

                Ann.Following.Add(Luke);
                Ann.Following.Add(Jerry);

                Jerry.Following.Add(Luke);

                context.Newts.AddRange(Luke.Newts);
                context.Newts.AddRange(Ann.Newts);
                context.Newts.AddRange(Jerry.Newts);
                context.Newts.AddRange(Izzy.Newts);

            }
        }
}

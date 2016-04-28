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
            var roleManager = new RoleManager<IdentityRole>(roleStore);



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
                    ImageUrl =
                        "http://cx.aos.ask.com/question/aq/1400px-788px/can-dogs-eat-turkey-bones_ddee09800a124de9.jpg",
                    PinImageUrl =
                        "http://cx.aos.ask.com/question/aq/1400px-788px/can-dogs-eat-turkey-bones_ddee09800a124de9.jpg",
                });
                Ann.Lins.Add(new Lin()
                {
                    Author = Ann,
                    CreatedOn = DateTime.Now,
                    Text = "Pretty Nice",
                    ImageUrl = "http://i.imgur.com/xDpbkSc.jpg",
                    PinImageUrl = "http://i.imgur.com/xDpbkSc.jpg",

                });
                Ann.Lins.Add(new Lin()
                {
                    Author = Ann,
                    CreatedOn = DateTime.Now,
                    Text = "I have such an awesome kitten, i adore you nickred",
                    ImageUrl =
                        "http://images2.fanpop.com/image/photos/9700000/Adorable-lil-Kittens-cute-kittens-9781743-670-578.jpg",
                    PinImageUrl =
                        "http://images2.fanpop.com/image/photos/9700000/Adorable-lil-Kittens-cute-kittens-9781743-670-578.jpg",
                });
                Ann.Lins.Add(new Lin()
                {
                    Author = Ann,
                    CreatedOn = DateTime.Now.AddHours(-5),
                    Text = "how i feel when i get stuck coding",
                    ImageUrl =
                        "http://vignette1.wikia.nocookie.net/cardfight/images/f/fb/Keep-calm-and-may-the-odds-be-ever-in-your-favor-57.png/revision/latest?cb=20150326090112",
                    PinImageUrl =
                        "http://vignette1.wikia.nocookie.net/cardfight/images/f/fb/Keep-calm-and-may-the-odds-be-ever-in-your-favor-57.png/revision/latest?cb=20150326090112",

                });
                Jerry.Lins.Add(new Lin()
                {
                    Author = Jerry,
                    CreatedOn = DateTime.Now.AddHours(3),
                    Text = "My favorite Barcelona",
                    ImageUrl = "https://media.timeout.com/images/101851347/image.jpg",
                    PinImageUrl = "https://media.timeout.com/images/101851347/image.jpg",

                });
                Jerry.Lins.Add(new Lin()
                {
                    Author = Jerry,
                    CreatedOn = DateTime.Now.AddDays(-1),
                    Text = "There are soccer teams and then there is the Soccer Team",
                    ImageUrl = "http://storage.zideo.nl/channel/6c5953566e673d3d/FCBarcelona0809.jpg",
                    PinImageUrl = "http://storage.zideo.nl/channel/6c5953566e673d3d/FCBarcelona0809.jpg",
                });
                Jerry.Lins.Add(new Lin()
                {
                    Author = Jerry,
                    CreatedOn = DateTime.Now,
                    Text = "Footbal state of mind",
                    ImageUrl =
                        "http://timleberecht.com/wp/wp-content/uploads/2015/06/AAEAAQAAAAAAAAJHAAAAJGM2NzNjYTY3LWZhODgtNDQ2Yy04NmE5LTViZGIyN2FmMGI1Yg.jpg",
                    PinImageUrl =
                        "http://timleberecht.com/wp/wp-content/uploads/2015/06/AAEAAQAAAAAAAAJHAAAAJGM2NzNjYTY3LWZhODgtNDQ2Yy04NmE5LTViZGIyN2FmMGI1Yg.jpg",

                });
                Jerry.Lins.Add(new Lin()
                {
                    Author = Jerry,
                    CreatedOn = DateTime.Now.AddDays(-5),
                    Text = "My Other team, never say never",
                    ImageUrl = "http://gazettereview.com/wp-content/uploads/2015/10/Manchester-City.jpg",
                    PinImageUrl = "http://gazettereview.com/wp-content/uploads/2015/10/Manchester-City.jpg",
                });
                Izzy.Lins.Add(new Lin()
                {
                    Author = Izzy,
                    CreatedOn = DateTime.Now,
                    Text = "bATMAN vs sUPERMAN...EPIC MOVIE...",
                    ImageUrl = "http://945kski.com/wp-content/uploads/2016/02/2015-movie-batman-vs-superman-42469.jpg",
                    PinImageUrl =
                        "http://945kski.com/wp-content/uploads/2016/02/2015-movie-batman-vs-superman-42469.jpg",

                });
                Izzy.Lins.Add(new Lin()
                {
                    Author = Izzy,
                    CreatedOn = DateTime.Now,
                    Text = "Ironyard Little Rock graduation in 4 weeks, gonna turn up",
                    ImageUrl =
                        "http://static.srcdn.com/slir/w700-h350-q90-c700:350/wp-content/uploads/Avengers-Age-of-Ultron-Guide.jpg",
                    PinImageUrl =
                        "http://static.srcdn.com/slir/w700-h350-q90-c700:350/wp-content/uploads/Avengers-Age-of-Ultron-Guide.jpg",
                });
                Izzy.Lins.Add(new Lin()
                {
                    Author = Izzy,
                    CreatedOn = DateTime.Now.AddHours(-10),
                    Text = "Super Hero Movie Maniac",
                    ImageUrl = "http://cdn1.sciencefiction.com/wp-content/uploads/2015/07/the-flash-concept-art.jpg",
                    PinImageUrl = "http://cdn1.sciencefiction.com/wp-content/uploads/2015/07/the-flash-concept-art.jpg",

                });

                context.Lins.AddRange(Luke.Lins);
                context.Lins.AddRange(Jerry.Lins);
                context.Lins.AddRange(Ann.Lins);
                context.Lins.AddRange(Izzy.Lins);


            }
        }
    }
}

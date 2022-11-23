using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LexFlix.Data;
using System;
using System.Linq;

namespace LexFlix.Models
{
    public static class SeedMovieData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }
                context.Movies.AddRange(
                    new Movies
                    {
                        Title = "Parasite",
                        ReleaseYear = 2019,
                        Director = "Bong, Joon-ho",
                        Price = 200,
                        ImageURL = "https://i.ibb.co/NVrDRkn/Parasite.jpg"
                    },

                    new Movies
                    {
                        Title = "The Irishman",
                        ReleaseYear = 2019,
                        Director = "Scorsese, Martin",
                        Price = 275,
                        ImageURL = "https://i.ibb.co/y6ZfQgx/Irishman.jpg"
                    },

                    new Movies
                    {
                        Title = "Joker",
                        ReleaseYear = 2016,
                        Director = "Phillips, Todd",
                        Price = 300,
                        ImageURL = "https://i.ibb.co/Srn90fY/Joker.jpg"
                    },

                    new Movies
                    {
                        Title = "Top Gun: Maverick",
                        ReleaseYear = 2022,
                        Director = "Kosinski, Joseph",
                        Price = 400,
                        ImageURL = "https://i.ibb.co/JBgRLv9/Top-Gun.jpg"
                    },

                    new Movies
                    {
                        Title = "The Witch",
                        ReleaseYear = 2015,
                        Director = "Eggers, Robert",
                        Price = 150,
                        ImageURL = "https://i.ibb.co/fnzRfXv/Witch.jpg"
                    },

                    new Movies
                    {
                        Title = "Arrival",
                        ReleaseYear = 2016,
                        Director = "Villeneuve, Denis",
                        Price = 200,
                        ImageURL = "https://i.ibb.co/QJC4d6Y/Arrival.jpg"
                    },

                    new Movies
                    {
                        Title = "Pandorum",
                        ReleaseYear = 2009,
                        Director = "Alvart, Christian",
                        Price = 100,
                        ImageURL = "https://i.ibb.co/2MvBGWN/Pandorum.jpg"
                    },

                    new Movies
                    {
                        Title = "Event Horizon",
                        ReleaseYear = 1997,
                        Director = "Anderson, Paul W. S.",
                        Price = 75,
                        ImageURL = "https://i.ibb.co/qWrrBgg/Horizon.jpg"
                    },

                    new Movies
                    {
                        Title = "Enola Holmes",
                        ReleaseYear = 2020,
                        Director = "Bradbeer, Harry",
                        Price = 175,
                        ImageURL = "https://i.ibb.co/cx5Ks0Q/Enola.jpg"
                    },

                    new Movies
                    {
                        Title = "Black Adam",
                        ReleaseYear = 2022,
                        Director = "Collet-Serra, Jaume",
                        Price = 400,
                        ImageURL = "https://i.ibb.co/89pGHD6/Adam.jpg"
                    },

                    new Movies
                    {
                        Title = "The Blair Witch Project",
                        ReleaseYear = 1999,
                        Director = "Daniel Myrick",
                        Price = 100,
                        ImageURL = "https://i.ibb.co/vh8Ctyj/Blair-Witch.jpg"
                    },

                    new Movies
                    {
                        Title = "Pacific Rim",
                        ReleaseYear = 2013,
                        Director = "Guillermo del Toro",
                        Price = 150,
                        ImageURL = "https://i.ibb.co/pKNk4zd/Pacific-Rim.jpg"
                    },

                    new Movies
                    {
                        Title = "Blade",
                        ReleaseYear = 1998,
                        Director = "Stephen Norrington",
                        Price = 125,
                        ImageURL = "https://i.ibb.co/nLbTkS2/Blade.jpg"
                    },

                    new Movies
                    {
                        Title = "The Lord of the Rings: The Fellowship of the Ring",
                        ReleaseYear = 2001,
                        Director = "Peter Jackson",
                        Price = 150,
                        ImageURL = "https://i.ibb.co/7ztFXGP/Fellowship.jpg"
                    },

                    new Movies
                    {
                        Title = "The Lord of the Rings: The Two Towers",
                        ReleaseYear = 2002,
                        Director = "Peter Jackson",
                        Price = 150,
                        ImageURL = "https://i.ibb.co/f9WXRdH/Towers.jpg"
                    },

                    new Movies
                    {
                        Title = "The Lord of the Rings: The Return of the King",
                        ReleaseYear = 2003,
                        Director = "Peter Jackson",
                        Price = 150,
                        ImageURL = "https://i.ibb.co/nM69Ccp/King.jpg"
                    },

                    new Movies
                    {
                        Title = "It: Chapter One",
                        ReleaseYear = 2017,
                        Director = "Andy Muschietti",
                        Price = 175,
                        ImageURL = "https://i.ibb.co/m5JYPm1/it.jpg"
                    },

                    new Movies
                    {
                        Title = "It: Chapter Two",
                        ReleaseYear = 2019,
                        Director = "Andy Muschietti",
                        Price = 175,
                        ImageURL = "https://i.ibb.co/gyYX1TG/it2.jpg"
                    },

                    new Movies
                    {
                        Title = "El Camino: A Breaking Bad Movie",
                        ReleaseYear = 2019,
                        Director = "Vince Gilligan",
                        Price = 200,
                        ImageURL = "https://i.ibb.co/gw3W3Vg/El-Camino11111111.jpg"
                    },

                    new Movies
                    {
                        Title = "Prisoners",
                        ReleaseYear = 2013,
                        Director = "Denis Villeneuve",
                        Price = 175,
                        ImageURL = "https://i.ibb.co/9nJbWFK/Prisoners.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
//Link used to complete the seed appplication in the project for all members of the group to see! do not use step 1 and 2 
//https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-6.0&tabs=visual-studio
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitialzer
    {

        //intial
        public static void Seed(IApplicationBuilder applicationBuilder)
        {

            // creating our database 
            using (var serviceScope=applicationBuilder.ApplicationServices.CreateScope() )
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                // if database doesn't exist create it 

               if(!context.Books.Any())
                {
                    //adding data to database
                    context.Books.AddRange(new Book()
                  
                    {
                        Title="1st book Title",
                        Description="1set book",
                        IsRead=true,
                        DateRead=DateTime.Now.AddDays(-10),
                        Rate=4,
                        Genre="Math",
                        Author="Riyad Al-Ali",
                        CoverUrl="https...",
                        DateAdded=DateTime.Now



                    },


                    new Book()
                    {
                        Title = "2st book Title",
                        Description = "2st book title",
                        IsRead = false,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Math",
                        Author = "Riyad Al-Ali",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now
                    }
                    );
                    context.SaveChanges(); // save changes to database

                }

            }
        }
    }
}

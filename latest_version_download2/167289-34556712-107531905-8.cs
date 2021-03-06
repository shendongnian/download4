    using System;
    using System.Linq;
    using Microsoft.Data.Entity;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace apiservice.Models
    {
        public static class SampleData
        {
            public static void Initialize(IServiceProvider serviceProvider) {
                var context=serviceProvider.GetService<BookContext>();
                context.Database.Migrate();
                if (!context.Books.Any()) {
                    var austen = context.Authors.Add(
                        new Author { LastName = "Austen", FirstName = "Jane" }).Entity;
                    var dickens = context.Authors.Add(
                        new Author { LastName = "Dickens", FirstName = "Charles" }).Entity;
                    var cervantes = context.Authors.Add(
                        new Author { LastName = "Cervantes", FirstName = "Miguel" }).Entity;
                            
                    context.Books.AddRange(
                        new Book {
                            Title = "Pride and Prejudice",
                            Year = 1813,
                            Author = austen,
                            Price = 9.99M,
                            Genre = "Comedy of manners"
                        },
                        new Book {
                            Title = "Northanger Abbey",
                            Year = 1817,
                            Author = austen,
                            Price = 12.95M,
                            Genre = "Gothic parody"
                        },
                        new Book {
                            Title = "David Copperfield",
                            Year = 1850,
                            Author = dickens,
                            Price = 15,
                            Genre = "Bildungsroman"
                        },
                        new Book {
                            Title = "Don Quixote",
                            Year = 1617,
                            Author = cervantes,
                            Price = 8.95M,
                            Genre = "Picaresque"
                        }
                    );
    
                    context.SaveChanges(); 
                }
            }
        }    
    }

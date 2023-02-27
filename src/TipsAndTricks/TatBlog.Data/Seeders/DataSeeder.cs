using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext;
        public DataSeeder(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Posts.Any()) return;

            var authors = AddAuthors();
            var categories = AddCategories();
            var tags = AddTags();
            var posts = AddPosts(authors, categories, tags);
        }

        private IList<Author> AddAuthors()
        {
            var authors = new List<Author>()
            {
                new()
                {
                    FullName = "Jason Mouth",
                    UrlSlug = "jason-mouth",
                    Email = "json@gmail.com",
                    JoinedDate = new DateTime(2022,10, 21),
                    Notes = ""
                },
                new()
                {
                    FullName = "Jessica Wonders",
                    UrlSlug = "jessica-wonders",
                    Email = "jessica665@motip.com",
                    JoinedDate = new DateTime(2020,4, 19),
                    Notes = ""
                },
                new()
                {
                    FullName = "Nguyen Van Anh",
                    UrlSlug = "nguyen-van-anh",
                    Email = "vananh@gmail.com",
                    JoinedDate = new DateTime(2020,1, 10),
                    Notes = ""
                },
                new()
                {
                    FullName = "Phan Ngoc Bach",
                    UrlSlug = "phan-ngoc-bach",
                    Email = "bachngoc@dlu.edu.vn",
                    JoinedDate = new DateTime(2022,9, 16),
                    Notes = ""
                },
                new()
                {
                    FullName = "Nguyen Thuy Chi",
                    UrlSlug = "nguyen-thuy-chi",
                    Email = "chichi55@gmail.com",
                    JoinedDate = new DateTime(2023,2, 3),
                    Notes = ""
                },
                new()
                {
                    FullName = "Nguyen Thuy Trung",
                    UrlSlug = "nguyen-thuy-chi",
                    Email = "chichi55@gmail.com",
                    JoinedDate = new DateTime(2021,12, 3),
                    Notes = ""
                }

            };

            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();

            return authors;
        }
        private IList<Category> AddCategories() 
        {
            var categories = new List<Category>()
            {
                new()
                {
                    Name = ".NET Core",
                    UrlSlug = "dot-net",
                    Description = ".NET Core"
                },
                new()
                {
                    Name = "Architecture",
                    UrlSlug = "architecture",
                    Description = "Architecture"
                },
                new()
                {
                    Name = "Messaging",
                    UrlSlug = "messaging",
                    Description = "Messaging"
                },
                new()
                {
                    Name = "OOP",
                    UrlSlug = "oop",
                    Description = "Object-Oriented Programming"
                },
                new()
                {
                    Name = "Design Patterns",
                    UrlSlug = "design-patterns",
                    Description = "Design Patterns"
                },

            };

            _dbContext.AddRange(categories);
            _dbContext.SaveChanges();

            return categories;

        }
        private IList<Tag> AddTags() 
        {
            var tags = new List<Tag>()
            {
                new()
                {
                    Name = "Google",
                    UrlSlug = "google",
                    Description = "Google applications and stuffs"
                },
                new()
                {
                    Name = "ASP.NET MVC",
                    UrlSlug = "asp-net-mvc",
                    Description = "ASP.NET MVC"
                },
                new()
                {
                    Name = "Razor Page",
                    UrlSlug = "razor-page",
                    Description = "Razor Page",
                },
                new()
                {
                    Name = "Blazor",
                    UrlSlug = "blazor",
                    Description = "Blazor"
                },
                new()
                {
                    Name = "Deep Learning",
                    UrlSlug = "deep-learning",
                    Description = "Deep Learning"
                },
                new()
                {
                    Name = "Neuro Network",
                    UrlSlug = "neuro-network",
                    Description = "Neuro Network"
                },
            };

            _dbContext.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }
        private IList<Post> AddPosts(
            IList<Author> authors,
            IList<Category> categories,
            IList<Tag> tags)
        {
            var posts = new List<Post>()
            {
                new()
                {
                    Title = "ASP.NET Diagnostic Scenarios",
                    ShortDescription = "",
                    Description = "",
                    Meta = "",
                    UrlSlug ="",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 26, 10, 20, 0),
                    ModifiedDate = new DateTime(2021, 9, 26, 10, 20, 0),
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },
                new()
                {
                    Title = "Productivity Shortcuts on Windows 10 & 11",
                    ShortDescription = "",
                    Description = "",
                    Meta = "",
                    UrlSlug ="",
                    Published = false,
                    PostedDate = new DateTime(2020, 7, 15, 8, 22, 0),
                    ModifiedDate = new DateTime(2020, 12, 6, 11, 4, 0),
                    ViewCount = 14,
                    Author = authors[2],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[3]
                    }
                },
                new()
                {
                    Title = "Array or Object JSON deserialization",
                    ShortDescription = "",
                    Description = "",
                    Meta = "",
                    UrlSlug ="",
                    Published = true,
                    PostedDate = new DateTime(2019, 7, 2, 21, 5, 0),
                    ModifiedDate = new DateTime(2020, 6, 6, 10, 28, 0),
                    ViewCount = 20,
                    Author = authors[4],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[2]
                    }
                }
            };
            
            _dbContext.AddRange(posts);
            _dbContext.SaveChanges();

            return posts;
        }

       
    }
}

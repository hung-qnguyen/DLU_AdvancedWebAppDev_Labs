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

        private Random random = new Random();
        private string[] tagNames = { "Google", "ASP.NET MVC", "Razor Page", "Blazor", "Deep Learning", "Neuro Network", "Unity", "Machine Learning", "Microsoft", "Oracle", "Linux", "Windows", "Apple", "Fedora 37", "KDE Plasma", "Jetbrains", "Intel", "AMD", "Virtual Reality", "Blockchains" };

        private string[] postTitles = { "ASP.NET Diagnostic Scenarios", "Productivity Shortcuts on Windows 10 & 11", "Array or Object JSON deserialization", "Increase your Linux knowledge", "Is the Macbook Pro worth it?", "Guide to installing Fedora 37", "Chip war between Intel and AMD", "Is 5G the future?", "10 Non-Traditional Hacks for Incoming Computer Science Students", "A Modern Approach to Data Protection", "Android Intelligence", "Building a Secure and Compliant Cloud Strategy with Managed Private Cloud IaaS", "Business Solutions from Intel", "Elevating Business Computing with AMD", "Enterprise Mobility Transformation", "Intelligent Automation", "In the Battle Against Ransomware, Organizations Need to Enhance their Data Protection Capabilities", "New Developments in Solid State Drive (SSD) Technology", "Patch Tuesday Debugged", "The Future of Endpoint Software Is a Unified Platform Approach", "What’s next for Fintech, and how banks can leverage new-wave technologies to deliver superior services to all", "The Promise of Connected RPA", "Is this the end of non-compete contracts?", "A New IT Consumption Model: Pay As You Go", "How do you proactively solve problems by tracking IoT devices?", "19 Techniques to Control the Chaos in Data Storage", "The Future of Apple Endpoint Software is Here and Mosyle Is Leading the Way", "API limitation evasion with SwaggerHub Explore analysis tool", "Data that doesn’t cost the earth: A decade of progress", "The importance of the circular economy in the tech sector", "The AI resource challenge: It’s infrastructure & compute, not data scarcity", "MindsDB drives AI for open source machine learning ", "NTT & Palo Alto Networks get sassy on secure SaaS SASE" };

        private string formatToUrlSlug(string str)
        {
            return string.Join("-", str.ToLower().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        public DataSeeder(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            //if (_dbContext.Posts.Any()) return;

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
                    FullName = "Doan Dinh Mai",
                    UrlSlug = "doan-dinh-mai",
                    Email = "maidoan@gmail.com",
                    JoinedDate = new DateTime(2021,12, 3),
                    Notes = ""
                }

            };

            foreach (var item in authors)
            {
                if (!_dbContext.Authors.Any(a => a.UrlSlug == item.UrlSlug))
                {
                    _dbContext.Authors.Add(item);
                }
            }

            //_dbContext.Authors.AddRange(authors);
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
                new()
                {
                    Name = "Structured Programming",
                    UrlSlug = "structured-programming",
                    Description = "Structured Programming"
                },
                new()
                {
                    Name = "Databases",
                    UrlSlug = "databases",
                    Description = "Databases"
                },
                new()
                {
                    Name = "Networking",
                    UrlSlug = "networking",
                    Description = "Networking"
                },
                new()
                {
                    Name = "Computer Architecture",
                    UrlSlug = "computer-architecture",
                    Description = "Computer Architecture"
                },
                new()
                {
                    Name = "Game Development",
                    UrlSlug = "game-development",
                    Description = "Game Development"
                }

            };

            _dbContext.AddRange(categories);
            _dbContext.SaveChanges();

            return categories;

        }
        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>();
            for (int i = 0; i < tagNames.Length; i++)
            {
                tags.Add(
                    new()
                    {
                        Name = tagNames[i],
                        UrlSlug = formatToUrlSlug(tagNames[i]),
                        Description = tagNames[i]
                    }
                );
            }

            _dbContext.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }
        /*private IList<Post> AddPosts(
            IList<Author> authors,
            IList<Category> categories,
            IList<Tag> tags)
        {
            var posts = new List<Post>();
            for (int i = 0; i < postTitles.Length; i++)
            {
                posts.Add(
                    new()
                    {
                        Title = postTitles[i],
                        ShortDescription = postTitles[i],
                        Description = postTitles[i],
                        Meta = "",
                        UrlSlug = formatToUrlSlug(postTitles[i]),
                        Published = true,
                        PostedDate = new DateTime(random.Next(1990, 2024),
                            random.Next(1, 13),
                            random.Next(1, 29),
                            random.Next(25),
                            random.Next(61),
                            random.Next(61)),
                        ModifiedDate = new DateTime(random.Next(1990, 2024),
                            random.Next(1, 13),
                            random.Next(1, 29),
                            random.Next(25),
                            random.Next(61),
                            random.Next(61)),
                        ViewCount = random.Next(256),
                        Author = authors[random.Next(5)],
                        Category = categories[random.Next(19)],
                        Tags = new List<Tag>()
                        {
                            tags[random.Next(tagNames.Length)]
                        }
                    }
                ) ;
            }

            _dbContext.AddRange(posts);
            _dbContext.SaveChanges();

            return posts;
        }*/

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

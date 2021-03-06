    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CoursePath
    {
        class Program
        {
            static void Main(string[] args)
            {
                var courses = new List<CourseInfo>()
                              {
                                  new CourseInfo("Finance 101", 1, DateTime.Parse("9:00 AM"), DateTime.Parse("10:00 AM")),
                                  new CourseInfo("Finance 102", 2, DateTime.Parse("10:00 AM"), DateTime.Parse("11:00 AM")),
                                  new CourseInfo("Python 300", 3, DateTime.Parse("10:00 AM"), DateTime.Parse("11:00 AM")),
                                  new CourseInfo("Security 101", 4, DateTime.Parse("11:00 AM"), DateTime.Parse("12:00 PM")),
                                  new CourseInfo("Economics 201", 5, DateTime.Parse("9:00 AM"), DateTime.Parse("12:00 PM")),
                                  new CourseInfo("Database 200", 6, DateTime.Parse("11:00 AM"), DateTime.Parse("1:00 PM"))
                              };
    
                var results = new List<List<CourseInfo>>();
    
                BuildCourseList(null, courses, results);
    
                results.ForEach(c => Console.WriteLine(string.Join(" -> ", c.Select(x => x.Name)) + $" -> Done ({c.Sum(x => x.Credits)} credits)"));
                Console.WriteLine();
                var optimal = results.Select(path => new {Path = path, TotalCredits = path.Sum(c => c.Credits)}).OrderByDescending(path => path.TotalCredits).First();
                Console.WriteLine("Optimal Path: " + string.Join(" -> ", optimal.Path.Select(x => x.Name)) + $" -> Done ({optimal.TotalCredits} credits)");
                Console.Read();
            }
    
            public static void BuildCourseList(List<CourseInfo> currentPath, List<CourseInfo> courses, List<List<CourseInfo>> results)
            {
                CourseInfo currentCourse = currentPath?.LastOrDefault();
                var candidates = (currentCourse == null ? courses : courses.Where(c => c.StarTime >= currentCourse.EndTime));
                if (currentPath != null)
                {
                    results.Add(currentPath);
                }
                foreach (var course in candidates)
                {
                    var nextPath = currentPath == null ? new List<CourseInfo>() : new List<CourseInfo>(currentPath);
                    nextPath.Add(course);
                    BuildCourseList(nextPath, courses, results);
                }
            }
        }
    
        public class CourseInfo
        {
            public CourseInfo(string name, int credits, DateTime starTime, DateTime endTime)
            {
                Name = name;
                Credits = credits;
                StarTime = starTime;
                EndTime = endTime;
            }
    
            public string Name { get; set; }
            public int Credits { get; set; }
            public DateTime StarTime { get; set; }
            public DateTime EndTime { get; set; }
        }
    }

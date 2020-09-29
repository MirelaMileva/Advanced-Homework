using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string contestInput = Console.ReadLine();
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userNames = new Dictionary<string, Dictionary<string, int>>();

            while (contestInput != "end of contests")
            {
                string[] contestInfo = contestInput.Split(":");
                string contest = contestInfo[0];
                string password = contestInfo[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }

                contestInput = Console.ReadLine();
            }

            string submissions = Console.ReadLine();

            while (submissions != "end of submissions")
            {
                //"{contest}=>{password}=>{username}=>{points}" 
                var submissionsInfo = submissions.Split("=>");
                string contestToCheck = submissionsInfo[0];
                string passwordToCheck = submissionsInfo[1];
                string userName = submissionsInfo[2];
                int points = int.Parse(submissionsInfo[3]);

                if (contests.ContainsKey(contestToCheck) && contests[contestToCheck] == passwordToCheck)
                {
                    if (!userNames.ContainsKey(userName))
                    {
                        userNames.Add(userName, new Dictionary<string, int>());
                    }

                    if (!userNames[userName].ContainsKey(contestToCheck))
                    {
                        userNames[userName].Add(contestToCheck, points);
                    }
                    else
                    {
                        if (userNames[userName][contestToCheck] < points)
                        {
                            userNames[userName][contestToCheck] = points;
                        }
                    }  
                    
                }

                submissions = Console.ReadLine();
            }

            var bestCandidate = userNames.OrderByDescending(u => u.Value.Values.Sum()).ToDictionary(a => a.Key, b => b.Value);
            var bestPointsCandidate = bestCandidate.Take(1);

            foreach (var item in bestPointsCandidate)
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value.Values.Sum()} points.");
            }

            Console.WriteLine("Ranking:");

            var students = userNames.OrderBy(s => s.Key).ToDictionary(a => a.Key, b => b.Value);

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key}");
                foreach (var item in student.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
                
            }
        }
    }
}

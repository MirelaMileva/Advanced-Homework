using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> vloggersWithFollowers = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> vloggersWithFollowings = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                input = FillInput(vloggersWithFollowers, vloggersWithFollowings, input);
            }

            int counter = 1;

            vloggersWithFollowers = vloggersWithFollowers.OrderByDescending(kvp => kvp.Value.Count).
                ThenBy(kvp => vloggersWithFollowings[kvp.Key].Count).ToDictionary(a => a.Key, b => b.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggersWithFollowers.Count} vloggers in its logs.");

            var mostFaumostVlogger = vloggersWithFollowers.First();
            HashSet<string> mostFaumostVloggerFollowers = mostFaumostVlogger.Value.OrderBy(f => f).ToHashSet();

            Console.WriteLine($"{counter++}. {mostFaumostVlogger.Key} : {mostFaumostVloggerFollowers.Count} followers, {vloggersWithFollowings[mostFaumostVlogger.Key].Count} following");

            foreach (var follower in mostFaumostVloggerFollowers)
            {
                Console.WriteLine($"*  {follower}");
            }

            foreach (var vlogerFollower in vloggersWithFollowers.Skip(1))
            {
                string name = vlogerFollower.Key;
                HashSet<string> followers = vlogerFollower.Value;

                Console.WriteLine($"{counter++}. {name} : {followers.Count} followers, {vloggersWithFollowings[name].Count} following");
            }
        }

        private static string FillInput(Dictionary<string, HashSet<string>> vloggersWithFollowers, Dictionary<string, HashSet<string>> vloggersWithFollowings, string input)
        {
            var splitted = input.Split();

            if (splitted[1] == "joined")
            {
                VloggersJoined(vloggersWithFollowers, vloggersWithFollowings, splitted);
            }
            else if (splitted[1] == "followed")
            {
                VloggersFollowed(vloggersWithFollowers, vloggersWithFollowings, splitted);

            }

            input = Console.ReadLine();
            return input;
        }

        private static void VloggersFollowed(Dictionary<string, HashSet<string>> vloggersWithFollowers, Dictionary<string, HashSet<string>> vloggersWithFollowings, string[] splitted)
        {
            string follower = splitted[0];
            string toBeFollowed = splitted[2];

            if (follower != toBeFollowed)
            {
                if (vloggersWithFollowers.ContainsKey(toBeFollowed) &&
                    vloggersWithFollowings.ContainsKey(follower))
                {
                    vloggersWithFollowers[toBeFollowed].Add(follower);
                    vloggersWithFollowings[follower].Add(toBeFollowed);
                }
            }
        }

        private static void VloggersJoined(Dictionary<string, HashSet<string>> vloggersWithFollowers, Dictionary<string, HashSet<string>> vloggersWithFollowings, string[] splitted)
        {
            string vloggerToJoin = splitted[0];

            if (!vloggersWithFollowers.ContainsKey(vloggerToJoin))
            {
                vloggersWithFollowers.Add(vloggerToJoin, new HashSet<string>());
                vloggersWithFollowings.Add(vloggerToJoin, new HashSet<string>());
            }
        }
    }
}

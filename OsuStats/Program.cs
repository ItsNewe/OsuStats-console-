using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu_api;
using Newtonsoft.Json;

namespace OsuStats
{
    class Program
    {
        static void Main(string[] args)
        {
            var osp = new osuAPI("APIkey");
            start:

            Console.Write("Enter the user's name: ");
            var usnm = Console.ReadLine();
            var user = osp.GetUser(usnm, Mode.osu);
            Console.WriteLine(Environment.NewLine + "Select the mode for which you want info about:"+ Environment.NewLine+"1. Osu" + Environment.NewLine + "2. Taiko" + Environment.NewLine + "3. Mania" + Environment.NewLine + "4. Catch the beat");
            var selec = Console.ReadLine();
            Console.WriteLine("Please wait while we're fetching info from Osu!..." + Environment.NewLine, Console.ForegroundColor = ConsoleColor.Yellow);
            int seleconv = Convert.ToInt32(selec);
            if (seleconv == 1)
            {
                user = osp.GetUser(usnm, Mode.osu);
            }
            else if (seleconv == 2)
            {
                user = osp.GetUser(usnm, Mode.Taiko);
            }
            else if (seleconv == 3)
            {
                user = osp.GetUser(usnm, Mode.Mania);
            }
            else if(seleconv == 4)
            {
                user = osp.GetUser(usnm, Mode.CtB);
            }
            else
            {
                Console.Write("error num");
            }
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Info for user " + user.username + Environment.NewLine);

            Console.WriteLine("User ID: " + user.user_id);
            Console.WriteLine("Level: " + user.level);
            Console.WriteLine("Country: " + user.country);
            Console.WriteLine("PP: " + user.pp_raw);
            Console.WriteLine("Rank: #" + user.pp_rank);
            Console.WriteLine("Ranked Score: " + user.ranked_score);
            Console.WriteLine("Accuracy: " + user.accuracy+"%");
            Console.WriteLine("Play Count: " + user.playcount);
            Console.Write("Ranks: " + user.count_rank_ss);
            Console.Write(" SS", Console.ForegroundColor = ConsoleColor.White);
            Console.ResetColor();
            Console.Write(", " + user.count_rank_s);
            Console.Write(" S", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ResetColor();
            Console.Write(", " + user.count_rank_a);
            Console.Write(" A", Console.ForegroundColor = ConsoleColor.Green);
            Console.ResetColor();
            Console.Write(Environment.NewLine+Environment.NewLine+"Want to give it another go? (y/n) ");
            var qa = Console.ReadLine();
            if (qa == "y")
            {
                Console.Clear();
                goto start;
            }
            else
            {
                Environment.Exit(1);
            }
        }
    }
}

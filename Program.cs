using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Xls;

namespace ConsoleApp1
{
    class Program
    {
        private static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Звірка номерів");
            Console.ForegroundColor = ConsoleColor.White;

            //Telephones tels = new Telephones();
            //tels.workT();
            Cearching sers = new Cearching();
            sers.Search();
        }
    }
    class Telephones
    {
        private readonly string patht = @"./tel.txt";
        private readonly string pathtw = @"./telw.txt";
        public string text;
        public void WorkT()
        {
            using (StreamReader sr = new StreamReader(patht, Encoding.Default))
            {
                text = sr.ReadToEnd();
                text = text.Replace("-", "");
                text = text.Replace(")", "");
                text = text.Replace("\n", "");
                text = text.Replace(" ", "");
                text = text.Replace("(", "\n");
                text = text.Replace("0988204750", "\n0988204750");
            }
            using (StreamWriter sw = new StreamWriter(pathtw, true, Encoding.Default))
            {
                sw.WriteLine(text);
            }
        }
    }
    public class Cearching
    {
        //Файл з з номерами телефону
        private readonly string pathtw = @"./telw.txt";
        //Дані по дзвінкам
        private readonly string pathV = @"./ua.txt";

        private string texttlv;
        private string Webs;
        public void Search()

        {

            using (StreamReader stl = new StreamReader(pathtw, Encoding.Default))
            {

                texttlv = stl.ReadToEnd();

            }
            using (StreamReader wstl = new StreamReader(pathV, Encoding.UTF8))
            {

                Webs = wstl.ReadToEnd();

            }
            texttlv = texttlv.Replace("\n", ",");
            texttlv = texttlv.Replace("  ", ",");
            var textarr = texttlv.Split(',');
            textarr = textarr.Distinct().ToArray();
            var indices = new List<int>();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Обробка");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var i in textarr)
            {
               
                var stres = Webs.IndexOf(i);
                while (stres > 0)
                {
                    indices.Add(stres);
                    stres = Webs.IndexOf(i, stres + i.Length);
                }
            }
            Webs = Webs.Replace('\t', ' ');
            Webs = Webs.Replace(" "," ");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Обробка закінчена");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Знайдено ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0}", indices.Count);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" співпадінь!!!");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---------------------------------'");
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            string textss ="";
            foreach ( var i in indices)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Webs.Substring(i - 23, 21));
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(Webs.Substring(i - 2, 12));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Webs.Substring(i + 10, 48));
                textss = String.Format("{0} {1} {2}",Webs.Substring(i - 23, 21),Webs.Substring(i-2, 12),Webs.Substring(i+10, 48));
                
            }
            
        }
     }
    
}

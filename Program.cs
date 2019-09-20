using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello");
            //Telephones tels = new Telephones();
            //tels.workT();
            Cearching sers = new Cearching();
            sers.search();
            Console.ReadKey();
        }
    }
    class Telephones
    {
        private string patht = @"D:\Документи_диска_С\Службові документи\Полунець\Sorcce\Phone-master\tel.txt";
        private string pathtw = @"D:\Документи_диска_С\Службові документи\Полунець\Sorcce\Phone-master\telw.txt";
        public string text;
        public void workT()
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
        private string pathtw = @"D:\Документи_диска_С\Службові документи\Полунець\Sorcce\Phone-master\telw.txt";
        //Дані по дзвінкам
        private string pathV = @"D:\Документи_диска_С\Службові документи\Полунець\Sorcce\Phone-master\Vitr1.txt";

        private string texttlv;
        private string Webs;
        public void search()

        {

            using (StreamReader stl = new StreamReader(pathtw, Encoding.Default))
            {

                texttlv = stl.ReadToEnd();

            }
            using (StreamReader wstl = new StreamReader(pathV, Encoding.Default))
            {

                Webs = wstl.ReadToEnd();

            }
            texttlv = texttlv.Replace("\n", ",");
            texttlv = texttlv.Replace("  ", ",");
            var textarr = texttlv.Split(',');
            textarr = textarr.Distinct().ToArray();
            foreach (var i in textarr)
            {
                if (Webs.Contains(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
     }        
    
}

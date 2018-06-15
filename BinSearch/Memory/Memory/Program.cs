using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw1 = new Stopwatch();
            var sw2 = new Stopwatch();
            var sw3 = new Stopwatch();
            var sw4 = new Stopwatch();
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            string text = "For shame deny that thou bear'st love to any, Who for thyself art so unprovident. Grant, if thou wilt, thou art beloved of many,But that thou none lov'st is most evident; For thou art so possess'd with murd'rous hate,That 'gainst thyself thou stick'st not to conspire, Seeking that beauteous roof to ruinateWhich to repair should be thy chief desire: O change thy thought, that I may change my mind!Shall hate be fairer lodged than gentle love? Be as thy presence is, gracious and kind,Or to thyself at least kind-hearted prove: Make thee another self, for love of me,That beauty still may live in thine or thee.";
            byte[] b = uniencoding.GetBytes(text);
            MemoryStream ms1 = new MemoryStream();
            MemoryStream ms2 = new MemoryStream();

            sw1.Start();
            ms1.Write(b, 0, b.Length);
            sw1.Stop();

            sw3.Start();
            ms1.Read(b, 0, b.Length);
            sw3.Stop();
            ms1.Close();

            string filename = "userinputlog.txt";

            sw2.Start();
            using (FileStream fs1 = File.Open(filename, FileMode.OpenOrCreate))
            {
                fs1.Seek(0, SeekOrigin.End);
                fs1.Write(b, 0, b.Length);
            }
            sw2.Stop();

            sw4.Start();
            using (FileStream fs1 = File.Open(filename, FileMode.OpenOrCreate))
            {
                fs1.Seek(0, SeekOrigin.End);
                fs1.Read(b, 0, b.Length);
            }
            sw4.Stop();

            Console.WriteLine("Text to write:");
            Console.WriteLine("\n" + text);
            Console.WriteLine("\nMemoryStream Write");
            Console.WriteLine(sw1.Elapsed.TotalMilliseconds);
            Console.WriteLine("\nFileStream Write");
            Console.WriteLine(sw2.Elapsed.TotalMilliseconds);
            Console.WriteLine("\nMemoryStream Read");
            Console.WriteLine(sw3.Elapsed.TotalMilliseconds);
            Console.WriteLine("\nFileStream Read");
            Console.WriteLine(sw4.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}

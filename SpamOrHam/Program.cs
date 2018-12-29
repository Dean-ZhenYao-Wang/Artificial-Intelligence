using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamOrHam
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\工作\资料\技术资料\人工智能\训练数据\SMSSpamCollection";
            var dataset = File.ReadAllLines(path).ToList();
            int spam = 0;
            //dataset.ForEach(i =>
            //{
            //    var tt = ParseDoc.ParseLine(i);
            //    Console.Write(tt.docType + "    ");
            //    Console.WriteLine(tt.meessage);
            //    DocType sh = PrimitiveClassifier(tt.meessage);
            //    if (sh == DocType.Spam)
            //        spam++;
            //    Console.WriteLine(sh);
            //});
            //Console.WriteLine(spam);
            //List<Doc> docs = new List<Doc>();
            //dataset.ForEach(i =>
            //{
            //    docs.Add(ParseDoc.ParseLine(i));
            //});
            //var spamWithFREE = docs
            //    .Where(m => m.docType == DocType.Spam)
            //    .Where(m => m.meessage.Contains("FREE"))
            //    .Count();
            //Console.WriteLine("val spamWithFREE : int ="+spamWithFREE);
            //var hamWithFREE = docs
            //    .Where(m => m.docType == DocType.Ham)
            //    .Where(m => m.meessage.Contains("FREE"))
            //    .Count();
            //Console.WriteLine("val hamWithFREE : int =" + hamWithFREE);
            Console.ReadKey();
        }
        private static DocType PrimitiveClassifier(string sms)
        {
            if (sms.Contains("FREE"))
                return DocType.Spam;
            else
                return DocType.Ham;
        }
    }
}

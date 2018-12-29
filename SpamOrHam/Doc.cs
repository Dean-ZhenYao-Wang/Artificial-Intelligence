using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamOrHam
{
    public enum DocType
    {
        Ham,
        Spam,
        UnknownLabel
    }
    public class ParseDoc
    {
        private static DocType ParseDocType(string label)
        {
            switch (label)
            {
                case "ham":
                    return DocType.Ham;
                case "spam":
                    return DocType.Spam;
                default:
                    return DocType.UnknownLabel;
            }
        }

        public static Doc ParseLine(string line)
        {
            var split = line.Split('\t');
            var lable = ParseDocType(split[0]);
            var message = split[1];
            return new Doc { docType = lable, meessage = message };
        }
    }

    public class Doc
    {
        public DocType docType { get; set; }
        public string meessage { get; set; }
    }
}

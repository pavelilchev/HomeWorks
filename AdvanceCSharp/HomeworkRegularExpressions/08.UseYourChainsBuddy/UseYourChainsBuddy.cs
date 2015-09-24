using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class UseYourChainsBuddy
{
    static void Main()
    {
        string input = Console.ReadLine();
       //string input = @"<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>";

        string tagPattern = @"(?<=<p>)(.*?)(?=<\/p>)";
        Regex reg = new Regex(tagPattern);
        MatchCollection matches = reg.Matches(input);
        StringBuilder sb = new StringBuilder();

        foreach (Match item in matches)
        {
            sb.Append(item);
        }

        string replacePattern = @"([^a-z0-9])";
        string result = Regex.Replace(sb.ToString(), replacePattern, " ");
        result = Regex.Replace(result, "(\\s+)", " ");
        sb.Clear();
        sb.Append(result);

        for (int i = 0; i < sb.Length; i++)
        {
            if (sb[i] >= 'a' && sb[i] <= 'm')
            {
                sb[i] = (char)(sb[i] + 13);
            }
            else if(sb[i] >= 'n' && sb[i] <= 'z')
            {
                sb[i] = (char)(sb[i] - 13);
            }
        }

        Console.WriteLine(sb);
    }
}


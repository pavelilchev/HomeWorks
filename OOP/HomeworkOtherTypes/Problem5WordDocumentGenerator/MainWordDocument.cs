
using Novacode;
using System;
using System.Diagnostics;

namespace Problem5WordDocumentGenerator
{
    class MainWordDocument
    {
        public static void Main(string[] args)
        {
            string pictureFileName = @"..\..\rpg-game.png";
            string textFileName = @"..\..\text.txt";
            string wordDocument = @"..\..\WordDocument.doc";

            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;


            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
            paraFormat.Size = 10D;

            // Create the document in memory:
            var doc = DocX.Create(wordDocument);

            // Insert the now text obejcts;
            doc.InsertParagraph(textFileName, false, headLineFormat);
            doc.InsertParagraph(wordDocument, false, paraFormat);

            // Save to the output directory:
            doc.Save();

            // Open in Word:
            Process.Start("WINWORD.EXE", wordDocument);
        }
    }
}
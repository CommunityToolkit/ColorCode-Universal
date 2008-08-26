using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using ColorCode.Common;
using XunitExt;

namespace ColorCode
{
    public class ColorizeData : DataAttribute
    {
        readonly Regex sourceFileRegex = new Regex(@"(?i)[a-z]+\.source\.([a-z]+)", RegexOptions.Compiled);
        
        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest)
        {
            List<object[]> colorizeData = new List<object[]>();
            
            string[] dirNames = Directory.GetDirectories(@"..\..\Data");

            foreach(string dirName in dirNames)
            {
                string[] sourceFileNames = Directory.GetFiles(dirName, "*.source.*");

                foreach(string sourceFileName in sourceFileNames)
                {
                    Match sourceFileMatch = sourceFileRegex.Match(sourceFileName);

                    if (sourceFileMatch.Success)
                    {
                        string fileExtension = sourceFileMatch.Groups[1].Captures[0].Value;
                        string languageId = GetLanguageId(fileExtension);
                        
                        string expectedFileName = sourceFileName.Replace(".source.", ".expected.").Replace("." + fileExtension, ".html");
                        
                        colorizeData.Add(new object[] {languageId, sourceFileName, expectedFileName});
                    }
                }
            }

            return colorizeData;
        }

        private static string GetLanguageId(string fileExtension)
        {
            switch (fileExtension)
            {
                case "ashx":
                    return LanguageId.Ashx;
                default:
                    throw new ArgumentException(string.Format("Unexpected file extension: {0}.", fileExtension));
            }
        }
    }
}
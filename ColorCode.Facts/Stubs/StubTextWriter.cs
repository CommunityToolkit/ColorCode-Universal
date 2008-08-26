using System;
using System.IO;
using System.Text;

namespace ColorCode.Stubs
{
    internal class StubTextWriter : TextWriter
    {
        public string Write__buffer = string.Empty;

        public override Encoding Encoding
        {
            get { throw new System.NotImplementedException(); }
        }

        public override void Write(string value)
        {
            Write__buffer += value;

            base.Write(value);
        }

        public override void WriteLine(string value)
        {
            Write__buffer += value + Environment.NewLine;

            base.WriteLine(value);
        }
    }
}
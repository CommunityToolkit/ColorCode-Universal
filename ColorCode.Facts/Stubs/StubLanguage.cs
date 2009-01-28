using System.Collections.Generic;
using ColorCode.Compilation;

namespace ColorCode.Stubs
{
    public class StubLanguage : ILanguage
    {
        public string id__getValue;
        public bool Name__getInvoked;
        public string name__getValue;
        public IList<LanguageRule> rules__getValue;
        public bool Rules__getInvoked;
        public bool FirstLinePattern__getInvoked;
        public string FirstLinePattern__getValue;

        public string Id
        {
            get { return id__getValue; }
        }

        public string Name
        {
            get 
            {
                Name__getInvoked = true; 
                return name__getValue; 
            }
        }

        public string FirstLinePattern
        {
            get
            {
                FirstLinePattern__getInvoked = true;
                return FirstLinePattern__getValue;
            }
        }

        public IList<LanguageRule> Rules
        {
            get 
            {
                Rules__getInvoked = true;
                return rules__getValue; 
            }
        }
    }
}
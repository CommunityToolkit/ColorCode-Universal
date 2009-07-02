using System;
using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Stubs
{
    public class StubLanguageRepository : ILanguageRepository
    {
        public Func<string, ILanguage> FindById__do;

        public IEnumerable<ILanguage> All
        {
            get { throw new System.NotImplementedException(); }
        }

        public ILanguage FindById(string languageId)
        {
            if (FindById__do != null)
                return FindById__do(languageId);
            else
                return null;
        }

        public void Load(ILanguage language)
        {
            throw new System.NotImplementedException();
        }

        public void Unload(ILanguage language)
        {
            throw new NotImplementedException();
        }

        public void Unload(string languageId)
        {
            throw new NotImplementedException();
        }
    }
}
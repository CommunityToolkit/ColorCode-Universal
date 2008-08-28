using System.Collections.Generic;
using ColorCode.Common;
using ColorCode.Compilation;
using ColorCode.Compilation.Languages;

namespace ColorCode
{
    public static class Languages
    {
        internal static Dictionary<string, CompiledLanguage> CompiledLanguages;
        internal static readonly Dictionary<string, ILanguage> LoadedLanguages;
        private static readonly LanguageRepository languageRepository;

        static Languages()
        {
            LoadedLanguages = new Dictionary<string, ILanguage>();
            CompiledLanguages = new Dictionary<string, CompiledLanguage>();
            languageRepository = new LanguageRepository(LoadedLanguages);

            languageRepository.Load(new JavaScript());
            languageRepository.Load(new Html()); 
            languageRepository.Load(new CSharp());
            languageRepository.Load(new Ashx());
            languageRepository.Load(new Aspx());
            languageRepository.Load(new Sql());
        }

        public static ILanguage Ashx
        {
            get { return languageRepository.FindById(LanguageId.Ashx); }
        }

        public static ILanguage Aspx
        {
            get { return languageRepository.FindById(LanguageId.Aspx); }
        }

        public static ILanguage CSharp
        {
            get { return languageRepository.FindById(LanguageId.CSharp); }
        }

        public static ILanguage Html
        {
            get { return languageRepository.FindById(LanguageId.Html); }
        }
        
        public static ILanguage JavaScript
        {
            get { return languageRepository.FindById(LanguageId.JavaScript); }
        }

        public static ILanguage Sql
        {
            get { return languageRepository.FindById(LanguageId.Sql); }
        }

        public static ILanguage FindById(string id)
        {
            return languageRepository.FindById(id);
        }

        public static void Load(ILanguage language)
        {
            languageRepository.Load(language);
        }
    }
}
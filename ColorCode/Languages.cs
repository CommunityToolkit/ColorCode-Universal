// Copyright (c) Microsoft Corporation.  All rights reserved.

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
            languageRepository.Load(new VbDotNet());
            languageRepository.Load(new Ashx());
            languageRepository.Load(new Asax());
            languageRepository.Load(new Aspx());
            languageRepository.Load(new AspxCs());
            languageRepository.Load(new AspxVb());
            languageRepository.Load(new Sql());
            languageRepository.Load(new Xml());
        }

        public static ILanguage Ashx
        {
            get { return languageRepository.FindById(LanguageId.Ashx); }
        }

        public static ILanguage Asax
        {
            get { return languageRepository.FindById(LanguageId.Asax); }
        }

        public static ILanguage Aspx
        {
            get { return languageRepository.FindById(LanguageId.Aspx); }
        }

        public static ILanguage AspxCs
        {
            get { return languageRepository.FindById(LanguageId.AspxCs); }
        }

        public static ILanguage AspxVb
        {
            get { return languageRepository.FindById(LanguageId.AspxVb); }
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

        public static ILanguage VbDotNet
        {
            get { return languageRepository.FindById(LanguageId.VbDotNet); }
        }

        public static ILanguage Xml
        {
            get { return languageRepository.FindById(LanguageId.Xml); }
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
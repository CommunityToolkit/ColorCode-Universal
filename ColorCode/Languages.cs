// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using ColorCode.Common;
using ColorCode.Compilation;
using ColorCode.Compilation.Languages;

namespace ColorCode
{
    public static class Languages
    {
        internal static readonly LanguageRepository LanguageRepository;
        internal static readonly Dictionary<string, ILanguage> LoadedLanguages;
        internal static Dictionary<string, CompiledLanguage> CompiledLanguages;

        static Languages()
        {
            LoadedLanguages = new Dictionary<string, ILanguage>();
            CompiledLanguages = new Dictionary<string, CompiledLanguage>();
            LanguageRepository = new LanguageRepository(LoadedLanguages);

            Load<JavaScript>();
            Load<Html>();
            Load<CSharp>();
            Load<VbDotNet>();
            Load<Ashx>();
            Load<Asax>();
            Load<Aspx>();
            Load<AspxCs>();
            Load<AspxVb>();
            Load<Sql>();
            Load<Xml>();
            Load<Php>();
            Load<Css>();
        }

        public static ILanguage Ashx
        {
            get { return LanguageRepository.FindById(LanguageId.Ashx); }
        }

        public static ILanguage Asax
        {
            get { return LanguageRepository.FindById(LanguageId.Asax); }
        }

        public static ILanguage Aspx
        {
            get { return LanguageRepository.FindById(LanguageId.Aspx); }
        }

        public static ILanguage AspxCs
        {
            get { return LanguageRepository.FindById(LanguageId.AspxCs); }
        }

        public static ILanguage AspxVb
        {
            get { return LanguageRepository.FindById(LanguageId.AspxVb); }
        }

        public static ILanguage CSharp
        {
            get { return LanguageRepository.FindById(LanguageId.CSharp); }
        }

        public static ILanguage Html
        {
            get { return LanguageRepository.FindById(LanguageId.Html); }
        }

        public static ILanguage JavaScript
        {
            get { return LanguageRepository.FindById(LanguageId.JavaScript); }
        }

        public static ILanguage Sql
        {
            get { return LanguageRepository.FindById(LanguageId.Sql); }
        }

        public static ILanguage VbDotNet
        {
            get { return LanguageRepository.FindById(LanguageId.VbDotNet); }
        }

        public static ILanguage Xml
        {
            get { return LanguageRepository.FindById(LanguageId.Xml); }
        }

        public static ILanguage Php
        {
            get { return LanguageRepository.FindById(LanguageId.Php); }
        }

        public static ILanguage Css
        {
            get { return LanguageRepository.FindById(LanguageId.Css); }
        }

        public static ILanguage FindById(string id)
        {
            return LanguageRepository.FindById(id);
        }

        public static void Load<T>()
            where T : ILanguage, new()
        {
            Load(new T());
        }

        public static void Load(ILanguage language)
        {
            LanguageRepository.Load(language);
        }

        public static void Unload<T>()
            where T : ILanguage, new()
        {
            Unload(new T());
        }

        public static void Unload(ILanguage language)
        {
            LanguageRepository.Unload(language.Id);
        }

        public static void Unload(string languageId)
        {
            LanguageRepository.Unload(languageId);
        }
    }
}
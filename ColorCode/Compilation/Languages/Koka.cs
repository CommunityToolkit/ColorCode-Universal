// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
  public class Koka : ILanguage
  {
    public string Id
    {
      get { return LanguageId.Koka; }
    }

    public string Name
    {
      get { return "Koka"; }
    }

    public string CssClassName
    {
      get { return "koka"; }
    }

    public string FirstLinePattern
    {
      get
      {
        return null;
      }
    }

    public IList<LanguageRule> Rules
    {
      get
      {
        return new List<LanguageRule> {
            new LanguageRule(
              // Handle nested block comments using named balanced groups
              @"/\*([^*/]+|/+[^*/]|\*+[^*/])*" +
              @"(" +
              @"((?<comment>/\*)([^*/]+|/+[^*/]|\*+[^*/])*)+" +
              @"((?<-comment>\*/)([^*/]+|/+[^*/]|\*+[^*/])*)+" +
              @")*" +
              @"(\*+/)",
              new Dictionary<int, string>
                  {
                      { 0, ScopeName.Comment },
                  }),
            new LanguageRule(
                @"\b(infix|infixr|infixl|type|cotype|rectype|struct|alias|forall|exists|some|interface|instance|with|external|fun|function|val|var|con|if|then|else|elif|match|return|module|import|as|public|private|abstract|yield)\b",
                new Dictionary<int, string>
                    {
                        { 1, ScopeName.Keyword }
                    }),
            new LanguageRule(
                @"(//.*?)\r?$",
                new Dictionary<int, string>
                    {
                        { 1, ScopeName.Comment }
                    }),
            new LanguageRule(
                @"'[^\n]*?(?<!\\)'",
                new Dictionary<int, string>
                    {
                        { 0, ScopeName.String }
                    }),
            new LanguageRule(
                @"(?s)@""(?:""""|.)*?""(?!"")",
                new Dictionary<int, string>
                    {
                        { 0, ScopeName.StringCSharpVerbatim }
                    }),
            new LanguageRule(
                @"(?s)(""[^\n]*?(?<!\\)"")",
                new Dictionary<int, string>
                    {
                        { 0, ScopeName.String }
                    }),
            new LanguageRule(
                @"^\s*(\#error|\#line|\#pragma|\#warning|\#!/usr/bin/env\s+koka|\#).*?$",
                new Dictionary<int, string>
                    {
                        { 1, ScopeName.PreprocessorKeyword }
                    }),
        };
      }
    }

    public bool HasAlias(string lang)
    {
      switch (lang.ToLower()) {
        case "kk":
        case "kki":
          return true;

        default:
          return false;
      }
    }

    public override string ToString()
    {
      return Name;
    }
  }
}

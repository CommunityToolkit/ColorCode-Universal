using System;
using System.Collections.Generic;
using ColorCode.Stubs;
using Xunit;

namespace ColorCode.Common
{
    public class LanguageRepositoryFacts
    {
        public class The_Load_method
        {
            [Fact]
            public void Will_add_the_language_to_the_loaded_languages()
            {
                Dictionary<string, ILanguage> stubLoadedLanguages = new Dictionary<string, ILanguage>();
                LanguageRepository languageRepository = new LanguageRepository(stubLoadedLanguages);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = "fnord";

                languageRepository.Load(stubLanguage);

                Assert.Contains(stubLanguage, stubLoadedLanguages.Values);
            }

            [Fact]
            public void Will_replace_an_existing_language_with_same_identifier()
            {
                Dictionary<string, ILanguage> loadedLanguages = new Dictionary<string, ILanguage>();
                LanguageRepository languageRepository = new LanguageRepository(loadedLanguages);
                StubLanguage language1 = new StubLanguage();
                language1.id__getValue = "fnord";
                StubLanguage language2 = new StubLanguage();
                language2.id__getValue = "fnord";
                languageRepository.Load(language1);

                languageRepository.Load(language2);

                Assert.DoesNotContain(language1, loadedLanguages.Values);
                Assert.Contains(language2, loadedLanguages.Values);
            }

            [Fact]
            public void Will_add_a_second_language_to_the_loaded_languages()
            {
                Dictionary<string, ILanguage> loadedLanguages = new Dictionary<string, ILanguage>();
                LanguageRepository languageRepository = new LanguageRepository(loadedLanguages);
                StubLanguage language1 = new StubLanguage();
                language1.id__getValue = "fnord";
                StubLanguage language2 = new StubLanguage();
                language2.id__getValue = "not fnord";

                languageRepository.Load(language1);
                languageRepository.Load(language2);

                Assert.Contains(language1, loadedLanguages.Values);
                Assert.Contains(language2, loadedLanguages.Values);
            }

            [Fact]
            public void Will_throw_when_the_language_is_null()
            {
                LanguageRepository languageRepository = new LanguageRepository(new Dictionary<string, ILanguage>());

                Exception ex = Record.Exception(() => languageRepository.Load(null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("language", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void Will_throw_when_the_language_identifier_is_null()
            {
                LanguageRepository languageRepository = new LanguageRepository(new Dictionary<string, ILanguage>());
                StubLanguage language = new StubLanguage();
                language.id__getValue = null;

                Exception ex = Record.Exception(() => languageRepository.Load(language));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The language identifier must not be null or empty.", ex.Message);
                Assert.Equal("language", ((ArgumentException)ex).ParamName);
            }

            [Fact]
            public void Will_throw_when__the_language_identifier_is_empty()
            {
                LanguageRepository languageRepository = new LanguageRepository(new Dictionary<string, ILanguage>());
                StubLanguage language = new StubLanguage();
                language.id__getValue = string.Empty;

                Exception ex = Record.Exception(() => languageRepository.Load(language));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The language identifier must not be null or empty.", ex.Message);
                Assert.Equal("language", ((ArgumentException)ex).ParamName);
            }
        } 

        public class The_FindById_method
        {
            [Fact]
            public void Will_find_a_loaded_language_with_a_matching_identfier()
            {
                StubLanguage expected = new StubLanguage();
                expected.id__getValue = "fnord";
                Dictionary<string, ILanguage> loadedLanguages = new Dictionary<string, ILanguage>();
                loadedLanguages.Add(expected.Id, expected);
                LanguageRepository languageRepository = new LanguageRepository(loadedLanguages);

                ILanguage actual = languageRepository.FindById(expected.Id);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void Will_return_null_if_no_loaded_languages_match_the_language_identifier()
            {
                LanguageRepository languageRepository = new LanguageRepository(new Dictionary<string, ILanguage>());

                ILanguage actual = languageRepository.FindById("fnord");

                Assert.Null(actual);
            }

            [Fact]
            public void Will_throw_when_the_language_identifier_is_null()
            {
                LanguageRepository languageRepository = new LanguageRepository(new Dictionary<string, ILanguage>());

                Exception ex = Record.Exception(() => languageRepository.FindById(null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("languageId", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void Will_throw_when_the_language_identifier_is_empty()
            {
                LanguageRepository languageRepository = new LanguageRepository(new Dictionary<string, ILanguage>());

                Exception ex = Record.Exception(() => languageRepository.FindById(string.Empty));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The languageId argument value must not be empty.", ex.Message);
                Assert.Equal("languageId", ((ArgumentException)ex).ParamName);
            }
        }

        public class The_All_property
        {
            [Fact]
            public void Will_return_all_loaded_languages()
            {
                StubLanguage language1 = new StubLanguage();
                language1.id__getValue = "fnord";
                StubLanguage language2 = new StubLanguage();
                language2.id__getValue = "not fnord";
                Dictionary<string, ILanguage> loadedLanguages = new Dictionary<string, ILanguage>();
                loadedLanguages.Add(language1.Id, language1);
                loadedLanguages.Add(language2.Id, language2);
                LanguageRepository languageRepository = new LanguageRepository(loadedLanguages);

                IEnumerable<ILanguage> all = languageRepository.All;

                Assert.Contains(language1, all);
                Assert.Contains(language2, all);
            }
        }
    }
}

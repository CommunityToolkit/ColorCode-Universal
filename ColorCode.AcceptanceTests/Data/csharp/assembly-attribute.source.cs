using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyTitle("Fnord")]
[assembly: AssemblyVersion("1.0.2000.0")]
[assembly: InternalsVisibleTo("Foo", AllInternalsVisible = true)]
[assembly: Foo("abc", "cde")]
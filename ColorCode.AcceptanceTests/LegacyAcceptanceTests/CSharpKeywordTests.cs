using Xunit;

namespace ColorCode.CSharpAcceptanceTests
{
    public class CSharpKeywordTests
    {
        public class Transform
        {
            [Fact]
            public void WillStyleKnownKeywords()
            {
                string sourceText =
@"#define
#elif
#else
#endif
#endregion
#error
#if
#line
#pragma
#region
#undef
#warning
abstract
as
base
bool
break
byte
case
catch
char
checked
const
continue
decimal
default
delegate
do
double
else
enum
event
explicit
extern
false
finally
fixed
float
for
foreach
goto
if
implicit
in
int
interface
internal
is
lock
long
namespace
new
null
object
operator
out
override
params
partial
private
protected
public
readonly
ref
return
sbyte
sealed
short
sizeof
stackalloc
static
string
struct
switch
this
throw
true
try
typeof
uint
ulong
unchecked
unsafe
ushort
using
virtual
void
volatile
while";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">#define</span>
<span style=""color:Blue;"">#elif</span>
<span style=""color:Blue;"">#else</span>
<span style=""color:Blue;"">#endif</span>
<span style=""color:Blue;"">#endregion</span>
<span style=""color:Blue;"">#error</span>
<span style=""color:Blue;"">#if</span>
<span style=""color:Blue;"">#line</span>
<span style=""color:Blue;"">#pragma</span>
<span style=""color:Blue;"">#region</span>
<span style=""color:Blue;"">#undef</span>
<span style=""color:Blue;"">#warning</span>
<span style=""color:Blue;"">abstract</span>
<span style=""color:Blue;"">as</span>
<span style=""color:Blue;"">base</span>
<span style=""color:Blue;"">bool</span>
<span style=""color:Blue;"">break</span>
<span style=""color:Blue;"">byte</span>
<span style=""color:Blue;"">case</span>
<span style=""color:Blue;"">catch</span>
<span style=""color:Blue;"">char</span>
<span style=""color:Blue;"">checked</span>
<span style=""color:Blue;"">const</span>
<span style=""color:Blue;"">continue</span>
<span style=""color:Blue;"">decimal</span>
<span style=""color:Blue;"">default</span>
<span style=""color:Blue;"">delegate</span>
<span style=""color:Blue;"">do</span>
<span style=""color:Blue;"">double</span>
<span style=""color:Blue;"">else</span>
<span style=""color:Blue;"">enum</span>
<span style=""color:Blue;"">event</span>
<span style=""color:Blue;"">explicit</span>
<span style=""color:Blue;"">extern</span>
<span style=""color:Blue;"">false</span>
<span style=""color:Blue;"">finally</span>
<span style=""color:Blue;"">fixed</span>
<span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">for</span>
<span style=""color:Blue;"">foreach</span>
<span style=""color:Blue;"">goto</span>
<span style=""color:Blue;"">if</span>
<span style=""color:Blue;"">implicit</span>
<span style=""color:Blue;"">in</span>
<span style=""color:Blue;"">int</span>
<span style=""color:Blue;"">interface</span>
<span style=""color:Blue;"">internal</span>
<span style=""color:Blue;"">is</span>
<span style=""color:Blue;"">lock</span>
<span style=""color:Blue;"">long</span>
<span style=""color:Blue;"">namespace</span>
<span style=""color:Blue;"">new</span>
<span style=""color:Blue;"">null</span>
<span style=""color:Blue;"">object</span>
<span style=""color:Blue;"">operator</span>
<span style=""color:Blue;"">out</span>
<span style=""color:Blue;"">override</span>
<span style=""color:Blue;"">params</span>
<span style=""color:Blue;"">partial</span>
<span style=""color:Blue;"">private</span>
<span style=""color:Blue;"">protected</span>
<span style=""color:Blue;"">public</span>
<span style=""color:Blue;"">readonly</span>
<span style=""color:Blue;"">ref</span>
<span style=""color:Blue;"">return</span>
<span style=""color:Blue;"">sbyte</span>
<span style=""color:Blue;"">sealed</span>
<span style=""color:Blue;"">short</span>
<span style=""color:Blue;"">sizeof</span>
<span style=""color:Blue;"">stackalloc</span>
<span style=""color:Blue;"">static</span>
<span style=""color:Blue;"">string</span>
<span style=""color:Blue;"">struct</span>
<span style=""color:Blue;"">switch</span>
<span style=""color:Blue;"">this</span>
<span style=""color:Blue;"">throw</span>
<span style=""color:Blue;"">true</span>
<span style=""color:Blue;"">try</span>
<span style=""color:Blue;"">typeof</span>
<span style=""color:Blue;"">uint</span>
<span style=""color:Blue;"">ulong</span>
<span style=""color:Blue;"">unchecked</span>
<span style=""color:Blue;"">unsafe</span>
<span style=""color:Blue;"">ushort</span>
<span style=""color:Blue;"">using</span>
<span style=""color:Blue;"">virtual</span>
<span style=""color:Blue;"">void</span>
<span style=""color:Blue;"">volatile</span>
<span style=""color:Blue;"">while</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleKnownAttributeTargets()
            {
                string source =
    @"[assembly: SomeAttribute]
[module: SomeAttribute]
[type: SomeAttribute]
[return: SomeAttribute]
[param: SomeAttribute]
[method: SomeAttribute]
[field: SomeAttribute]
[property: SomeAttribute]
[event: SomeAttribute]";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
[<span style=""color:Blue;"">assembly</span>: SomeAttribute]
[<span style=""color:Blue;"">module</span>: SomeAttribute]
[<span style=""color:Blue;"">type</span>: SomeAttribute]
[<span style=""color:Blue;"">return</span>: SomeAttribute]
[<span style=""color:Blue;"">param</span>: SomeAttribute]
[<span style=""color:Blue;"">method</span>: SomeAttribute]
[<span style=""color:Blue;"">field</span>: SomeAttribute]
[<span style=""color:Blue;"">property</span>: SomeAttribute]
[<span style=""color:Blue;"">event</span>: SomeAttribute]
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }
        }
    }
}

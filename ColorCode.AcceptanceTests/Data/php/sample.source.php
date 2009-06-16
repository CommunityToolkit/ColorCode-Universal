/*
more
than
one
line
comment
*/

// single line comment

# a different single line comment

$foo = 'a string'

$foo2 = "a string"

//$foo = 'a string'

//$foo2 = "a string"

$foo3 = "a string" // a comment

/* Incorrect Method: */
if($a > $b):
    echo $a." is greater than ".$b;
else if($a == $b): // Will not compile.
    echo "The above line causes a parse error.";
endif;

/* Correct Method: */
if($a > $b):
    echo $a." is greater than ".$b;
elseif($a == $b): // Note the combination of the words.
    echo $a." equals ".$b;
else:
    echo $a." is neither greater than or equal to ".$b;
endif;

<?php
$file = fopen("welcome.txt", "r") or exit("Unable to open file!");
//Output a line of the file until the end is reached

/* single line comment */

echo "<table width=\"175\" border=\"1\" class=\"Table1\">\n";
$regex = '/(?:(")|(?:\'))((?(1)[^"]+|[^\']+))(?(1)"|\')/';

while(!feof($file))
 {
 echo fgets($file). "<br />";
/* single line comment */
 }
           /*multi line style
            * Second line
            * third line
            * fourth line
           */
fclose($file);
mysqli_fetch_object())
and
__LINE__ 
class 
die() 
empty() 
endswitch 
for 
include() 
print() 
switch 
__FUNCTION__ 
interface
protected
throw
or 
array() 
const 
do 
enddeclare 
endwhile 
foreach 
include_once() 
require() 
unset() 
__CLASS__ 
implements
abstract
cfunction
namespace
xor 
as 
continue 
echo() 
endfor 
eval() 
function 
isset() 
require_once() 
use 
__METHOD__ 
clone
old_function
goto
__FILE__ 
break 
declare 
else 
endforeach 
exit() 
global 
list() 
return() 
var 
final
public
try
this
exception
case 
default 
elseif 
endif 
extends 
if 
new 
static 
while 
php_user_filter
private
catch
final
?> 

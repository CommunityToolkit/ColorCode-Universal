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
?> 

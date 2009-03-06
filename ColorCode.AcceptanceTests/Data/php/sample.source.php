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

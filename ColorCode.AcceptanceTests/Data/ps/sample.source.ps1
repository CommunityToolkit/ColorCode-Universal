################################################################################ 
# Set-ClipboardScript.ps1 
# 
# The script entire contents of the currently selected editor window to system 
# clipboard. The copied data can be pasted into any application that supports 
# pasting in UnicodeText, RTF or HTML format. Text pasted in RTF or HTML 
# format will be colorized. 
# 
# See also: 
# http://blogs.msdn.com/powershell/archive/2009/01/13/ 
# how-to-copy-colorized-script-from-powershell-ise.aspx 
# http://www.leeholmes.com/blog/SyntaxHighlightingInPowerShell.aspx 
# http://www.leeholmes.com/blog/RealtimeSyntaxHighlightingInYourPowerShellConsole.aspx 
# 
################################################################################ 

[CmdletBinding()] 
param($path) 

function Get-ScriptName 
{ 
    $myInvocation.ScriptName 
} 

if($path -and ([Threading.Thread]::CurrentThread.ApartmentState -ne "STA")) 
{ 
    PowerShell -NoProfile -STA -File (Get-ScriptName) $path 
    return 
} 

$tokenColours = @{ 
    'Attribute' = '#FFADD8E6' 
    'Command' = '#FF0000FF' 
    'CommandArgument' = '#FF8A2BE2' 
    'CommandParameter' = '#FF000080' 
    'Comment' = '#FF006400' 
    'GroupEnd' = '#FF000000' 
    'GroupStart' = '#FF000000' 
    'Keyword' = '#FF00008B' 
    'LineContinuation' = '#FF000000' 
    'LoopLabel' = '#FF00008B' 
    'Member' = '#FF000000' 
    'NewLine' = '#FF000000' 
    'Number' = '#FF800080' 
    'Operator' = '#FFA9A9A9' 
    'Position' = '#FF000000' 
    'StatementSeparator' = '#FF000000' 
    'String' = '#FF8B0000' 
    'Type' = '#FF008080' 
    'Unknown' = '#FF000000' 
    'Variable' = '#FFFF4500' 
} 

if($psise) 
{ 
    $tokenColours = $psise.Options.TokenColors 
} 

Add-Type -Assembly System.Web 
Add-Type -Assembly PresentationCore 

# Create RTF block from text using named console colors. 
function Append-RtfBlock ($block, $tokenColor) 
{ 
    $colorIndex = $rtfColorMap.$tokenColor 
    $block = $block.Replace('\','\\').Replace("`r`n","\cf1\par`r`n") 
    $block = $block.Replace("`t",'\tab').Replace('{','\{').Replace('}','\}') 
    $null = $rtfBuilder.Append("\cf$colorIndex $block") 
} 

# Generate an HTML span and append it to HTML string builder 
$currentLine = 1 
function Append-HtmlSpan ($block, $tokenColor) 
{ 
    if (($tokenColor -eq 'NewLine') -or ($tokenColor -eq 'LineContinuation')) 
    { 
        if($tokenColor -eq 'LineContinuation') 
        { 
            $null = $codeBuilder.Append('`') 
        } 
        
        $null = $codeBuilder.Append("<br />`r`n") 
        $null = $lineBuilder.Append("{0:000}<BR />" -f $currentLine) 
        $SCRIPT:currentLine++ 
    } 
    else 
    { 
        $block = [System.Web.HttpUtility]::HtmlEncode($block) 
        if (-not $block.Trim()) 
        { 
            $block = $block.Replace(' ', '&nbsp;') 
        } 

        $htmlColor = $tokenColours[$tokenColor].ToString().Replace('#FF', '#') 

        if($tokenColor -eq 'String') 
        { 
            $lines = $block -split "`r`n" 
            $block = "" 

            $multipleLines = $false 
            foreach($line in $lines) 
            { 
                if($multipleLines) 
                { 
                    $block += "<BR />`r`n" 
                    
                    $null = $lineBuilder.Append("{0:000}<BR />" -f $currentLine) 
                    $SCRIPT:currentLine++ 
                } 

                $newText = $line.TrimStart() 
                $newText = "&nbsp;" * ($line.Length - $newText.Length) +  
                    $newText 
                $block += $newText 
                $multipleLines = $true 
            } 
        } 
    
        $null = $codeBuilder.Append( 
            "<span style='color:$htmlColor'>$block</span>") 
    } 
} 

function GetHtmlClipboardFormat($html) 
{ 
    $header = @" 
Version:1.0 
StartHTML:0000000000 
EndHTML:0000000000 
StartFragment:0000000000 
EndFragment:0000000000 
StartSelection:0000000000 
EndSelection:0000000000 
SourceURL:file:///about:blank 
<!DOCTYPE HTML PUBLIC `"-//W3C//DTD HTML 4.0 Transitional//EN`"> 
<HTML> 
<HEAD> 
<TITLE>HTML Clipboard</TITLE> 
</HEAD> 
<BODY> 
<!--StartFragment--> 
<DIV style='font-family:Consolas,Lucida Console; font-size:10pt; 
    width:750; border:1px solid black; overflow:auto; padding:5px'> 
<TABLE BORDER='0' cellpadding='5' cellspacing='0'> 
<TBODY> 
<TR> 
    <TD VALIGN='Top'> 
<DIV style='font-family:Consolas,Lucida Console; font-size:10pt; 
    padding:5px; background:#cecece'> 
__LINES__ 
</DIV> 
    </TD> 
    <TD VALIGN='Top' NOWRAP='NOWRAP'> 
<DIV style='font-family:Consolas,Lucida Console; font-size:10pt; 
    padding:5px; background:#fcfcfc'> 
__HTML__ 
</DIV> 
    </TD> 
</TR> 
</TBODY> 
</TABLE> 
</DIV> 
<!--EndFragment--> 
</BODY> 
</HTML> 
"@ 

    $header = $header.Replace("__LINES__", $lineBuilder.ToString()) 
    $startFragment = $header.IndexOf("<!--StartFragment-->") + 
        "<!--StartFragment-->".Length + 2 
    $endFragment = $header.IndexOf("<!--EndFragment-->") + 
        $html.Length - "__HTML__".Length 
    $startHtml = $header.IndexOf("<!DOCTYPE") 
    $endHtml = $header.Length + $html.Length - "__HTML__".Length 
    $header = $header -replace "StartHTML:0000000000", 
        ("StartHTML:{0:0000000000}" -f $startHtml) 
    $header = $header -replace "EndHTML:0000000000", 
        ("EndHTML:{0:0000000000}" -f $endHtml) 
    $header = $header -replace "StartFragment:0000000000", 
        ("StartFragment:{0:0000000000}" -f $startFragment) 
    $header = $header -replace "EndFragment:0000000000", 
        ("EndFragment:{0:0000000000}" -f $endFragment) 
    $header = $header -replace "StartSelection:0000000000", 
        ("StartSelection:{0:0000000000}" -f $startFragment) 
    $header = $header -replace "EndSelection:0000000000", 
        ("EndSelection:{0:0000000000}" -f $endFragment) 
    $header = $header.Replace("__HTML__", $html) 
    
    Write-Verbose $header 
    $header 
} 

function Main 
{ 
    $text = $null 
    
    if($path) 
    { 
        $text = (Get-Content $path) -join "`r`n" 
    } 
    else 
    { 
        if (-not $psise.CurrentOpenedFile) 
        { 
            Write-Error 'No script is available for copying.' 
            return 
        } 
        
        $text = $psise.CurrentOpenedFile.Editor.Text 
    } 

    trap { break } 

    # Do syntax parsing. 
    $errors = $null 
    $tokens = [system.management.automation.psparser]::Tokenize($Text, 
        [ref] $errors) 

    # Initialize HTML builder. 
    $codeBuilder = new-object system.text.stringbuilder 
    $lineBuilder = new-object system.text.stringbuilder 
    $null = $lineBuilder.Append("{0:000}<BR />" -f $currentLine) 
    $SCRIPT:currentLine++ 
   

    # Initialize RTF builder. 
    $rtfBuilder = new-object system.text.stringbuilder 
    
    # Append RTF header 
    $header = "{\rtf1\fbidis\ansi\ansicpg1252\deff0\deflang1033{\fonttbl" + 
        "{\f0\fnil\fcharset0 $fontName;}}" 
    $null = $rtfBuilder.Append($header) 
    $null = $rtfBuilder.Append("`r`n") 

    # Append RTF color table which will contain all Powershell console colors. 
    $null = $rtfBuilder.Append("{\colortbl ;") 
    
    # Generate RTF color definitions for each token type. 
    $rtfColorIndex = 1 
    $rtfColors = @{} 
    $rtfColorMap = @{} 
    
    [Enum]::GetNames([System.Management.Automation.PSTokenType]) | % { 
        $tokenColor = $tokenColours[$_]; 
        $rtfColor = "\red$($tokenColor.R)\green$($tokenColor.G)\blue" + 
            "$($tokenColor.B);" 
        if ($rtfColors.Keys -notcontains $rtfColor) 
        { 
            $rtfColors.$rtfColor = $rtfColorIndex 
            $null = $rtfBuilder.Append($rtfColor) 
            $rtfColorMap.$_ = $rtfColorIndex 
            $rtfColorIndex ++ 
        } 
        else 
        { 
            $rtfColorMap.$_ = $rtfColors.$rtfColor 
        } 
    } 
    
    $null = $rtfBuilder.Append('}') 
    $null = $rtfBuilder.Append("`r`n") 
    
    # Append RTF document settings. 
    $null = $rtfBuilder.Append('\viewkind4\uc1\pard\f0\fs20 ') 
    
    # Iterate over the tokens and set the colors appropriately. 
    $position = 0 
    foreach ($token in $tokens) 
    { 
        if ($position -lt $token.Start) 
        { 
            $block = $text.Substring($position, ($token.Start - $position)) 
            $tokenColor = 'Unknown' 
            Append-RtfBlock $block $tokenColor 
            Append-HtmlSpan $block $tokenColor 
        } 
        
        $block = $text.Substring($token.Start, $token.Length) 
        $tokenColor = $token.Type.ToString() 
        Append-RtfBlock $block $tokenColor 
        Append-HtmlSpan $block $tokenColor 
        
        $position = $token.Start + $token.Length 
    } 

    # Append RTF ending brace. 
    $null = $rtfBuilder.Append('}') 
    
    # Copy console screen buffer contents to clipboard in three formats - 
    # text, HTML and RTF. 
    $dataObject = New-Object Windows.DataObject 
    $dataObject.SetText([string]$text, [Windows.TextDataFormat]"UnicodeText") 
    $rtf = $rtfBuilder.ToString() 
    $dataObject.SetText([string]$rtf, [Windows.TextDataFormat]"Rtf") 
    $code = $codeBuilder.ToString() 
    $html = GetHtmlClipboardFormat($code) 
    
    $dataObject.SetText([string]$html, [Windows.TextDataFormat]"Html") 

    [Windows.Clipboard]::SetDataObject($dataObject, $true) 
} 

. Main
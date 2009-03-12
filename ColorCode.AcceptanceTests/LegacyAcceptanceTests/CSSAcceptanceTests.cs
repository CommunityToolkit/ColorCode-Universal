using Xunit;

namespace ColorCode.LegacyAcceptanceTests
{
    public class CSSAcceptanceTests
    {
        [Fact]
        public void TransformWillCommentMultipleCommentsCorrectly()
        {
            string source =
@"<style type=""text/css"">
    /* C style */
    /*
multi
line
    */
    .red_text { color: #FF0000 } /* Comments can also be placed along side CSS statements */
    // ignore single line
</style>";
            string expected =
                "<div style=\"color:Black;background-color:White;\"><pre>\r\n&lt;style type=&quot;text/css&quot;&gt;<span style=\"color:Green;\">\r\n    /* C style */</span><span style=\"color:Green;\">\r\n    /*\r\nmulti\r\nline\r\n    */</span>\r\n<span style=\"color:#A31515;\">    .red_text </span>{ <span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#FF0000 </span>}<span style=\"color:Green;\"> /* Comments can also be placed along side CSS statements */</span>\r\n    // ignore single line\r\n&lt;/style&gt;\r\n</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Css);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformSample()
        {
            string source =
@"body {
	color: #080808;
	font-family: Verdana;
	font-size: 62.5%;
	margin-right: 20px;
	margin-top: 4px;
	margin-left: 20px;
	
}

.AutoCompletePanel
{
	z-index:1000;
}


.MSMarginBottom
{
	margin-bottom:2em;	
	width: 30em;
}

.UpdateProgress
{
	background-color: #CDDFF2;
	color: #000000;
	font-weight:bold;
}

#WikiVersions th
{
	background-color:#ECECEC;
}

.Grid .Header 
{
	background-color:#ECECEC;
}

ul
{
	list-style-image:none;
}
li
{
	padding-top:.5em;
}

.IE7 .workItemDetails .leftCell,
.IE6 .workItemDetails .leftCell
{
	width:8em;
}

.IE7 .workItemDetails .rightCell
{
	padding-left: 0.4em;
}

.IE7 .workItemDetails .rightCellEditable 
{
	padding-left: 0.4em;
}

.IE6 .workItemDetails .smartDate
{
	display:block;
	width:9em;
}

.SideBar .ContentPanel .HeaderPanel
{
	padding:0px;
}

.PageStep
{
	padding-bottom:1em;
}

.Header h1, h1.Header, .Header h2, h2.Header, h3.Header, Header h3, .CodePlexPageHeader
{
	color: #000000;
}

.SignInPanel .RoundedContent, .SignInPanel .RoundedBorder
{
	background: none;
}


.TabLink
{
	padding-top:2px;
}


.SiteContent
{
	margin: 0;
	padding-top: 1em;
	padding-left:1em;
	padding-right:1em;
}

.CanvasContent .SiteHeader
{
	color: black;
	padding-top: 0.3em;
	padding-bottom:10px;
	
	padding-left:1em;
	padding-right:1em;
	width:98%;
}



.GlobalBar h4
{
	margin: 0;
	padding: 0;
}


.BulletLink
{
	background-image:none;
	padding:0px;
	margin:0px;
}

/*MSDNAboutPanel Styles */
.MSDNAboutPanel
{
	margin-right:1em;
}

.MSDNAboutPanel h2
{
	font-size:1.3em;
}

#TitleSearchHeader
{
	width:100%;
	padding-bottom:3em;
}

.IE6 #TitleSearchHeader, .IE7 #TitleSearchHeader
{
	padding-bottom:1em;
}

#TitleSearchHeader .TitleHeader
{
	float:left;
}

#TitleSearchHeader .ProjectSearchBox
{
	float:right;
}


.MSDNSearch
{
	float:right;
}

.ProjectSearchPanel
{
	float:none;
	margin-left:13px;
	margin-right:15px;
}

* html .ProjectSearchPanel {
	margin-right: 6px;
}

.TagMSDNCellBody
{
	border:solid 1px #000000;
	xbackground-color: #AA2520;
	background-image:url(/images/tag_bg.jpg);
}

.TagMSDNBody 
{
	padding: 0.3em;
	font-size: 1.3em;
}


.TagMSDNBody a:link, .TagMSDNBody a:visited
{
	color: White;
}

.TagMSDNBody a:hover
{
	color:#FF6600;
}


/*TagColor Styles */
.TagMSDNHeader 
{
	background-color: #3B3E3F;
	color: White;
	font-weight: bold;
	padding: 0.2em;
	font-size: 1.3em;
}

.TagMSDNHeader a:link, .TagMSDNHeader a:visited 
{
	color: White;
}




.RightSideBar .TagMSDNCellBody
{
	margin-top:1em;
}
.RightSideBar .TagMSDNBody,
.RightSideBar .TagMSDNHeader
{
	font-size:.9em;
}

/*AboutMSDNSubPanel Styles*/
.MSDNAboutSubPanel
{
	overflow:hidden;
	padding:1em;
}

.MSDNAboutSubPanelImage
{
	float: left;
	padding-right: 0.1em;
}
	
.ContentPanel .RoundedContent .MSDNAboutSubPanel .Header
{	
    color:#FFFFFF;
    padding-top:.4em;
    margin:0px;
	padding-bottom:.4em;
	position: relative;
}

.ContentPanel .MSDNAboutSubPanel .Content
{	
	padding:.5em;
	height:6em; 
}

.ContentPanel .MSDNAboutSubPanel .RoundedContent 
{
	background-color: Transparent;
}


/* Content Panel overrides */
.ContentPanel  .HeaderPanel{
    padding:/*{css:StandardPadding}*/;
    background-image: none;
    background-color:Transparent;
    position:relative;
}

.ContentPanel  .RoundedContent .FooterPanel{
    padding:/*{css:StandardPadding}*/;
    background-image: none;
    background-color:Transparent;
    position:relative;
}

.ContentPanel .RoundedContent, 
.AlternateBackgroundPanel .RoundedContent,
.AlternateBackgroundPanel .RoundedBorder,
.ContentPanel .TopBorder {
    background-image: none;
    background-repeat:repeat-x;
    background-color:#fff;
}

.ContentPanel .TopBorder
{
	background-image:url(../Images/contentpanel_gradientbg.gif);
}


.ContentPanel .RoundedContentContainer .BottomBorder,
.ContentPanel .RoundedContent .HeaderPanel
{
	background-color: Transparent;
	
}


.ContentPanel .RoundedContent
{
	background-image:url(../Images/contentpanel_gradientbg.gif);

}



.TabPanel .RoundedBorder, .TabPanel .RoundedContent {
	background-color:#FFFFFF;
	background-image:none;
	background-repeat:repeat-x;
	text-align:center;
	width:auto;
}
 .TabPanel .RoundedContent {
	background-image:url(../images/button_gradient.gif);
	background-position:left bottom !important;
	background-repeat:repeat-x;
	min-height:1px;
}

 .ActiveTab .RoundedBorder, .ActiveTab .RoundedContent {
	background-color:#FFFFFF;
	background-image:none;
}



.ResultListPanel .GridHeader
{
	background-color: #959595
}
.ResultListPanel .GridHeader .SecondaryText
{
	color:White;
}

.InlineBox
{
	display:inline;
}

/* MSDN Header CSS */

.GlobalBar a, .GlobalBar a:Link, .GlobalBar a:Visited
{
	color: #080808;
	text-decoration: none;
}

.GlobalBar a:hover
{
	color: #080808;
	text-decoration: underline;
}

.GlobalBar .Teaser
{
	float: left;
	margin-left: 0.75em;
}

.GlobalBar .Teaser a, .GlobalBar .Teaser a:Link, .GlobalBar .Teaser a:Visited
{
	text-decoration: none;
}



.GlobalBar .SiteMap
{
	float: right;
	margin-right: 12px;
	padding-left: 12px;
}

.GlobalBar
{
	float: left;
	margin-bottom:6px;
	font-size: 90%;

}

.PassportSignOut
{
	vertical-align: middle;
}


.Content .StepOneActive, .Content .StepTwoActive, .Content .StepThreeActive
{
	color:#000000;
}

/*MSDN HEADER*/
/*

/*-------- Start ThinNav --------*/

.ThinNavBox {
	background-color: #821E2D;
	background-image: url(../Images/msdn_mosaic_BG1.jpg);
	background-repeat: no-repeat;
}

.TopLeftCorner {
	background-image: url(../Images/corner_up_left.png);
	background-repeat: no-repeat;
    position: absolute;
    left: 0px;
    top: 0px;
	height: 4px;
	width: 4px;
}

/* Holly hack for IE \*/
* html .TopLeftCorner {
	background-image: none;
	filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='Images/corner_up_left.png', sizingMethod='image');
}
/* */

.BottomLeftCorner {
background-image:url(../Images/corner_bot_left.png);
background-repeat:no-repeat;
height:4px;
left:0px;
position:absolute;
/*top:71px;*/
bottom:0px;
width:4px;
}

/* Holly hack for IE \*/
* html .BottomLeftCorner {
	background-image: none;
	filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='Images/corner_bot_left.png', sizingMethod='image');
}
/* */

.TopRightCorner {
	background-image: url(../Images/corner_up_right.png);
	background-repeat: no-repeat;
    position: absolute;
    right: 0px;
    top: 0px;
	height: 4px;
	width: 4px;
}


/* Holly hack for IE \*/
* html .TopRightCorner {
	background-image: none;
	filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='Images/corner_up_right.png', sizingMethod='image');
}
/* */

.BottomRightCorner {
	background-image: url(../Images/corner_bot_right.png);
	background-repeat: no-repeat;
    position: absolute;
    right: 0px;
	/*top:71px;*/
	bottom:0px;
	height: 4px;
	width: 4px;
}

/* Holly hack for IE \*/
* html .BottomRightCorner {
	background-image: none;
	filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='Images/corner_bot_right.png', sizingMethod='image');
}
/* */

.BrandLogo {
    background-image: url(../Images/logo_msdn.jpg);
	background-repeat: no-repeat;
	height: 42px;
	width: 80px;
	margin-top: 5px;
    margin-right: 42px;
    margin-left: 20px;
}

.IE6 .BrandLogo,.IE7 .BrandLogo  {
    margin-top: 8px;
}

/* Holly hack for IE \*/
* html .BrandLogo {
    margin-left: 10px;
}




.ThinNavTarget a {
	color: white;
}
/* Holly hack for IE \*/
* html .ThinNavTarget a {
	background-color: #8AA0B4;
	border-top: solid 1px #B9C6D2;
	border-bottom: solid 1px #B9C6D2;
}
/* */

.ThinNavTarget a:hover {
	color: white;
}
/* Holly hack for IE \*/
* html .ThinNavTarget a:hover {
	background-color: #9fb8ce;
	border-top: solid 1px #B9C6D2;
	border-bottom: solid 1px #B9C6D2;
}
/* */

.ThinNavTarget a:visited {
	color: white;
}

.thinnavtableft {
    border-left: solid 1px #c87270;
}

.thinnavtabright {
    border-right: solid 1px #c87270;
}

.BrowseCenter {
	background-color: #7A1312;
	border-top: solid 1px #c87270;
	border-bottom: solid 1px #c87270;
}

.BrowseCenter:hover {
	background-color: #a53532;
}

.BrowseSite {
	background-color: #7A1312;
	border-top: solid 1px #c87270;
	border-bottom: solid 1px #c87270;
}

.BrowseSite:hover {
	background-color: #a53532;
}



#JelloSizer {
	margin: 0 auto 0 auto;
	padding: 0;
	width: 87%;
	max-width: 288px;  /* version for IE is at the bottom of this style block */
}
/* Holly hack for IE \*/
* html #JelloSizer {
    width: expression(document.body.clientWidth > 1280 ? ""288px"" : ""87%"" );
}
/* */

#JelloExpander {
	margin-right: -476px;
	margin-left: -476px;
	min-width: 952px; /* Critical Safari fix! */
	position: relative;
}
/* Holly hack for IE \*/
* html #JelloExpander { height: 0; }
/* */

/* helps IE get the child percentages right. */
#JelloWrapper {
    width: 100%;
	border-top: solid 0px #ffffff;
}

#Header {
}

/* http://positioniseverything.net/easyclearing */

.clearfix:after {
	content: "".""; 
	display: block; 
	height: 0; 
	clear: both; 
	visibility: hidden;
}

.clearfix {display: inline-table;}

/* Hides from IE-mac \*/
* html .clearfix {height: 1%;}
.clearfix {display: block;}
/* End hide from IE-mac */

/*-------- Start Header --------*/
/*-------- Start GlobalBar --------*/
.GlobalBar {
    float: left;
	padding-bottom: 6px;
	width: 100%;
}

.GlobalBar a {
	color: #080808;
}

.GlobalBar .Teaser {
    float: left;
    padding-left: 4px;
}

img.DropDownArrow {
	margin-bottom: 2px;
	padding-left: 3px;
}

.PassportScarab {
    
	font-weight: bold;
    vertical-align: middle;
    position:absolute;
    right:1em;
}

.IE6 .PassportScarab
{
	right:2em;
}

.GlobalBar .LocaleFlyout {
    float: right;
	font-weight: bold;
    margin-right: 12px;
}

.GlobalBar .LocaleFlyout a:hover {
	text-decoration: underline;
}

.LocaleFlyout .ContextMenuPanel a {
  	display: block;
  	color: #000000;
  	font-weight: normal;
  	text-decoration: none;
  	white-space: nowrap;
  	cursor: pointer;
  	margin: 1px 0px 1px 0px;
  	padding: 3px 7px 3px 7px;
}

.LocaleFlyout .ContextMenuPanel a:hover {
  	display: block;
  	color: #000000;
  	background-color: #eff5fb;
  	border: solid 1px #afdbee;
  	font-weight: normal;
  	text-decoration: none;
  	white-space: nowrap;
  	cursor: pointer;
  	margin: 1px 2px 1px 2px;
  	padding: 2px 4px 2px 4px;
}

.GlobalBar .SiteMap {
    float: right;
	color: #080808;
    margin-right: 12px;
    padding-left: 12px;
  	cursor: pointer;
}

.GlobalBar .SiteMap:hover {
  	text-decoration: underline;
}

.SiteMap .ContextMenuPanel td {
    white-space:nowrap;
}

.SiteMap .ContextMenuPanel h4 {
    color: Blue;
  	font-weight: bold;
  	margin: 1px 0px 1px 0px;
  	padding: 3px 7px 3px 2px;
}

.SiteMap .ContextMenuPanel .listitem a {
  	display: block;
  	color: #000000;
  	text-decoration: none;
  	white-space: nowrap;
  	cursor: pointer;
  	margin: 1px 0px 1px 0px;
  	padding: 3px 7px 3px 7px;
}

.SiteMap .ContextMenuPanel .listitem a:hover {
  	display: block;
  	color: #000000;
  	background-color: #eff5fb;
  	border: solid 1px #afdbee;
  	text-decoration: none;
  	white-space: nowrap;
  	cursor: pointer;
  	margin: 1px 2px 1px 2px;
  	padding: 2px 4px 2px 4px;
}
/*-------- End GlobalBar --------*/

/*-------- Start ThinNavBox --------*/
.ThinNavBox {
	position:relative;
    height: 57px;
    float:left;
	width: 100%;
}

.IE6 .ThinNavBox 
{
    height: 56px;
}

.BrandLogo {
    float: left;
  	cursor: pointer;
  	position:absolute;
  	top:5px;
}

.IE6 .BrandLogo, .IE7 .BrandLogo
{
	top:0px;
}

.ThinNavTarget {
	margin-top: 19px;
}

.ThinNavTarget a {
  	text-decoration: none;
    padding-top: 1px;
    padding-right: 10px;
    padding-bottom: 3px;
    padding-left: 10px;
}

.ThinNavTarget a:hover {
  	text-decoration: none;
}

.ThinNavTarget a:visited {
  	text-decoration: none;
}

.thinnavtableft {
    float: right;
    height: 18px;
    width: 1px;
}

.thinnavtabright {
    float: right;
    height: 18px;
    width: 1px;
    margin-left: 5px;
}


.BrowseCenter {
    float: right;
    height: 15px;
    padding-top: 1px;

}

.BrowseSite {
    float: right;
    height: 15px;
    padding-top: 1px;

}

/*-------- Start SearchControl --------*/


div#TextBoxSearchDiv input[type=""text""] {
	height: 16px;
}

.TextBoxSearch {
    float: left;
	width: 204px;
	font: 12px Tahoma;
	color: GrayText;
	font-style: italic;
	border-top: solid 1px #849CB1;
	border-bottom: solid 1px #849CB1;
	border-left: solid 1px #849CB1;
	margin-right: -5px;
}

.hidden {
	visibility: hidden;
	display: none;
}
/* Watermark */
.TextBoxSearch {
    float: left;
    height: 16px;
	width: 200px;
	font: italic 12px 'Segoe UI', Tahoma;
	color: #999999;
	border-top: solid 1px #849CB1;
	border-bottom: solid 1px #849CB1;
	border-left: solid 1px #849CB1;
	padding-left: 5px;
	margin-right: -5px;
}

/*
div#TextBoxSearchDiv input[type=""text""] {
	height: 16px;
}

.hidden {
	visibility: hidden;
	display: none;
}
/* Watermark 
.TextBoxSearch {
    float: left;
    height: 16px;
	width: 200px;
	font: italic 9pt 'Segoe UI' , Tahoma;
	color: #000000;
	font-style:normal;
	border-top: solid 1px #676767;
	border-bottom: solid 1px #676767;
	border-left: solid 1px #676767;
	padding-left: 5px;
	margin-right: -6px;
}
*/



.EmptyTextBox {
	COLOR: GrayText! important; 
	FONT-STYLE: italic;
}

.ContextMenuPanel {
	background-color: #ffffff;
    border: solid 1px #676767;
	position: absolute;
    visibility: hidden;
    z-index: 10;
    opacity: .9;
    filter: alpha(opacity=90);
	cursor: default;
}

.NonTransparentContextMenuPanel {
	background-color: #ffffff;
    border: solid 1px #676767;
	position: absolute;
    visibility: hidden;
    z-index: 10;
	cursor: default;
}

a.ContextMenuItem {
	display: block;
	color: #000000;
	text-decoration: none;
	white-space: nowrap;
	cursor: pointer;
	margin: 1px 0px 1px 0px;
	padding: 3px 7px 3px 7px;
}

a.ContextMenuItem:hover {
	display: block;
	color: #000000;
	background-color: #ffffff;
	border: solid 1px #afdbee;
	text-decoration: none;
	margin: 1px 2px 1px 2px;
	padding: 2px 4px 2px 4px;
}

a.ContextMenuItemSelected {
	display: block;
	color: #000000;
	text-decoration: none;
	white-space: nowrap;
	cursor: pointer;
	margin: 1px 0px 1px 0px;
	padding: 3px 7px 3px 7px;
}

a.ContextMenuItemSelected:hover {
	display: block;
	color: #000000;
	background-color: #ffffff;
	border: solid 1px #afdbee;
	text-decoration: none;
	white-space: nowrap;
	cursor: pointer;
	margin: 1px 2px 1px 2px;
	padding: 2px 4px 2px 4px;
}
/*-------- End SearchControl --------*/
/*-------- End ThinNavBox --------*/

/*-------- End ThinNav --------*/


#Footer {
    background-color: #ffffff;
	clear: both;
	text-align: left;
	height: 26px;
	margin-bottom:10px;
	padding-top: 10px;
	padding-bottom: 5px;
}

/*-------- Start Footer --------*/

div.FooterLinks {
	float: left;
	margin-bottom: 10px;	
}

div.FooterLogo {
	float: right;
	height: 29px;
	width: 132px;
    background-repeat: no-repeat;
	margin-top: 14px;
}

div.FooterLinks a{
	color: #0033CC;
	text-decoration: underline;
}

div.FooterLinks a.FooterLink {
    border-left: solid 1px #080808;
    margin-left: 6px;
    padding-left: 7px;
}

a.FooterLinks:hover, div.FooterLinks a:hover {
	color: #FF6600;
	text-decoration: underline;
}

.FooterCopyright {
}


.MSDNNavBox
{
	
	display:block;
	color:#CCCCCC;
	margin-top:1em;
}

.MSDNNavBox .RoundedContent,
.MSDNNavBox .TopBorder,
.MSDNNavBox .RoundedBorder
{
	background-image:none;
	background-color:#EEEEEE;
}

.MSDNNavBox .RoundedContent .HeaderPanel
{
	
	padding-left:10px;
	padding-right:10px;
	padding-top:5px;
	padding-bottom:5px;
}


.MSDNNavBox A:link, .MSDNNavBox A:visited
{
	color:#0033CC;
}
.MSDNNavBox A:hover
{
	color:#FF6600;
}


.CanvasBackground, .CanvasContent
{
	background: none;
}

.CanvasMargin
{
	width:0px;
}


/* Junk */

	BODY {
		FONT-SIZE: 0.7em; MARGIN: 0px; FONT-STYLE: normal; POSITION: relative; HEIGHT: 100%; BACKGROUND-COLOR: #fff; 
	}
	BODY {
		FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif, Geneva;
		}
	INPUT {
		FONT-FAMILY: Segoe UI, Tahoma, Arial, Sans-Serif, Geneva;
	}
	SELECT {
		FONT-FAMILY: Segoe UI, Tahoma, Arial, Sans-Serif, Geneva;
	}
	TEXTAREA {
	FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif, Geneva;
	}
	P {
		MARGIN-TOP: 1em; MARGIN-BOTTOM: 1em; line-height: 1.2em;
	}
	A {
		COLOR: #0033CC; TEXT-DECORATION: none;
	}
	A:link {
		COLOR: #0033CC; TEXT-DECORATION: none;
	}
	A:visited {
		COLOR: #80080; TEXT-DECORATION: none;
	}
	A:active {
		COLOR: #0033CC;
	}
	A:hover {
		COLOR: #FF6600;
	}
	.SecondaryText A {
		COLOR: #0033CC;
	}
	.SecondaryText A:active {
		COLOR: #0033CC;
	}
	.SecondaryText A:link {
		COLOR: #0033CC;
	}
	.SecondaryText A:visited {
		COLOR: #800080;
	}
	A SecondaryText {
		COLOR: #0033CC;
	}
	A.SecondaryText:active {
		COLOR: #0033CC;
	}
	A.SecondaryText:link {
		COLOR: #0033CC;
	}
	A.SecondaryText:visited {
		COLOR: #800080;
	}
	.BrowseDirectoryLink A {
		COLOR: #0033CC! important
	}
	.BrowseDirectoryLink A:link {
		COLOR: #0033CC! important
	}
	.NoImages .SiteHeaderLeft A {
		PADDING-LEFT: 0.7em; FONT-WEIGHT: bold; FONT-SIZE: 3em; COLOR: #000000; TEXT-DECORATION: none
	}
	.NoImages .SiteHeaderLeft A:active {
		PADDING-LEFT: 0.7em; FONT-WEIGHT: bold; FONT-SIZE: 3em; COLOR: #000000; TEXT-DECORATION: none
	}
	.NoImages .SiteHeaderLeft A:link {
		PADDING-LEFT: 0.7em; FONT-WEIGHT: bold; FONT-SIZE: 3em; COLOR: #000000; TEXT-DECORATION: none
	}
	.NoImages .SiteHeaderLeft A:visited {
		PADDING-LEFT: 0.7em; FONT-WEIGHT: bold; FONT-SIZE: 3em; COLOR: #000000; TEXT-DECORATION: none
	}
	.NoImages .SiteHeaderLeft A:hover {
		PADDING-LEFT: 0.7em; FONT-WEIGHT: bold; FONT-SIZE: 3em; COLOR: #000000; TEXT-DECORATION: none
	}
	.NoImages .SiteHeaderLeft {
		PADDING-TOP: 1.2em
	}
	.NoImages .SiteHeaderCenter A {
		COLOR: #0033CC;
	}
	.NoImages .SiteHeaderCenter A:active {
		COLOR: #0033CC;
	}
	.NoImages .SiteHeaderCenter A:link {
		COLOR: #0033CC;
	}
	.NoImages .SiteHeaderCenter A:visited {
		COLOR: #800080;
	}
	.NoImages .SiteHeaderCenter A:hover {
		COLOR: #FF6600;
	}
	A.SubLink {
		FONT-WEIGHT: normal; FONT-SIZE: 0.9em; COLOR: #0033CC;
	}
	.SubLink A {
		FONT-WEIGHT: normal; FONT-SIZE: 0.9em; COLOR: #0033CC;
	}
	.Header H1 {
		DISPLAY: inline; MARGIN: 0px; COLOR: #000000;
	}
	H1.Header {
		DISPLAY: inline; MARGIN: 0px; COLOR: #000000;
	}
	.Header H2 {
		DISPLAY: inline; MARGIN: 0px; COLOR: #000000;
	}
	H2.Header {
		DISPLAY: inline; MARGIN: 0px; COLOR: #000000;
	}
	H3.Header {
		DISPLAY: inline; MARGIN: 0px; COLOR: #000000;
	}
	Header H3 {
		DISPLAY: inline; MARGIN: 0px; COLOR: #000000;
	}
	.AlternateHeader H1 {
		COLOR: #000000;
	}
	H1.AlternateHeader {
		COLOR: #000000;
	}
	.AlternateHeader H2 {
		COLOR: #000000;
	}
	H2.AlternateHeader {
		COLOR: #000000;
	}
	H3.AlternateHeader {
		COLOR: #000000;
	}
	.AlternateHeader H3 {
		COLOR: #000000;
	}
	.SecondaryText {
		COLOR: #000000;
	}
	.AlternateBackground {
		BACKGROUND-COLOR: #EEEEEE;
	}
	.AlternateBackgroundDark {
		BACKGROUND-COLOR: #999999;
	}


#ProjectRelease #VoteBoxCell
{
	width:6em !important;
	overflow:hidden; 
	min-width:5em;
}

.SidebarContainer .Content .Row .Input
{
	font-size:0.84em;
}

.InfoBox
{
	border: solid .1em #bbb;
	text-align: center;
	width: 5.5em;
}

.TabStrip td
{
	width:6em;
}

#ProjectReleaseEditDeleteButtonTab
{
	padding-top:.5em;
}

.Grid .Header
{
	background-color:#959595; /*#E6E6E6*/
}

.WorkItemAdvancedView .Header a:link 
{
	color: White;
}

.WorkItemAdvancedView .Header a:hover
{
	color: Blue;
}

.IE6 ul.RssFeedsPanel li
{
	width:12em;
}

.MultiFileHeight
{
	font-size: 1.1em;
}

.FileUploadHeight
{
	height: 1.7em;
}

.RightPanelMinHeight 
{
	height: auto !important;
	min-height: 0 !important;
}
";
            string expected =
                "<div style=\"color:Black;background-color:White;\"><pre>\r\n<span style=\"color:#A31515;\">body </span>{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#080808</span>;\r\n\t<span style=\"color:Red;\">font-family</span>: <span style=\"color:Blue;\">Verdana</span>;\r\n\t<span style=\"color:Red;\">font-size</span>: <span style=\"color:Blue;\">62.5%</span>;\r\n\t<span style=\"color:Red;\">margin-right</span>: <span style=\"color:Blue;\">20px</span>;\r\n\t<span style=\"color:Red;\">margin-top</span>: <span style=\"color:Blue;\">4px</span>;\r\n\t<span style=\"color:Red;\">margin-left</span>: <span style=\"color:Blue;\">20px</span>;\r\n\t\r\n}\r\n\r\n<span style=\"color:#A31515;\">.AutoCompletePanel</span>\r\n{\r\n\t<span style=\"color:Red;\">z-index</span>:<span style=\"color:Blue;\">1000</span>;\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.MSMarginBottom</span>\r\n{\r\n\t<span style=\"color:Red;\">margin-bottom</span>:<span style=\"color:Blue;\">2em</span>;\t\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">30em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.UpdateProgress</span>\r\n{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#CDDFF2</span>;\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t<span style=\"color:Red;\">font-weight</span>:<span style=\"color:Blue;\">bold</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">#WikiVersions th</span>\r\n{\r\n\t<span style=\"color:Red;\">background-color</span>:<span style=\"color:Blue;\">#ECECEC</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.Grid .Header </span>\r\n{\r\n\t<span style=\"color:Red;\">background-color</span>:<span style=\"color:Blue;\">#ECECEC</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">ul</span>\r\n{\r\n\t<span style=\"color:Red;\">list-style-image</span>:<span style=\"color:Blue;\">none</span>;\r\n}\r\n<span style=\"color:#A31515;\">li</span>\r\n{\r\n\t<span style=\"color:Red;\">padding-top</span>:<span style=\"color:Blue;\">.5em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.IE7 .workItemDetails .leftCell</span>,\r\n<span style=\"color:#A31515;\">.IE6 .workItemDetails .leftCell</span>\r\n{\r\n\t<span style=\"color:Red;\">width</span>:<span style=\"color:Blue;\">8em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.IE7 .workItemDetails .rightCell</span>\r\n{\r\n\t<span style=\"color:Red;\">padding-left</span>: <span style=\"color:Blue;\">0.4em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.IE7 .workItemDetails .rightCellEditable </span>\r\n{\r\n\t<span style=\"color:Red;\">padding-left</span>: <span style=\"color:Blue;\">0.4em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.IE6 .workItemDetails .smartDate</span>\r\n{\r\n\t<span style=\"color:Red;\">display</span>:<span style=\"color:Blue;\">block</span>;\r\n\t<span style=\"color:Red;\">width</span>:<span style=\"color:Blue;\">9em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.SideBar .ContentPanel .HeaderPanel</span>\r\n{\r\n\t<span style=\"color:Red;\">padding</span>:<span style=\"color:Blue;\">0px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.PageStep</span>\r\n{\r\n\t<span style=\"color:Red;\">padding-bottom</span>:<span style=\"color:Blue;\">1em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.Header h1</span>, <span style=\"color:#A31515;\">h1.Header</span>, <span style=\"color:#A31515;\">.Header h2</span>, <span style=\"color:#A31515;\">h2.Header</span>, <span style=\"color:#A31515;\">h3.Header</span>, <span style=\"color:#A31515;\">Header h3</span>, <span style=\"color:#A31515;\">.CodePlexPageHeader</span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#000000</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.SignInPanel .RoundedContent</span>, <span style=\"color:#A31515;\">.SignInPanel .RoundedBorder</span>\r\n{\r\n\t<span style=\"color:Red;\">background</span>: <span style=\"color:Blue;\">none</span>;\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.TabLink</span>\r\n{\r\n\t<span style=\"color:Red;\">padding-top</span>:<span style=\"color:Blue;\">2px</span>;\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.SiteContent</span>\r\n{\r\n\t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">0</span>;\r\n\t<span style=\"color:Red;\">padding-top</span>: <span style=\"color:Blue;\">1em</span>;\r\n\t<span style=\"color:Red;\">padding-left</span>:<span style=\"color:Blue;\">1em</span>;\r\n\t<span style=\"color:Red;\">padding-right</span>:<span style=\"color:Blue;\">1em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.CanvasContent .SiteHeader</span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">black</span>;\r\n\t<span style=\"color:Red;\">padding-top</span>: <span style=\"color:Blue;\">0.3em</span>;\r\n\t<span style=\"color:Red;\">padding-bottom</span>:<span style=\"color:Blue;\">10px</span>;\r\n\t\r\n\t<span style=\"color:Red;\">padding-left</span>:<span style=\"color:Blue;\">1em</span>;\r\n\t<span style=\"color:Red;\">padding-right</span>:<span style=\"color:Blue;\">1em</span>;\r\n\t<span style=\"color:Red;\">width</span>:<span style=\"color:Blue;\">98%</span>;\r\n}\r\n\r\n\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar h4</span>\r\n{\r\n\t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">0</span>;\r\n\t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">0</span>;\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.BulletLink</span>\r\n{\r\n\t<span style=\"color:Red;\">background-image</span>:<span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">padding</span>:<span style=\"color:Blue;\">0px</span>;\r\n\t<span style=\"color:Red;\">margin</span>:<span style=\"color:Blue;\">0px</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n/*MSDNAboutPanel Styles */</span>\r\n<span style=\"color:#A31515;\">.MSDNAboutPanel</span>\r\n{\r\n\t<span style=\"color:Red;\">margin-right</span>:<span style=\"color:Blue;\">1em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.MSDNAboutPanel h2</span>\r\n{\r\n\t<span style=\"color:Red;\">font-size</span>:<span style=\"color:Blue;\">1.3em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">#TitleSearchHeader</span>\r\n{\r\n\t<span style=\"color:Red;\">width</span>:<span style=\"color:Blue;\">100%</span>;\r\n\t<span style=\"color:Red;\">padding-bottom</span>:<span style=\"color:Blue;\">3em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.IE6 #TitleSearchHeader</span>, <span style=\"color:#A31515;\">.IE7 #TitleSearchHeader</span>\r\n{\r\n\t<span style=\"color:Red;\">padding-bottom</span>:<span style=\"color:Blue;\">1em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">#TitleSearchHeader .TitleHeader</span>\r\n{\r\n\t<span style=\"color:Red;\">float</span>:<span style=\"color:Blue;\">left</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">#TitleSearchHeader .ProjectSearchBox</span>\r\n{\r\n\t<span style=\"color:Red;\">float</span>:<span style=\"color:Blue;\">right</span>;\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.MSDNSearch</span>\r\n{\r\n\t<span style=\"color:Red;\">float</span>:<span style=\"color:Blue;\">right</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.ProjectSearchPanel</span>\r\n{\r\n\t<span style=\"color:Red;\">float</span>:<span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">margin-left</span>:<span style=\"color:Blue;\">13px</span>;\r\n\t<span style=\"color:Red;\">margin-right</span>:<span style=\"color:Blue;\">15px</span>;\r\n}\r\n\r\n*<span style=\"color:#A31515;\"> html .ProjectSearchPanel </span>{\r\n\t<span style=\"color:Red;\">margin-right</span>: <span style=\"color:Blue;\">6px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.TagMSDNCellBody</span>\r\n{\r\n\t<span style=\"color:Red;\">border</span>:<span style=\"color:Blue;\">solid 1px #000000</span>;\r\n\t<span style=\"color:Red;\">xbackground-color</span>: <span style=\"color:Blue;\">#AA2520</span>;\r\n\t<span style=\"color:Red;\">background-image</span>:<span style=\"color:Blue;\">url(/images/tag_bg.jpg)</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.TagMSDNBody </span>\r\n{\r\n\t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">0.3em</span>;\r\n\t<span style=\"color:Red;\">font-size</span>: <span style=\"color:Blue;\">1.3em</span>;\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.TagMSDNBody a:link</span>, <span style=\"color:#A31515;\">.TagMSDNBody a:visited</span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">White</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.TagMSDNBody a:hover</span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>:<span style=\"color:Blue;\">#FF6600</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n\r\n/*TagColor Styles */</span>\r\n<span style=\"color:#A31515;\">.TagMSDNHeader </span>\r\n{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#3B3E3F</span>;\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">White</span>;\r\n\t<span style=\"color:Red;\">font-weight</span>: <span style=\"color:Blue;\">bold</span>;\r\n\t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">0.2em</span>;\r\n\t<span style=\"color:Red;\">font-size</span>: <span style=\"color:Blue;\">1.3em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.TagMSDNHeader a:link</span>, <span style=\"color:#A31515;\">.TagMSDNHeader a:visited </span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">White</span>;\r\n}\r\n\r\n\r\n\r\n\r\n<span style=\"color:#A31515;\">.RightSideBar .TagMSDNCellBody</span>\r\n{\r\n\t<span style=\"color:Red;\">margin-top</span>:<span style=\"color:Blue;\">1em</span>;\r\n}\r\n<span style=\"color:#A31515;\">.RightSideBar .TagMSDNBody</span>,\r\n<span style=\"color:#A31515;\">.RightSideBar .TagMSDNHeader</span>\r\n{\r\n\t<span style=\"color:Red;\">font-size</span>:<span style=\"color:Blue;\">.9em</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n/*AboutMSDNSubPanel Styles*/</span>\r\n<span style=\"color:#A31515;\">.MSDNAboutSubPanel</span>\r\n{\r\n\t<span style=\"color:Red;\">overflow</span>:<span style=\"color:Blue;\">hidden</span>;\r\n\t<span style=\"color:Red;\">padding</span>:<span style=\"color:Blue;\">1em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.MSDNAboutSubPanelImage</span>\r\n{\r\n\t<span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">left</span>;\r\n\t<span style=\"color:Red;\">padding-right</span>: <span style=\"color:Blue;\">0.1em</span>;\r\n}\r\n\t\r\n<span style=\"color:#A31515;\">.ContentPanel .RoundedContent .MSDNAboutSubPanel .Header</span>\r\n{\t\r\n    <span style=\"color:Red;\">color</span>:<span style=\"color:Blue;\">#FFFFFF</span>;\r\n    <span style=\"color:Red;\">padding-top</span>:<span style=\"color:Blue;\">.4em</span>;\r\n    <span style=\"color:Red;\">margin</span>:<span style=\"color:Blue;\">0px</span>;\r\n\t<span style=\"color:Red;\">padding-bottom</span>:<span style=\"color:Blue;\">.4em</span>;\r\n\t<span style=\"color:Red;\">position</span>: <span style=\"color:Blue;\">relative</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.ContentPanel .MSDNAboutSubPanel .Content</span>\r\n{\t\r\n\t<span style=\"color:Red;\">padding</span>:<span style=\"color:Blue;\">.5em</span>;\r\n\t<span style=\"color:Red;\">height</span>:<span style=\"color:Blue;\">6em</span>; \r\n}\r\n\r\n<span style=\"color:#A31515;\">.ContentPanel .MSDNAboutSubPanel .RoundedContent </span>\r\n{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">Transparent</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n\r\n/* Content Panel overrides */</span>\r\n<span style=\"color:#A31515;\">.ContentPanel  .HeaderPanel</span>{\r\n    <span style=\"color:Red;\">padding</span>:<span style=\"color:Blue;\">/*{css:StandardPadding}*/</span>;\r\n    <span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">none</span>;\r\n    <span style=\"color:Red;\">background-color</span>:<span style=\"color:Blue;\">Transparent</span>;\r\n    <span style=\"color:Red;\">position</span>:<span style=\"color:Blue;\">relative</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.ContentPanel  .RoundedContent .FooterPanel</span>{\r\n    <span style=\"color:Red;\">padding</span>:<span style=\"color:Blue;\">/*{css:StandardPadding}*/</span>;\r\n    <span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">none</span>;\r\n    <span style=\"color:Red;\">background-color</span>:<span style=\"color:Blue;\">Transparent</span>;\r\n    <span style=\"color:Red;\">position</span>:<span style=\"color:Blue;\">relative</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.ContentPanel .RoundedContent</span>, \r\n<span style=\"color:#A31515;\">.AlternateBackgroundPanel .RoundedContent</span>,\r\n<span style=\"color:#A31515;\">.AlternateBackgroundPanel .RoundedBorder</span>,\r\n<span style=\"color:#A31515;\">.ContentPanel .TopBorder </span>{\r\n    <span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">none</span>;\r\n    <span style=\"color:Red;\">background-repeat</span>:<span style=\"color:Blue;\">repeat-x</span>;\r\n    <span style=\"color:Red;\">background-color</span>:<span style=\"color:Blue;\">#fff</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.ContentPanel .TopBorder</span>\r\n{\r\n\t<span style=\"color:Red;\">background-image</span>:<span style=\"color:Blue;\">url(../Images/contentpanel_gradientbg.gif)</span>;\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.ContentPanel .RoundedContentContainer .BottomBorder</span>,\r\n<span style=\"color:#A31515;\">.ContentPanel .RoundedContent .HeaderPanel</span>\r\n{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">Transparent</span>;\r\n\t\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.ContentPanel .RoundedContent</span>\r\n{\r\n\t<span style=\"color:Red;\">background-image</span>:<span style=\"color:Blue;\">url(../Images/contentpanel_gradientbg.gif)</span>;\r\n\r\n}\r\n\r\n\r\n\r\n<span style=\"color:#A31515;\">.TabPanel .RoundedBorder</span>, <span style=\"color:#A31515;\">.TabPanel .RoundedContent </span>{\r\n\t<span style=\"color:Red;\">background-color</span>:<span style=\"color:Blue;\">#FFFFFF</span>;\r\n\t<span style=\"color:Red;\">background-image</span>:<span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">background-repeat</span>:<span style=\"color:Blue;\">repeat-x</span>;\r\n\t<span style=\"color:Red;\">text-align</span>:<span style=\"color:Blue;\">center</span>;\r\n\t<span style=\"color:Red;\">width</span>:<span style=\"color:Blue;\">auto</span>;\r\n}\r\n<span style=\"color:#A31515;\"> .TabPanel .RoundedContent </span>{\r\n\t<span style=\"color:Red;\">background-image</span>:<span style=\"color:Blue;\">url(../images/button_gradient.gif)</span>;\r\n\t<span style=\"color:Red;\">background-position</span>:<span style=\"color:Blue;\">left bottom !important</span>;\r\n\t<span style=\"color:Red;\">background-repeat</span>:<span style=\"color:Blue;\">repeat-x</span>;\r\n\t<span style=\"color:Red;\">min-height</span>:<span style=\"color:Blue;\">1px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\"> .ActiveTab .RoundedBorder</span>, <span style=\"color:#A31515;\">.ActiveTab .RoundedContent </span>{\r\n\t<span style=\"color:Red;\">background-color</span>:<span style=\"color:Blue;\">#FFFFFF</span>;\r\n\t<span style=\"color:Red;\">background-image</span>:<span style=\"color:Blue;\">none</span>;\r\n}\r\n\r\n\r\n\r\n<span style=\"color:#A31515;\">.ResultListPanel .GridHeader</span>\r\n{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#959595</span>\r\n}\r\n<span style=\"color:#A31515;\">.ResultListPanel .GridHeader .SecondaryText</span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>:<span style=\"color:Blue;\">White</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.InlineBox</span>\r\n{\r\n\t<span style=\"color:Red;\">display</span>:<span style=\"color:Blue;\">inline</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n/* MSDN Header CSS */</span>\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar a</span>, <span style=\"color:#A31515;\">.GlobalBar a:Link</span>, <span style=\"color:#A31515;\">.GlobalBar a:Visited</span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#080808</span>;\r\n\t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar a:hover</span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#080808</span>;\r\n\t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">underline</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar .Teaser</span>\r\n{\r\n\t<span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">left</span>;\r\n\t<span style=\"color:Red;\">margin-left</span>: <span style=\"color:Blue;\">0.75em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar .Teaser a</span>, <span style=\"color:#A31515;\">.GlobalBar .Teaser a:Link</span>, <span style=\"color:#A31515;\">.GlobalBar .Teaser a:Visited</span>\r\n{\r\n\t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n}\r\n\r\n\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar .SiteMap</span>\r\n{\r\n\t<span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">right</span>;\r\n\t<span style=\"color:Red;\">margin-right</span>: <span style=\"color:Blue;\">12px</span>;\r\n\t<span style=\"color:Red;\">padding-left</span>: <span style=\"color:Blue;\">12px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar</span>\r\n{\r\n\t<span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">left</span>;\r\n\t<span style=\"color:Red;\">margin-bottom</span>:<span style=\"color:Blue;\">6px</span>;\r\n\t<span style=\"color:Red;\">font-size</span>: <span style=\"color:Blue;\">90%</span>;\r\n\r\n}\r\n\r\n<span style=\"color:#A31515;\">.PassportSignOut</span>\r\n{\r\n\t<span style=\"color:Red;\">vertical-align</span>: <span style=\"color:Blue;\">middle</span>;\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.Content .StepOneActive</span>, <span style=\"color:#A31515;\">.Content .StepTwoActive</span>, <span style=\"color:#A31515;\">.Content .StepThreeActive</span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>:<span style=\"color:Blue;\">#000000</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n/*MSDN HEADER*/</span><span style=\"color:Green;\">\r\n/*\r\n\r\n/*-------- Start ThinNav --------*/</span>\r\n\r\n<span style=\"color:#A31515;\">.ThinNavBox </span>{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#821E2D</span>;\r\n\t<span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">url(../Images/msdn_mosaic_BG1.jpg)</span>;\r\n\t<span style=\"color:Red;\">background-repeat</span>: <span style=\"color:Blue;\">no-repeat</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.TopLeftCorner </span>{\r\n\t<span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">url(../Images/corner_up_left.png)</span>;\r\n\t<span style=\"color:Red;\">background-repeat</span>: <span style=\"color:Blue;\">no-repeat</span>;\r\n    <span style=\"color:Red;\">position</span>: <span style=\"color:Blue;\">absolute</span>;\r\n    <span style=\"color:Red;\">left</span>: <span style=\"color:Blue;\">0px</span>;\r\n    <span style=\"color:Red;\">top</span>: <span style=\"color:Blue;\">0px</span>;\r\n\t<span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">4px</span>;\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">4px</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n/* Holly hack for IE \\*/</span>\r\n*<span style=\"color:#A31515;\"> html .TopLeftCorner </span>{\r\n\t<span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">filter</span>:<span style=\"color:Blue;\">progid:DXImageTransform.Microsoft.AlphaImageLoader(src='Images/corner_up_left.png', sizingMethod='image')</span>;\r\n}<span style=\"color:Green;\">\r\n/* */</span>\r\n\r\n<span style=\"color:#A31515;\">.BottomLeftCorner </span>{\r\n<span style=\"color:Red;\">background-image</span>:<span style=\"color:Blue;\">url(../Images/corner_bot_left.png)</span>;\r\n<span style=\"color:Red;\">background-repeat</span>:<span style=\"color:Blue;\">no-repeat</span>;\r\n<span style=\"color:Red;\">height</span>:<span style=\"color:Blue;\">4px</span>;\r\n<span style=\"color:Red;\">left</span>:<span style=\"color:Blue;\">0px</span>;\r\n<span style=\"color:Red;\">position</span>:<span style=\"color:Blue;\">absolute</span>;<span style=\"color:Green;\">\r\n/*top:71px;*/</span>\r\n<span style=\"color:Red;\">bottom</span>:<span style=\"color:Blue;\">0px</span>;\r\n<span style=\"color:Red;\">width</span>:<span style=\"color:Blue;\">4px</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n/* Holly hack for IE \\*/</span>\r\n*<span style=\"color:#A31515;\"> html .BottomLeftCorner </span>{\r\n\t<span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">filter</span>:<span style=\"color:Blue;\">progid:DXImageTransform.Microsoft.AlphaImageLoader(src='Images/corner_bot_left.png', sizingMethod='image')</span>;\r\n}<span style=\"color:Green;\">\r\n/* */</span>\r\n\r\n<span style=\"color:#A31515;\">.TopRightCorner </span>{\r\n\t<span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">url(../Images/corner_up_right.png)</span>;\r\n\t<span style=\"color:Red;\">background-repeat</span>: <span style=\"color:Blue;\">no-repeat</span>;\r\n    <span style=\"color:Red;\">position</span>: <span style=\"color:Blue;\">absolute</span>;\r\n    <span style=\"color:Red;\">right</span>: <span style=\"color:Blue;\">0px</span>;\r\n    <span style=\"color:Red;\">top</span>: <span style=\"color:Blue;\">0px</span>;\r\n\t<span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">4px</span>;\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">4px</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n\r\n/* Holly hack for IE \\*/</span>\r\n*<span style=\"color:#A31515;\"> html .TopRightCorner </span>{\r\n\t<span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">filter</span>:<span style=\"color:Blue;\">progid:DXImageTransform.Microsoft.AlphaImageLoader(src='Images/corner_up_right.png', sizingMethod='image')</span>;\r\n}<span style=\"color:Green;\">\r\n/* */</span>\r\n\r\n<span style=\"color:#A31515;\">.BottomRightCorner </span>{\r\n\t<span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">url(../Images/corner_bot_right.png)</span>;\r\n\t<span style=\"color:Red;\">background-repeat</span>: <span style=\"color:Blue;\">no-repeat</span>;\r\n    <span style=\"color:Red;\">position</span>: <span style=\"color:Blue;\">absolute</span>;\r\n    <span style=\"color:Red;\">right</span>: <span style=\"color:Blue;\">0px</span>;<span style=\"color:Green;\">\r\n\t/*top:71px;*/</span>\r\n\t<span style=\"color:Red;\">bottom</span>:<span style=\"color:Blue;\">0px</span>;\r\n\t<span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">4px</span>;\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">4px</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n/* Holly hack for IE \\*/</span>\r\n*<span style=\"color:#A31515;\"> html .BottomRightCorner </span>{\r\n\t<span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">filter</span>:<span style=\"color:Blue;\">progid:DXImageTransform.Microsoft.AlphaImageLoader(src='Images/corner_bot_right.png', sizingMethod='image')</span>;\r\n}<span style=\"color:Green;\">\r\n/* */</span>\r\n\r\n<span style=\"color:#A31515;\">.BrandLogo </span>{\r\n    <span style=\"color:Red;\">background-image</span>: <span style=\"color:Blue;\">url(../Images/logo_msdn.jpg)</span>;\r\n\t<span style=\"color:Red;\">background-repeat</span>: <span style=\"color:Blue;\">no-repeat</span>;\r\n\t<span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">42px</span>;\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">80px</span>;\r\n\t<span style=\"color:Red;\">margin-top</span>: <span style=\"color:Blue;\">5px</span>;\r\n    <span style=\"color:Red;\">margin-right</span>: <span style=\"color:Blue;\">42px</span>;\r\n    <span style=\"color:Red;\">margin-left</span>: <span style=\"color:Blue;\">20px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.IE6 .BrandLogo</span>,<span style=\"color:#A31515;\">.IE7 .BrandLogo  </span>{\r\n    <span style=\"color:Red;\">margin-top</span>: <span style=\"color:Blue;\">8px</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n/* Holly hack for IE \\*/</span>\r\n*<span style=\"color:#A31515;\"> html .BrandLogo </span>{\r\n    <span style=\"color:Red;\">margin-left</span>: <span style=\"color:Blue;\">10px</span>;\r\n}\r\n\r\n\r\n\r\n\r\n<span style=\"color:#A31515;\">.ThinNavTarget a </span>{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">white</span>;\r\n}<span style=\"color:Green;\">\r\n/* Holly hack for IE \\*/</span>\r\n*<span style=\"color:#A31515;\"> html .ThinNavTarget a </span>{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#8AA0B4</span>;\r\n\t<span style=\"color:Red;\">border-top</span>: <span style=\"color:Blue;\">solid 1px #B9C6D2</span>;\r\n\t<span style=\"color:Red;\">border-bottom</span>: <span style=\"color:Blue;\">solid 1px #B9C6D2</span>;\r\n}<span style=\"color:Green;\">\r\n/* */</span>\r\n\r\n<span style=\"color:#A31515;\">.ThinNavTarget a:hover </span>{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">white</span>;\r\n}<span style=\"color:Green;\">\r\n/* Holly hack for IE \\*/</span>\r\n*<span style=\"color:#A31515;\"> html .ThinNavTarget a:hover </span>{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#9fb8ce</span>;\r\n\t<span style=\"color:Red;\">border-top</span>: <span style=\"color:Blue;\">solid 1px #B9C6D2</span>;\r\n\t<span style=\"color:Red;\">border-bottom</span>: <span style=\"color:Blue;\">solid 1px #B9C6D2</span>;\r\n}<span style=\"color:Green;\">\r\n/* */</span>\r\n\r\n<span style=\"color:#A31515;\">.ThinNavTarget a:visited </span>{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">white</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.thinnavtableft </span>{\r\n    <span style=\"color:Red;\">border-left</span>: <span style=\"color:Blue;\">solid 1px #c87270</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.thinnavtabright </span>{\r\n    <span style=\"color:Red;\">border-right</span>: <span style=\"color:Blue;\">solid 1px #c87270</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.BrowseCenter </span>{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#7A1312</span>;\r\n\t<span style=\"color:Red;\">border-top</span>: <span style=\"color:Blue;\">solid 1px #c87270</span>;\r\n\t<span style=\"color:Red;\">border-bottom</span>: <span style=\"color:Blue;\">solid 1px #c87270</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.BrowseCenter:hover </span>{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#a53532</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.BrowseSite </span>{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#7A1312</span>;\r\n\t<span style=\"color:Red;\">border-top</span>: <span style=\"color:Blue;\">solid 1px #c87270</span>;\r\n\t<span style=\"color:Red;\">border-bottom</span>: <span style=\"color:Blue;\">solid 1px #c87270</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.BrowseSite:hover </span>{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#a53532</span>;\r\n}\r\n\r\n\r\n\r\n<span style=\"color:#A31515;\">#JelloSizer </span>{\r\n\t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">0 auto 0 auto</span>;\r\n\t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">0</span>;\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">87%</span>;\r\n\t<span style=\"color:Red;\">max-width</span>: <span style=\"color:Blue;\">288px</span>;<span style=\"color:Green;\">  /* version for IE is at the bottom of this style block */</span>\r\n}<span style=\"color:Green;\">\r\n/* Holly hack for IE \\*/</span>\r\n*<span style=\"color:#A31515;\"> html #JelloSizer </span>{\r\n    <span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">expression(document.body.clientWidth &gt; 1280 ? &quot;288px&quot; : &quot;87%&quot; )</span>;\r\n}<span style=\"color:Green;\">\r\n/* */</span>\r\n\r\n<span style=\"color:#A31515;\">#JelloExpander </span>{\r\n\t<span style=\"color:Red;\">margin-right</span>: <span style=\"color:Blue;\">-476px</span>;\r\n\t<span style=\"color:Red;\">margin-left</span>: <span style=\"color:Blue;\">-476px</span>;\r\n\t<span style=\"color:Red;\">min-width</span>: <span style=\"color:Blue;\">952px</span>;<span style=\"color:Green;\"> /* Critical Safari fix! */</span>\r\n\t<span style=\"color:Red;\">position</span>: <span style=\"color:Blue;\">relative</span>;\r\n}<span style=\"color:Green;\">\r\n/* Holly hack for IE \\*/</span>\r\n*<span style=\"color:#A31515;\"> html #JelloExpander </span>{ <span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">0</span>; }<span style=\"color:Green;\">\r\n/* */</span><span style=\"color:Green;\">\r\n\r\n/* helps IE get the child percentages right. */</span>\r\n<span style=\"color:#A31515;\">#JelloWrapper </span>{\r\n    <span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">100%</span>;\r\n\t<span style=\"color:Red;\">border-top</span>: <span style=\"color:Blue;\">solid 0px #ffffff</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">#Header </span>{\r\n}<span style=\"color:Green;\">\r\n\r\n/* http://positioniseverything.net/easyclearing */</span>\r\n\r\n<span style=\"color:#A31515;\">.clearfix:after </span>{\r\n\t<span style=\"color:Red;\">content</span>: <span style=\"color:Blue;\">&quot;.&quot;</span>; \r\n\t<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">block</span>; \r\n\t<span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">0</span>; \r\n\t<span style=\"color:Red;\">clear</span>: <span style=\"color:Blue;\">both</span>; \r\n\t<span style=\"color:Red;\">visibility</span>: <span style=\"color:Blue;\">hidden</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.clearfix </span>{<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">inline-table</span>;}<span style=\"color:Green;\">\r\n\r\n/* Hides from IE-mac \\*/</span>\r\n*<span style=\"color:#A31515;\"> html .clearfix </span>{<span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">1%</span>;}\r\n<span style=\"color:#A31515;\">.clearfix </span>{<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">block</span>;}<span style=\"color:Green;\">\r\n/* End hide from IE-mac */</span><span style=\"color:Green;\">\r\n\r\n/*-------- Start Header --------*/</span><span style=\"color:Green;\">\r\n/*-------- Start GlobalBar --------*/</span>\r\n<span style=\"color:#A31515;\">.GlobalBar </span>{\r\n    <span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">left</span>;\r\n\t<span style=\"color:Red;\">padding-bottom</span>: <span style=\"color:Blue;\">6px</span>;\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">100%</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar a </span>{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#080808</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar .Teaser </span>{\r\n    <span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">left</span>;\r\n    <span style=\"color:Red;\">padding-left</span>: <span style=\"color:Blue;\">4px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">img.DropDownArrow </span>{\r\n\t<span style=\"color:Red;\">margin-bottom</span>: <span style=\"color:Blue;\">2px</span>;\r\n\t<span style=\"color:Red;\">padding-left</span>: <span style=\"color:Blue;\">3px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.PassportScarab </span>{\r\n    \r\n\t<span style=\"color:Red;\">font-weight</span>: <span style=\"color:Blue;\">bold</span>;\r\n    <span style=\"color:Red;\">vertical-align</span>: <span style=\"color:Blue;\">middle</span>;\r\n    <span style=\"color:Red;\">position</span>:<span style=\"color:Blue;\">absolute</span>;\r\n    <span style=\"color:Red;\">right</span>:<span style=\"color:Blue;\">1em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.IE6 .PassportScarab</span>\r\n{\r\n\t<span style=\"color:Red;\">right</span>:<span style=\"color:Blue;\">2em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar .LocaleFlyout </span>{\r\n    <span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">right</span>;\r\n\t<span style=\"color:Red;\">font-weight</span>: <span style=\"color:Blue;\">bold</span>;\r\n    <span style=\"color:Red;\">margin-right</span>: <span style=\"color:Blue;\">12px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar .LocaleFlyout a:hover </span>{\r\n\t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">underline</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.LocaleFlyout .ContextMenuPanel a </span>{\r\n  \t<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">block</span>;\r\n  \t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#000000</span>;\r\n  \t<span style=\"color:Red;\">font-weight</span>: <span style=\"color:Blue;\">normal</span>;\r\n  \t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n  \t<span style=\"color:Red;\">white-space</span>: <span style=\"color:Blue;\">nowrap</span>;\r\n  \t<span style=\"color:Red;\">cursor</span>: <span style=\"color:Blue;\">pointer</span>;\r\n  \t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">1px 0px 1px 0px</span>;\r\n  \t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">3px 7px 3px 7px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.LocaleFlyout .ContextMenuPanel a:hover </span>{\r\n  \t<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">block</span>;\r\n  \t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#000000</span>;\r\n  \t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#eff5fb</span>;\r\n  \t<span style=\"color:Red;\">border</span>: <span style=\"color:Blue;\">solid 1px #afdbee</span>;\r\n  \t<span style=\"color:Red;\">font-weight</span>: <span style=\"color:Blue;\">normal</span>;\r\n  \t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n  \t<span style=\"color:Red;\">white-space</span>: <span style=\"color:Blue;\">nowrap</span>;\r\n  \t<span style=\"color:Red;\">cursor</span>: <span style=\"color:Blue;\">pointer</span>;\r\n  \t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">1px 2px 1px 2px</span>;\r\n  \t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">2px 4px 2px 4px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar .SiteMap </span>{\r\n    <span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">right</span>;\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#080808</span>;\r\n    <span style=\"color:Red;\">margin-right</span>: <span style=\"color:Blue;\">12px</span>;\r\n    <span style=\"color:Red;\">padding-left</span>: <span style=\"color:Blue;\">12px</span>;\r\n  \t<span style=\"color:Red;\">cursor</span>: <span style=\"color:Blue;\">pointer</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.GlobalBar .SiteMap:hover </span>{\r\n  \t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">underline</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.SiteMap .ContextMenuPanel td </span>{\r\n    <span style=\"color:Red;\">white-space</span>:<span style=\"color:Blue;\">nowrap</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.SiteMap .ContextMenuPanel h4 </span>{\r\n    <span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">Blue</span>;\r\n  \t<span style=\"color:Red;\">font-weight</span>: <span style=\"color:Blue;\">bold</span>;\r\n  \t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">1px 0px 1px 0px</span>;\r\n  \t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">3px 7px 3px 2px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.SiteMap .ContextMenuPanel .listitem a </span>{\r\n  \t<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">block</span>;\r\n  \t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#000000</span>;\r\n  \t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n  \t<span style=\"color:Red;\">white-space</span>: <span style=\"color:Blue;\">nowrap</span>;\r\n  \t<span style=\"color:Red;\">cursor</span>: <span style=\"color:Blue;\">pointer</span>;\r\n  \t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">1px 0px 1px 0px</span>;\r\n  \t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">3px 7px 3px 7px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.SiteMap .ContextMenuPanel .listitem a:hover </span>{\r\n  \t<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">block</span>;\r\n  \t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#000000</span>;\r\n  \t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#eff5fb</span>;\r\n  \t<span style=\"color:Red;\">border</span>: <span style=\"color:Blue;\">solid 1px #afdbee</span>;\r\n  \t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n  \t<span style=\"color:Red;\">white-space</span>: <span style=\"color:Blue;\">nowrap</span>;\r\n  \t<span style=\"color:Red;\">cursor</span>: <span style=\"color:Blue;\">pointer</span>;\r\n  \t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">1px 2px 1px 2px</span>;\r\n  \t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">2px 4px 2px 4px</span>;\r\n}<span style=\"color:Green;\">\r\n/*-------- End GlobalBar --------*/</span><span style=\"color:Green;\">\r\n\r\n/*-------- Start ThinNavBox --------*/</span>\r\n<span style=\"color:#A31515;\">.ThinNavBox </span>{\r\n\t<span style=\"color:Red;\">position</span>:<span style=\"color:Blue;\">relative</span>;\r\n    <span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">57px</span>;\r\n    <span style=\"color:Red;\">float</span>:<span style=\"color:Blue;\">left</span>;\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">100%</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.IE6 .ThinNavBox </span>\r\n{\r\n    <span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">56px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.BrandLogo </span>{\r\n    <span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">left</span>;\r\n  \t<span style=\"color:Red;\">cursor</span>: <span style=\"color:Blue;\">pointer</span>;\r\n  \t<span style=\"color:Red;\">position</span>:<span style=\"color:Blue;\">absolute</span>;\r\n  \t<span style=\"color:Red;\">top</span>:<span style=\"color:Blue;\">5px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.IE6 .BrandLogo</span>, <span style=\"color:#A31515;\">.IE7 .BrandLogo</span>\r\n{\r\n\t<span style=\"color:Red;\">top</span>:<span style=\"color:Blue;\">0px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.ThinNavTarget </span>{\r\n\t<span style=\"color:Red;\">margin-top</span>: <span style=\"color:Blue;\">19px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.ThinNavTarget a </span>{\r\n  \t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n    <span style=\"color:Red;\">padding-top</span>: <span style=\"color:Blue;\">1px</span>;\r\n    <span style=\"color:Red;\">padding-right</span>: <span style=\"color:Blue;\">10px</span>;\r\n    <span style=\"color:Red;\">padding-bottom</span>: <span style=\"color:Blue;\">3px</span>;\r\n    <span style=\"color:Red;\">padding-left</span>: <span style=\"color:Blue;\">10px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.ThinNavTarget a:hover </span>{\r\n  \t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.ThinNavTarget a:visited </span>{\r\n  \t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.thinnavtableft </span>{\r\n    <span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">right</span>;\r\n    <span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">18px</span>;\r\n    <span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">1px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.thinnavtabright </span>{\r\n    <span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">right</span>;\r\n    <span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">18px</span>;\r\n    <span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">1px</span>;\r\n    <span style=\"color:Red;\">margin-left</span>: <span style=\"color:Blue;\">5px</span>;\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.BrowseCenter </span>{\r\n    <span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">right</span>;\r\n    <span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">15px</span>;\r\n    <span style=\"color:Red;\">padding-top</span>: <span style=\"color:Blue;\">1px</span>;\r\n\r\n}\r\n\r\n<span style=\"color:#A31515;\">.BrowseSite </span>{\r\n    <span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">right</span>;\r\n    <span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">15px</span>;\r\n    <span style=\"color:Red;\">padding-top</span>: <span style=\"color:Blue;\">1px</span>;\r\n\r\n}<span style=\"color:Green;\">\r\n\r\n/*-------- Start SearchControl --------*/</span>\r\n\r\n\r\n<span style=\"color:#A31515;\">div#TextBoxSearchDiv input[type=&quot;text&quot;] </span>{\r\n\t<span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">16px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.TextBoxSearch </span>{\r\n    <span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">left</span>;\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">204px</span>;\r\n\t<span style=\"color:Red;\">font</span>: <span style=\"color:Blue;\">12px Tahoma</span>;\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">GrayText</span>;\r\n\t<span style=\"color:Red;\">font-style</span>: <span style=\"color:Blue;\">italic</span>;\r\n\t<span style=\"color:Red;\">border-top</span>: <span style=\"color:Blue;\">solid 1px #849CB1</span>;\r\n\t<span style=\"color:Red;\">border-bottom</span>: <span style=\"color:Blue;\">solid 1px #849CB1</span>;\r\n\t<span style=\"color:Red;\">border-left</span>: <span style=\"color:Blue;\">solid 1px #849CB1</span>;\r\n\t<span style=\"color:Red;\">margin-right</span>: <span style=\"color:Blue;\">-5px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.hidden </span>{\r\n\t<span style=\"color:Red;\">visibility</span>: <span style=\"color:Blue;\">hidden</span>;\r\n\t<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">none</span>;\r\n}<span style=\"color:Green;\">\r\n/* Watermark */</span>\r\n<span style=\"color:#A31515;\">.TextBoxSearch </span>{\r\n    <span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">left</span>;\r\n    <span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">16px</span>;\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">200px</span>;\r\n\t<span style=\"color:Red;\">font</span>: <span style=\"color:Blue;\">italic 12px 'Segoe UI', Tahoma</span>;\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#999999</span>;\r\n\t<span style=\"color:Red;\">border-top</span>: <span style=\"color:Blue;\">solid 1px #849CB1</span>;\r\n\t<span style=\"color:Red;\">border-bottom</span>: <span style=\"color:Blue;\">solid 1px #849CB1</span>;\r\n\t<span style=\"color:Red;\">border-left</span>: <span style=\"color:Blue;\">solid 1px #849CB1</span>;\r\n\t<span style=\"color:Red;\">padding-left</span>: <span style=\"color:Blue;\">5px</span>;\r\n\t<span style=\"color:Red;\">margin-right</span>: <span style=\"color:Blue;\">-5px</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n/*\r\ndiv#TextBoxSearchDiv input[type=&quot;text&quot;] {\r\n\theight: 16px;\r\n}\r\n\r\n.hidden {\r\n\tvisibility: hidden;\r\n\tdisplay: none;\r\n}\r\n/* Watermark \r\n.TextBoxSearch {\r\n    float: left;\r\n    height: 16px;\r\n\twidth: 200px;\r\n\tfont: italic 9pt 'Segoe UI' , Tahoma;\r\n\tcolor: #000000;\r\n\tfont-style:normal;\r\n\tborder-top: solid 1px #676767;\r\n\tborder-bottom: solid 1px #676767;\r\n\tborder-left: solid 1px #676767;\r\n\tpadding-left: 5px;\r\n\tmargin-right: -6px;\r\n}\r\n*/</span>\r\n\r\n\r\n\r\n<span style=\"color:#A31515;\">.EmptyTextBox </span>{\r\n\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">GrayText! important</span>; \r\n\t<span style=\"color:Red;\">FONT-STYLE</span>: <span style=\"color:Blue;\">italic</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.ContextMenuPanel </span>{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#ffffff</span>;\r\n    <span style=\"color:Red;\">border</span>: <span style=\"color:Blue;\">solid 1px #676767</span>;\r\n\t<span style=\"color:Red;\">position</span>: <span style=\"color:Blue;\">absolute</span>;\r\n    <span style=\"color:Red;\">visibility</span>: <span style=\"color:Blue;\">hidden</span>;\r\n    <span style=\"color:Red;\">z-index</span>: <span style=\"color:Blue;\">10</span>;\r\n    <span style=\"color:Red;\">opacity</span>: <span style=\"color:Blue;\">.9</span>;\r\n    <span style=\"color:Red;\">filter</span>: <span style=\"color:Blue;\">alpha(opacity=90)</span>;\r\n\t<span style=\"color:Red;\">cursor</span>: <span style=\"color:Blue;\">default</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.NonTransparentContextMenuPanel </span>{\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#ffffff</span>;\r\n    <span style=\"color:Red;\">border</span>: <span style=\"color:Blue;\">solid 1px #676767</span>;\r\n\t<span style=\"color:Red;\">position</span>: <span style=\"color:Blue;\">absolute</span>;\r\n    <span style=\"color:Red;\">visibility</span>: <span style=\"color:Blue;\">hidden</span>;\r\n    <span style=\"color:Red;\">z-index</span>: <span style=\"color:Blue;\">10</span>;\r\n\t<span style=\"color:Red;\">cursor</span>: <span style=\"color:Blue;\">default</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">a.ContextMenuItem </span>{\r\n\t<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">block</span>;\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">white-space</span>: <span style=\"color:Blue;\">nowrap</span>;\r\n\t<span style=\"color:Red;\">cursor</span>: <span style=\"color:Blue;\">pointer</span>;\r\n\t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">1px 0px 1px 0px</span>;\r\n\t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">3px 7px 3px 7px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">a.ContextMenuItem:hover </span>{\r\n\t<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">block</span>;\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#ffffff</span>;\r\n\t<span style=\"color:Red;\">border</span>: <span style=\"color:Blue;\">solid 1px #afdbee</span>;\r\n\t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">1px 2px 1px 2px</span>;\r\n\t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">2px 4px 2px 4px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">a.ContextMenuItemSelected </span>{\r\n\t<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">block</span>;\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">white-space</span>: <span style=\"color:Blue;\">nowrap</span>;\r\n\t<span style=\"color:Red;\">cursor</span>: <span style=\"color:Blue;\">pointer</span>;\r\n\t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">1px 0px 1px 0px</span>;\r\n\t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">3px 7px 3px 7px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">a.ContextMenuItemSelected:hover </span>{\r\n\t<span style=\"color:Red;\">display</span>: <span style=\"color:Blue;\">block</span>;\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t<span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#ffffff</span>;\r\n\t<span style=\"color:Red;\">border</span>: <span style=\"color:Blue;\">solid 1px #afdbee</span>;\r\n\t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">white-space</span>: <span style=\"color:Blue;\">nowrap</span>;\r\n\t<span style=\"color:Red;\">cursor</span>: <span style=\"color:Blue;\">pointer</span>;\r\n\t<span style=\"color:Red;\">margin</span>: <span style=\"color:Blue;\">1px 2px 1px 2px</span>;\r\n\t<span style=\"color:Red;\">padding</span>: <span style=\"color:Blue;\">2px 4px 2px 4px</span>;\r\n}<span style=\"color:Green;\">\r\n/*-------- End SearchControl --------*/</span><span style=\"color:Green;\">\r\n/*-------- End ThinNavBox --------*/</span><span style=\"color:Green;\">\r\n\r\n/*-------- End ThinNav --------*/</span>\r\n\r\n\r\n<span style=\"color:#A31515;\">#Footer </span>{\r\n    <span style=\"color:Red;\">background-color</span>: <span style=\"color:Blue;\">#ffffff</span>;\r\n\t<span style=\"color:Red;\">clear</span>: <span style=\"color:Blue;\">both</span>;\r\n\t<span style=\"color:Red;\">text-align</span>: <span style=\"color:Blue;\">left</span>;\r\n\t<span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">26px</span>;\r\n\t<span style=\"color:Red;\">margin-bottom</span>:<span style=\"color:Blue;\">10px</span>;\r\n\t<span style=\"color:Red;\">padding-top</span>: <span style=\"color:Blue;\">10px</span>;\r\n\t<span style=\"color:Red;\">padding-bottom</span>: <span style=\"color:Blue;\">5px</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n/*-------- Start Footer --------*/</span>\r\n\r\n<span style=\"color:#A31515;\">div.FooterLinks </span>{\r\n\t<span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">left</span>;\r\n\t<span style=\"color:Red;\">margin-bottom</span>: <span style=\"color:Blue;\">10px</span>;\t\r\n}\r\n\r\n<span style=\"color:#A31515;\">div.FooterLogo </span>{\r\n\t<span style=\"color:Red;\">float</span>: <span style=\"color:Blue;\">right</span>;\r\n\t<span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">29px</span>;\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">132px</span>;\r\n    <span style=\"color:Red;\">background-repeat</span>: <span style=\"color:Blue;\">no-repeat</span>;\r\n\t<span style=\"color:Red;\">margin-top</span>: <span style=\"color:Blue;\">14px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">div.FooterLinks a</span>{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">underline</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">div.FooterLinks a.FooterLink </span>{\r\n    <span style=\"color:Red;\">border-left</span>: <span style=\"color:Blue;\">solid 1px #080808</span>;\r\n    <span style=\"color:Red;\">margin-left</span>: <span style=\"color:Blue;\">6px</span>;\r\n    <span style=\"color:Red;\">padding-left</span>: <span style=\"color:Blue;\">7px</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">a.FooterLinks:hover</span>, <span style=\"color:#A31515;\">div.FooterLinks a:hover </span>{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">#FF6600</span>;\r\n\t<span style=\"color:Red;\">text-decoration</span>: <span style=\"color:Blue;\">underline</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.FooterCopyright </span>{\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.MSDNNavBox</span>\r\n{\r\n\t\r\n\t<span style=\"color:Red;\">display</span>:<span style=\"color:Blue;\">block</span>;\r\n\t<span style=\"color:Red;\">color</span>:<span style=\"color:Blue;\">#CCCCCC</span>;\r\n\t<span style=\"color:Red;\">margin-top</span>:<span style=\"color:Blue;\">1em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.MSDNNavBox .RoundedContent</span>,\r\n<span style=\"color:#A31515;\">.MSDNNavBox .TopBorder</span>,\r\n<span style=\"color:#A31515;\">.MSDNNavBox .RoundedBorder</span>\r\n{\r\n\t<span style=\"color:Red;\">background-image</span>:<span style=\"color:Blue;\">none</span>;\r\n\t<span style=\"color:Red;\">background-color</span>:<span style=\"color:Blue;\">#EEEEEE</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.MSDNNavBox .RoundedContent .HeaderPanel</span>\r\n{\r\n\t\r\n\t<span style=\"color:Red;\">padding-left</span>:<span style=\"color:Blue;\">10px</span>;\r\n\t<span style=\"color:Red;\">padding-right</span>:<span style=\"color:Blue;\">10px</span>;\r\n\t<span style=\"color:Red;\">padding-top</span>:<span style=\"color:Blue;\">5px</span>;\r\n\t<span style=\"color:Red;\">padding-bottom</span>:<span style=\"color:Blue;\">5px</span>;\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.MSDNNavBox A:link</span>, <span style=\"color:#A31515;\">.MSDNNavBox A:visited</span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>:<span style=\"color:Blue;\">#0033CC</span>;\r\n}\r\n<span style=\"color:#A31515;\">.MSDNNavBox A:hover</span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>:<span style=\"color:Blue;\">#FF6600</span>;\r\n}\r\n\r\n\r\n<span style=\"color:#A31515;\">.CanvasBackground</span>, <span style=\"color:#A31515;\">.CanvasContent</span>\r\n{\r\n\t<span style=\"color:Red;\">background</span>: <span style=\"color:Blue;\">none</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.CanvasMargin</span>\r\n{\r\n\t<span style=\"color:Red;\">width</span>:<span style=\"color:Blue;\">0px</span>;\r\n}<span style=\"color:Green;\">\r\n\r\n\r\n/* Junk */</span>\r\n\r\n\t<span style=\"color:#A31515;\">BODY </span>{\r\n\t\t<span style=\"color:Red;\">FONT-SIZE</span>: <span style=\"color:Blue;\">0.7em</span>; <span style=\"color:Red;\">MARGIN</span>: <span style=\"color:Blue;\">0px</span>; <span style=\"color:Red;\">FONT-STYLE</span>: <span style=\"color:Blue;\">normal</span>; <span style=\"color:Red;\">POSITION</span>: <span style=\"color:Blue;\">relative</span>; <span style=\"color:Red;\">HEIGHT</span>: <span style=\"color:Blue;\">100%</span>; <span style=\"color:Red;\">BACKGROUND-COLOR</span>: <span style=\"color:Blue;\">#fff</span>; \r\n\t}\r\n\t<span style=\"color:#A31515;\">BODY </span>{\r\n\t\t<span style=\"color:Red;\">FONT-FAMILY</span>: <span style=\"color:Blue;\">Verdana, Arial, Helvetica, sans-serif, Geneva</span>;\r\n\t\t}\r\n\t<span style=\"color:#A31515;\">INPUT </span>{\r\n\t\t<span style=\"color:Red;\">FONT-FAMILY</span>: <span style=\"color:Blue;\">Segoe UI, Tahoma, Arial, Sans-Serif, Geneva</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">SELECT </span>{\r\n\t\t<span style=\"color:Red;\">FONT-FAMILY</span>: <span style=\"color:Blue;\">Segoe UI, Tahoma, Arial, Sans-Serif, Geneva</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">TEXTAREA </span>{\r\n\t<span style=\"color:Red;\">FONT-FAMILY</span>: <span style=\"color:Blue;\">Verdana, Arial, Helvetica, sans-serif, Geneva</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">P </span>{\r\n\t\t<span style=\"color:Red;\">MARGIN-TOP</span>: <span style=\"color:Blue;\">1em</span>; <span style=\"color:Red;\">MARGIN-BOTTOM</span>: <span style=\"color:Blue;\">1em</span>; <span style=\"color:Red;\">line-height</span>: <span style=\"color:Blue;\">1.2em</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">A </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>; <span style=\"color:Red;\">TEXT-DECORATION</span>: <span style=\"color:Blue;\">none</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">A:link </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>; <span style=\"color:Red;\">TEXT-DECORATION</span>: <span style=\"color:Blue;\">none</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">A:visited </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#80080</span>; <span style=\"color:Red;\">TEXT-DECORATION</span>: <span style=\"color:Blue;\">none</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">A:active </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">A:hover </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#FF6600</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.SecondaryText A </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.SecondaryText A:active </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.SecondaryText A:link </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.SecondaryText A:visited </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#800080</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">A SecondaryText </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">A.SecondaryText:active </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">A.SecondaryText:link </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">A.SecondaryText:visited </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#800080</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.BrowseDirectoryLink A </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC! important</span>\r\n\t}\r\n\t<span style=\"color:#A31515;\">.BrowseDirectoryLink A:link </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC! important</span>\r\n\t}\r\n\t<span style=\"color:#A31515;\">.NoImages .SiteHeaderLeft A </span>{\r\n\t\t<span style=\"color:Red;\">PADDING-LEFT</span>: <span style=\"color:Blue;\">0.7em</span>; <span style=\"color:Red;\">FONT-WEIGHT</span>: <span style=\"color:Blue;\">bold</span>; <span style=\"color:Red;\">FONT-SIZE</span>: <span style=\"color:Blue;\">3em</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>; <span style=\"color:Red;\">TEXT-DECORATION</span>: <span style=\"color:Blue;\">none</span>\r\n\t}\r\n\t<span style=\"color:#A31515;\">.NoImages .SiteHeaderLeft A:active </span>{\r\n\t\t<span style=\"color:Red;\">PADDING-LEFT</span>: <span style=\"color:Blue;\">0.7em</span>; <span style=\"color:Red;\">FONT-WEIGHT</span>: <span style=\"color:Blue;\">bold</span>; <span style=\"color:Red;\">FONT-SIZE</span>: <span style=\"color:Blue;\">3em</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>; <span style=\"color:Red;\">TEXT-DECORATION</span>: <span style=\"color:Blue;\">none</span>\r\n\t}\r\n\t<span style=\"color:#A31515;\">.NoImages .SiteHeaderLeft A:link </span>{\r\n\t\t<span style=\"color:Red;\">PADDING-LEFT</span>: <span style=\"color:Blue;\">0.7em</span>; <span style=\"color:Red;\">FONT-WEIGHT</span>: <span style=\"color:Blue;\">bold</span>; <span style=\"color:Red;\">FONT-SIZE</span>: <span style=\"color:Blue;\">3em</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>; <span style=\"color:Red;\">TEXT-DECORATION</span>: <span style=\"color:Blue;\">none</span>\r\n\t}\r\n\t<span style=\"color:#A31515;\">.NoImages .SiteHeaderLeft A:visited </span>{\r\n\t\t<span style=\"color:Red;\">PADDING-LEFT</span>: <span style=\"color:Blue;\">0.7em</span>; <span style=\"color:Red;\">FONT-WEIGHT</span>: <span style=\"color:Blue;\">bold</span>; <span style=\"color:Red;\">FONT-SIZE</span>: <span style=\"color:Blue;\">3em</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>; <span style=\"color:Red;\">TEXT-DECORATION</span>: <span style=\"color:Blue;\">none</span>\r\n\t}\r\n\t<span style=\"color:#A31515;\">.NoImages .SiteHeaderLeft A:hover </span>{\r\n\t\t<span style=\"color:Red;\">PADDING-LEFT</span>: <span style=\"color:Blue;\">0.7em</span>; <span style=\"color:Red;\">FONT-WEIGHT</span>: <span style=\"color:Blue;\">bold</span>; <span style=\"color:Red;\">FONT-SIZE</span>: <span style=\"color:Blue;\">3em</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>; <span style=\"color:Red;\">TEXT-DECORATION</span>: <span style=\"color:Blue;\">none</span>\r\n\t}\r\n\t<span style=\"color:#A31515;\">.NoImages .SiteHeaderLeft </span>{\r\n\t\t<span style=\"color:Red;\">PADDING-TOP</span>: <span style=\"color:Blue;\">1.2em</span>\r\n\t}\r\n\t<span style=\"color:#A31515;\">.NoImages .SiteHeaderCenter A </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.NoImages .SiteHeaderCenter A:active </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.NoImages .SiteHeaderCenter A:link </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.NoImages .SiteHeaderCenter A:visited </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#800080</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.NoImages .SiteHeaderCenter A:hover </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#FF6600</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">A.SubLink </span>{\r\n\t\t<span style=\"color:Red;\">FONT-WEIGHT</span>: <span style=\"color:Blue;\">normal</span>; <span style=\"color:Red;\">FONT-SIZE</span>: <span style=\"color:Blue;\">0.9em</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.SubLink A </span>{\r\n\t\t<span style=\"color:Red;\">FONT-WEIGHT</span>: <span style=\"color:Blue;\">normal</span>; <span style=\"color:Red;\">FONT-SIZE</span>: <span style=\"color:Blue;\">0.9em</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#0033CC</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.Header H1 </span>{\r\n\t\t<span style=\"color:Red;\">DISPLAY</span>: <span style=\"color:Blue;\">inline</span>; <span style=\"color:Red;\">MARGIN</span>: <span style=\"color:Blue;\">0px</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">H1.Header </span>{\r\n\t\t<span style=\"color:Red;\">DISPLAY</span>: <span style=\"color:Blue;\">inline</span>; <span style=\"color:Red;\">MARGIN</span>: <span style=\"color:Blue;\">0px</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.Header H2 </span>{\r\n\t\t<span style=\"color:Red;\">DISPLAY</span>: <span style=\"color:Blue;\">inline</span>; <span style=\"color:Red;\">MARGIN</span>: <span style=\"color:Blue;\">0px</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">H2.Header </span>{\r\n\t\t<span style=\"color:Red;\">DISPLAY</span>: <span style=\"color:Blue;\">inline</span>; <span style=\"color:Red;\">MARGIN</span>: <span style=\"color:Blue;\">0px</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">H3.Header </span>{\r\n\t\t<span style=\"color:Red;\">DISPLAY</span>: <span style=\"color:Blue;\">inline</span>; <span style=\"color:Red;\">MARGIN</span>: <span style=\"color:Blue;\">0px</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">Header H3 </span>{\r\n\t\t<span style=\"color:Red;\">DISPLAY</span>: <span style=\"color:Blue;\">inline</span>; <span style=\"color:Red;\">MARGIN</span>: <span style=\"color:Blue;\">0px</span>; <span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.AlternateHeader H1 </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">H1.AlternateHeader </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.AlternateHeader H2 </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">H2.AlternateHeader </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">H3.AlternateHeader </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.AlternateHeader H3 </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.SecondaryText </span>{\r\n\t\t<span style=\"color:Red;\">COLOR</span>: <span style=\"color:Blue;\">#000000</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.AlternateBackground </span>{\r\n\t\t<span style=\"color:Red;\">BACKGROUND-COLOR</span>: <span style=\"color:Blue;\">#EEEEEE</span>;\r\n\t}\r\n\t<span style=\"color:#A31515;\">.AlternateBackgroundDark </span>{\r\n\t\t<span style=\"color:Red;\">BACKGROUND-COLOR</span>: <span style=\"color:Blue;\">#999999</span>;\r\n\t}\r\n\r\n\r\n<span style=\"color:#A31515;\">#ProjectRelease #VoteBoxCell</span>\r\n{\r\n\t<span style=\"color:Red;\">width</span>:<span style=\"color:Blue;\">6em !important</span>;\r\n\t<span style=\"color:Red;\">overflow</span>:<span style=\"color:Blue;\">hidden</span>; \r\n\t<span style=\"color:Red;\">min-width</span>:<span style=\"color:Blue;\">5em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.SidebarContainer .Content .Row .Input</span>\r\n{\r\n\t<span style=\"color:Red;\">font-size</span>:<span style=\"color:Blue;\">0.84em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.InfoBox</span>\r\n{\r\n\t<span style=\"color:Red;\">border</span>: <span style=\"color:Blue;\">solid .1em #bbb</span>;\r\n\t<span style=\"color:Red;\">text-align</span>: <span style=\"color:Blue;\">center</span>;\r\n\t<span style=\"color:Red;\">width</span>: <span style=\"color:Blue;\">5.5em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.TabStrip td</span>\r\n{\r\n\t<span style=\"color:Red;\">width</span>:<span style=\"color:Blue;\">6em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">#ProjectReleaseEditDeleteButtonTab</span>\r\n{\r\n\t<span style=\"color:Red;\">padding-top</span>:<span style=\"color:Blue;\">.5em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.Grid .Header</span>\r\n{\r\n\t<span style=\"color:Red;\">background-color</span>:<span style=\"color:Blue;\">#959595</span>;<span style=\"color:Green;\"> /*#E6E6E6*/</span>\r\n}\r\n\r\n<span style=\"color:#A31515;\">.WorkItemAdvancedView .Header a:link </span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">White</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.WorkItemAdvancedView .Header a:hover</span>\r\n{\r\n\t<span style=\"color:Red;\">color</span>: <span style=\"color:Blue;\">Blue</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.IE6 ul.RssFeedsPanel li</span>\r\n{\r\n\t<span style=\"color:Red;\">width</span>:<span style=\"color:Blue;\">12em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.MultiFileHeight</span>\r\n{\r\n\t<span style=\"color:Red;\">font-size</span>: <span style=\"color:Blue;\">1.1em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.FileUploadHeight</span>\r\n{\r\n\t<span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">1.7em</span>;\r\n}\r\n\r\n<span style=\"color:#A31515;\">.RightPanelMinHeight </span>\r\n{\r\n\t<span style=\"color:Red;\">height</span>: <span style=\"color:Blue;\">auto !important</span>;\r\n\t<span style=\"color:Red;\">min-height</span>: <span style=\"color:Blue;\">0 !important</span>;\r\n}\r\n\r\n</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Css);

            Assert.Equal(expected, actual);
        }
    }
}

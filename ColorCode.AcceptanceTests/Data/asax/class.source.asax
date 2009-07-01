<%@ Application Language="C#" CodeBehind="Global.asax.cs" Inherits="Microsoft.Foundation.Web.Global" %>
<script runat="server">
using System.IO;
using System.Text;
using System.Web;
using CodePlex.Common;
using CodePlex.Presentation.Compression;
using CodePlex.Presentation.Css.Presenter;
using CodePlex.Presentation.Navigation;

namespace CodePlex.WebSite.Css
{
    /// <summary>
    /// StyleSheet.ashx parses and delivers css files submitted through the QueryString
    /// It replaces constants described by the css file in the form 
    /// 
    ///     /*{css:ConstantName}*/
    /// 
    /// with the correspondingly named AppSetting Key from the containing directory's .config file
    /// </summary>
    public class StyleSheet : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/css";
            if (context.Request.QueryString["i"] == null)
                return;

            string[] cssFiles;
            cssFiles = css.ToString().Split(',');
            for (int i = 0; i < cssFiles.Length; i++)
            {
                cssFiles[i] = Path.GetFileName(cssFiles[i].Trim());
                if (!Path.HasExtension(cssFiles[i]))
                    cssFiles[i] = Path.ChangeExtension(cssFiles[i], ".css");
            }

            //Cache settings handled in AddHeaderItemsToRequestModule
            //bool alreadyCached;
            //CompressionUtility.SetCaching(context, cssFiles, out alreadyCached);
            //if (alreadyCached)
            //    return;
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
</script>
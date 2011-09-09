using System;
using System.Web;

namespace HttpModule
{
    public class HTMLValidateModule : IHttpModule
    {
        /// <summary>
        /// 您将需要在您网站的 web.config 文件中配置此模块，
        /// 并向 IIS 注册此模块，然后才能使用。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication context = sender as HttpApplication;
            if (context.Request.Url.AbsolutePath.EndsWith(".html") || context.Request.Url.AbsolutePath.EndsWith(".htm"))
            {
                HttpCookie cookie = context.Request.Cookies["ticketCookie"];
                if (cookie == null)
                {
                    context.Response.Write("您需要登录后才能访问本资源");
                    context.Response.Redirect("~/Account/Login.aspx");
                }
            }
        }
        #endregion
    }
}

using System;

namespace CCMSUI
{
    public class Global : System.Web.HttpApplication
    {
         protected void Application_Start(object sender, EventArgs e)
        {
            try
            {

              
            }
            catch (Exception ex)
            {
             }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
    
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            this.Response.Headers["X-Content-Type-Options"] = "nosniff";
        }

        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server");
        }


    }
}
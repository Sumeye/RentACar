using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Filter
{
    public class AutFilter : FilterAttribute, IAuthorizationFilter
    {
        //Yetki kontrolü için gerekli methoddur.
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.Session["UserName"] == null)
            {
                filterContext.Result = new RedirectResult("/Admin/Login");

            }
            else
            {

            }
        }
    }
}
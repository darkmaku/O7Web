﻿// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Web.Domain.Advisory;

namespace Angkor.O7Web.Interface.Advisory.Controller
{
    public partial class SettingsController : O7Controller
    {
        public ActionResult Period()
        {
            return View();
        }        
    }
}
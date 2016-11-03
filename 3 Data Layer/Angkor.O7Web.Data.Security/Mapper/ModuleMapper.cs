﻿// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Utility;
using Angkor.O7Web.Common.Security.Entity;

namespace Angkor.O7Web.Data.Security.Mapper
{
    public class ModuleMapper : O7Mapper<Module>
    {
        public override Module Map()
            => new Module { Title = O7Row.GetValue<string>(0), Version = O7Row.GetValue<string>(1), Url = O7Row.GetValue<string>(2) };        
    }
}
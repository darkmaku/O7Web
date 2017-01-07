﻿// Create by Felix A. Bueno
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Web.Common.Security.Entity;

namespace Angkor.O7Web.Data.Security.DataMapper
{
    public class CompanyDataMapper : O7DbMapper<Company>
    {
        public override Company MapTarget()
            => new Company { Id = Source.GetValue<string>(0), Description = Source.GetValue<string>(1) };
    }
}
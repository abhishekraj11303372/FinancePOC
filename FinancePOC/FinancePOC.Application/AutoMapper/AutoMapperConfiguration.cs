﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancePOC.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelProfile());
            });
        }
    }
}

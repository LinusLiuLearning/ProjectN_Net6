﻿using AutoMapper;
using ProjectN.Repository.DTO.Condition;
using ProjectN.Repository.DTO.DataModel;
using ProjectN.Service.Dtos.Info;
using ProjectN.Service.Dtos.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectN.Service.Mappings
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            // Info -> Condition
            this.CreateMap<CardInfo, CardCondition>();
            this.CreateMap<CardSearchInfo, CardSearchCondition>();

            // DataModel -> ResultModel
            this.CreateMap<CardDataModel, CardResultModel>();
        }
    }
}

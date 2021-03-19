using AppleAppRequest.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campus_technology_server.AppleAppRequest.Models
{
    public class AppleAppRequestProfile : Profile
    {
        public AppleAppRequestProfile()
        {
            CreateMap<AppleAppRequestEditView, AppleAppRequestModel>()
                .ReverseMap();
        }
        
    }
}

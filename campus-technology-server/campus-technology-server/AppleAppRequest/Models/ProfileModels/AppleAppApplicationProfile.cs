using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleAppRequest.Models
{
    public class AppleAppApplicationProfile : Profile
    {
        public AppleAppApplicationProfile()
        {
            CreateMap<AppleAppRequestedApplicationEditView, AppleAppRequestedApplicationModel>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleAppRequest.Models
{
    public class AppleAppRequestedApplicationProfile : Profile
    {
        public AppleAppRequestedApplicationProfile()
        {
            CreateMap<AppleAppRequestedApplicationEditView, AppleAppRequestedApplicationModel>()
                .ForMember(a => a.ReferenceId, o => o.MapFrom(s => Guid.NewGuid().ToString()))
                .ReverseMap();
        }
    }
}

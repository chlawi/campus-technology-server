using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleAppRequest.Models
{
    public class AppleAppRequestedDeviceProfile : Profile
    {
        public AppleAppRequestedDeviceProfile()
        {
            CreateMap<AppleAppRequestedDeviceEditView, AppleAppRequestedDeviceModel>()
                .ForMember(a => a.ReferenceId, o => o.MapFrom(s => Guid.NewGuid().ToString()))
                .ReverseMap();
        }
    }
}

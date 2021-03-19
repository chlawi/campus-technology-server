using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleAppRequest.Models
{
    public class AppleAppDeviceProfile : Profile
    {
        public AppleAppDeviceProfile()
        {
            CreateMap<AppleAppRequestedDeviceEditView, AppleAppRequestedDeviceModel>()
                .ReverseMap();
        }
    }
}

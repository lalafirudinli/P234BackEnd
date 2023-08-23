using AutoMapper;
using Pironia.Business.ViewModels.SliderViewModels;
using Pironia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pironia.Business.Mappers;

public class SliderProfile : Profile
{
    public SliderProfile()
    {
        CreateMap<Slider, SliderPostVM>().ReverseMap();
    }

}


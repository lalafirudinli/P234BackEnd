using AutoMapper;
using Foxic.Business.ViewModels.SliderViewModels;
using Foxic.Core.Entities.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.Mappers;

public class SliderProfile : Profile
{
	public SliderProfile() 
	{
		CreateMap<Slider, SliderPostVM>().ReverseMap();
		CreateMap<SliderUploadVM, Slider>().ReverseMap();
	}
}

using AutoMapper;
using WebApplication1.DTOs.User;
using WebApplication1.Models;

namespace WebApplication1
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<RegisterDto, User>();
            //CreateMap<Widget, WidgetDto>();
            //CreateMap<WidgetDto, Widget>();
            //CreateMap<Dashboard, DashboardDto>();
            //CreateMap<UpdateDashboardDto, Dashboard>();
            //CreateMap<TaskDto, Entities.Task>();
            //CreateMap<Entities.Task, TaskDto>();
            //CreateMap<ContactDto, Contact>();
            //CreateMap<Contact, ContactDto>();
        }
    }
}

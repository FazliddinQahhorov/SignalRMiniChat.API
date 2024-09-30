using AutoMapper;
using SignalRMiniChat.Application.DTO;
using SignalRMiniChat.Domain.Models;

namespace SignalRMiniChat.Application.Mapper;

public class MappingProfile : Profile
{
   public MappingProfile() 
   {
        CreateMap<Admin, AdminForCreation>().ReverseMap();
        CreateMap<User, UserForCreation>().ReverseMap();
        CreateMap<Chat, ChatForCreation>().ReverseMap();
        CreateMap<Chat, ChatForResult>().ReverseMap();
        CreateMap<ChatMessage, ChatMessageDTO>().ReverseMap();
        CreateMap<ChatMessage, ChatMessageForCreation>().ReverseMap();
   }

}

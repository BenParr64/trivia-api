using AutoMapper;
using PubQuiz.Domain;

namespace PubQuiz.Services.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionDto, Question>()
                .ForMember(dest => dest.Prompt, opt => opt.MapFrom(src => src.Prompt))
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer))
                .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.QuestionId))
                ;
        }
    }
}

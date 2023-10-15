using API.DTOs;
using AutoMapper;

namespace API
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<User, UserDto>();
            CreateMap<Weapon, WeaponDto>();
            CreateMap<Skill, SkillDto>();
        }
    }
}
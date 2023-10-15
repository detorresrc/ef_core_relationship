using API.Data;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CharacterController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CharacterDto>>> Get()
        {
            var characters = await _context
                .Characters
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .Include(c => c.User)
                .ToListAsync();
            return Ok(_mapper.Map<List<CharacterDto>>(characters));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetById(int id)
        {
            var characters = await _context.Characters
                .Where(c => c.Id == id)
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .Include(c => c.User)
                .FirstOrDefaultAsync();
            return Ok(_mapper.Map<CharacterDto>(characters));
        }

        [HttpPost]
        public async Task<ActionResult<CharacterDto>> Create(CreateCharacterDto characterDto)
        {
            var user = _context.Users.FirstOrDefault();
            if(user==null) return NotFound();

            var character = new Character{
                Description=characterDto.Description,
                RpgClass = characterDto.RpgClass,
                User = user
            };
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            var _character = _mapper.Map<CharacterDto>(character);

            return Ok(_character);
        }

        [HttpPost("AddWeapon")]
        public async Task<ActionResult<CharacterDto>> AddWeapon(AddWeaponDto addWeaponDto)
        {
            var character = await _context.Characters.FindAsync(addWeaponDto.CharacterId);
            if(character==null) return NotFound("Character not found!");

            var weapon = new Weapon{
                Name = addWeaponDto.Name,
                Damage = addWeaponDto.Damage,
            };

            _context.Weapons.Add(weapon);

            character.Weapon = weapon;
            _context.Characters.Update(character);

            await _context.SaveChangesAsync();
            return Ok(
                _mapper.Map<CharacterDto>(
                    await _context.Characters
                        .Where(c => c.Id == character.Id)
                        .Include(c => c.Weapon)
                        .Include(c => c.Skills)
                        .Include(c => c.User)
                        .FirstOrDefaultAsync()
                )
            );
        }

        [HttpPost("AddSkill")]
        public async Task<ActionResult<CharacterDto>> AddSkill(AddSkillDto addSkillDto)
        {
            var character = await _context.Characters.FindAsync(addSkillDto.CharacterId);
            if(character==null) return NotFound("Character not found!");

            var skill = new Skill{
                Name = addSkillDto.Name,
                Damage = addSkillDto.Damage,
            };

            character.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return Ok(
                _mapper.Map<CharacterDto>(
                    await _context.Characters
                        .Where(c => c.Id == character.Id)
                        .Include(c => c.Weapon)
                        .Include(c => c.Skills)
                        .Include(c => c.User)
                        .FirstOrDefaultAsync()
                )
            );
        }
    }
}
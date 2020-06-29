using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Commander.Data;
using Commander.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoMapperController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AutoMapperController(IMapper mapper, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CommandReadDto> Index()
        {
            var command = _context.Commands.Find(1);

            // var dto = _mapper.ProjectTo<CommandReadDto>(_context.Commands).ToList();
            var dto = _context.Commands.ProjectTo<CommandReadDto>(_mapper.ConfigurationProvider).ToList();

            // var dto = _mapper.Map<CommandReadDto>(command);

            return Ok(dto);
        }
    }
}
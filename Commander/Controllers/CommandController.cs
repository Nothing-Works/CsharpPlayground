using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ICommanderRepo _repo;
        private readonly IMapper _mapper;

        public CommandController(ICommanderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> Index()
        {
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(_repo.Index()));
        }

        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> Show(int id)
        {
            var command = _repo.Show(id);

            if (command is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> Store(CommandCreateDto createDto)
        {
            var command = _mapper.Map<Command>(createDto);
            _repo.Store(command);
            _repo.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(command);

            return CreatedAtAction(nameof(Show), new { id = commandReadDto.Id }, commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, CommandUpdateDto updateDto)
        {
            var command = _repo.Show(id);

            if (command is null)
            {
                return NotFound();
            }

            _mapper.Map(updateDto, command);

            _repo.Update(command);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult Patch(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var command = _repo.Show(id);

            if (command is null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(command);

            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(commandToPatch, command);
            _repo.Update(command);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var command = _repo.Show(id);

            if (command is null)
            {
                return NotFound();
            }
            _repo.Delete(command);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}
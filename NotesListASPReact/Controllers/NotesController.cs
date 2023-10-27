using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NotesListASPReact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<NoteDTO>> GetByIdAsync(int id)
        {
            return Ok(_noteService.GetNote(id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetAllAsync()
        {
            return Ok(await _noteService.GetAllNotesAsync());
        }

        [HttpPost("CreateNote")]
        public async Task<ActionResult> CreateNote(NoteDTO noteDTO)
        {
            _noteService.CreateNote(noteDTO);
            return Ok();
        }

        [HttpDelete("DeleteNote")]
        public async Task<ActionResult> DeleteNodeAsync(NoteDTO noteDTO)
        {
            if (noteDTO.Id == null) return BadRequest();
            _noteService.RemoveNote(noteDTO.Id);
            return Ok();
        }

        [HttpPut("UpdateNote")]
        public async Task<ActionResult> UpdateNoteAsync(NoteDTO noteDTO)
        {
            if (noteDTO.Id == null) return BadRequest();
            _noteService.UpdateNote(noteDTO);
            return Ok();
        }
    }
}

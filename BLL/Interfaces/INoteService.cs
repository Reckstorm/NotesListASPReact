using BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INoteService
    {
        void CreateNote(NoteDTO noteDto);
        void UpdateNote(NoteDTO noteDto);
        NoteDTO GetNote(int? id);
        Task<ActionResult<IEnumerable<NoteDTO>>> GetAllNotesAsync();
        void RemoveNote(int? id);
        void Dispose();
    }
}

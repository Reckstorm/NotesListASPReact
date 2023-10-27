using BLL.DTO;
using BLL.Interfaces;
using DAL.EF;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NoteService : INoteService
    {
        NotesContext Database { get; set; }

        public NoteService(NotesContext database)
        {
            Database = database;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public NoteDTO GetNote(int? id)
        {
            if (id == null) return new NoteDTO();
            Note note = Database.Notes.FirstOrDefault(x => x.Id.Equals(id));
            return new NoteDTO() { Id = note.Id, Title = note.Title, Description = note.Description };
        }

        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetAllNotesAsync()
        {
            List<NoteDTO> notes = new List<NoteDTO>();
            if (Database.Notes == null) return notes;
            await Database.Notes.ForEachAsync(x => notes.Add(new NoteDTO(x)));
            return notes;
        }

        public void CreateNote(NoteDTO noteDto)
        {
            Database.Notes.Attach(new Note() { Title = noteDto.Title, Description = noteDto.Description, Created = DateTime.Now }).State = EntityState.Added;
            Database.SaveChanges();
        }

        public void UpdateNote(NoteDTO noteDto)
        {
            if (noteDto.Id == null) return;
            Note temp = Database.Notes.FirstOrDefaultAsync(x => x.Id.Equals(noteDto.Id)).Result;
            temp.Title = noteDto.Title;
            temp.Description = noteDto.Description;
            Database.Notes.Attach(temp).State = EntityState.Modified;
            Database.SaveChanges();
        }

        public void RemoveNote(int? id)
        {
            if (id == 0) return;
            Note temp = Database.Notes.FirstOrDefaultAsync(x => x.Id.Equals(id)).Result;
            Database.Notes.Attach(temp).State = EntityState.Deleted;
            Database.SaveChanges();
        }
    }
}

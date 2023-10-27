using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class NoteDTO
    {
        public NoteDTO()
        {
            Id = 0;
            Title = string.Empty;
            Description = string.Empty;
        }
        public NoteDTO(Note note)
        {
            Id = note.Id;
            Title = note.Title;
            Description = note.Description;
        }
        public NoteDTO(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

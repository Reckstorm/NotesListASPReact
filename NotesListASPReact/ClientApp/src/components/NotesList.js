import { useEffect, useState } from 'react';
import axios from 'axios';
import * as React from 'react';
import 'bootstrap/dist/css/bootstrap.css';

function NotesList(props) {
    const [notes, setNotes] = useState([]);
    const [currentNote, setCurrentNote] = useState(null);

    function getAllNotes() {
        axios.get(`api/Notes/GetAll`)
            .then(res => {
                setNotes(res.data.value);
                const temp = (notes.find(note => note.title === '') || notes[0]);
                setCurrentNote(temp);
                console.log(currentNote);
            })
    }

    function createNote() {
        axios({
            method: 'post',
            url: 'api/Notes/CreateNote',
            data: {
                Id: 0,
                Title: '',
                Description: ''
            }
        })
        getAllNotes();
    }

    function updateNote() {
        axios({
            method: 'put',
            url: 'api/Notes/UpdateNote',
            data: {
                Id: currentNote.id,
                Title: currentNote.title,
                Description: currentNote.description
            }
        })
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    function deleteNote() {
        axios({
            method: 'delete',
            url: 'api/Notes/DeleteNote',
            data: {
                Id: currentNote.id,
                Title: currentNote.title,
                Description: currentNote.description
            }
        })
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    useEffect(getAllNotes, []);

    function handleClick(e) {
        console.log(notes.find(n => n.id == e.target.getAttribute('noteid')));
        setCurrentNote(notes.find(n => n.id == e.target.getAttribute('noteid')));
    }

    console.log(currentNote);
    return (
        <div className="container d-flex p-2 d-flex justify-content-evenly">
            <div className="d-flex p-2 d-flex justify-content-center flex-column" >
                <button className="btn btn-primary m-1" onClick={createNote}>Create note</button>
                <ul>
                    {notes.map(note => <li className="border border-2 rounded mx-auto p-2 m-1" noteid={note.id} key={note.id}
                        onClick={handleClick}>{note.title}</li>)}
                </ul>
            </div>
            <div>
                <div className="d-flex p-2 d-flex justify-content-center flex-column" >
                    <div className="input-group mb-3">
                        <span className="input-group-text" id="basic-addon1">Title</span>
                        <input type="text"
                            className="form-control"
                            placeholder="Title Placeholder"
                            aria-label="Title"
                            aria-describedby="basic-addon1"
                            onChange={e => {
                                setCurrentNote({
                                    ...currentNote,
                                    title: e.target.value
                                });
                            }
                            }
                            value={currentNote == null ? '' : currentNote.title}></input>
                    </div>
                    <div className="input-group">
                        <span className="input-group-text">Text </span>
                        <textarea className="form-control"
                            aria-label="Text"
                            onChange={e => {
                                setCurrentNote({
                                    ...currentNote,
                                    description: e.target.value
                                });
                            }
                            }
                            value={currentNote == null ? '' : currentNote.description}></textarea>
                    </div>
                    <div className="d-flex justify-content-between mt-3">
                        <button className="btn btn-primary" onClick={deleteNote}>Remove Note</button>
                        <button className="btn btn-primary" onClick={updateNote}>Save</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default NotesList;
import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import NotesList from './components/NotesList';
import Note from './components/Note';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
       <NotesList></NotesList>
    );
  }
}

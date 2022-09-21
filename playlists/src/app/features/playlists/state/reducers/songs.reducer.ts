import { createReducer } from '@ngrx/store';

export interface SongEntity {
  id: string;
  title: string;
  artist: string;
  album?: string;
}

export interface SongState {
  songs: SongEntity[];
}

const initialState: SongState = {
  songs: [{ id: '1', title: "Love's Holiday", artist: 'Earth Wind and Fire' }],
};

export const reducer = createReducer(initialState);

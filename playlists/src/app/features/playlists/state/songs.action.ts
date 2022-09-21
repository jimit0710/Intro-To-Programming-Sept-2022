import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { SongCreate } from '../models';

export const SongEvents = createActionGroup({
  source: 'playlists songs events',
  events: {
    added: props<{ payload: SongCreate }>(),
    addedToPlayList: props<{ payload: { id: string } }>(),
    titleChangeRequested: props<{ payload: { id: string } }>(),
  },
});

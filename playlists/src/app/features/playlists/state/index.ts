import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';
import { SongListModel } from '../models';
import * as fromSongs from './reducers/songs.reducer';
import * as fromSongSorter from './reducers/song-sorter.reducer';
export const FEATURE_NAME = 'playlists';

// describe the state of this feature for typescript

export interface PlaylistsState {
  songList: fromSongs.SongState;
  songSort: fromSongSorter.SongSorterState;
}

export const reducers: ActionReducerMap<PlaylistsState> = {
  songList: fromSongs.reducer,
  songSort: fromSongSorter.reducer,
};

// 1. Create a Feature Selector
const selectFeature = createFeatureSelector<PlaylistsState>(FEATURE_NAME);

// 2. A selector per "branch" of the feature state
const selectSongListBranch = createSelector(selectFeature, (f) => f.songList);
const selectSongSortBranch = createSelector(selectFeature, (f) => f.songSort);
// 3. Any "Helpers" (optional)

const { selectAll: selectSongListEntities } =
  fromSongs.adapter.getSelectors(selectSongListBranch);

// 4. The exported selectors that our components need:

// TODO: We need a function that returns the SongListModel

export const selectSortingBy = createSelector(
  selectSongSortBranch,
  (b) => b.sortBy
);
export const selectSongListModel = createSelector(
  selectSongListEntities,
  (songs) =>
    ({
      data: songs,
    } as SongListModel)
);

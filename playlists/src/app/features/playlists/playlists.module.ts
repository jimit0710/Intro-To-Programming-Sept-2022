import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlaylistsComponent } from './playlists.component';
import { RouterModule, Routes } from '@angular/router';
import { SongListComponent } from './components/song-list/song-list.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { OverviewComponent } from './components/overview/overview.component';

const routes: Routes = [
  {
    path: '',
    component: PlaylistsComponent,
    children: [
      {
        path: 'overview',
        component: OverviewComponent,
      },

      {
        path: 'songs',
        component: SongListComponent,
      },
      {
        path: '**',
        redirectTo: 'overview',
      },
    ],
  },
];
@NgModule({
  declarations: [
    PlaylistsComponent,
    SongListComponent,
    NavigationComponent,
    OverviewComponent,
  ],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PlaylistsModule {}
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { SongSummaryModel } from '../../models';

@Component({
  selector: 'app-songs-summary',
  templateUrl: './songs-summary.component.html',
  styleUrls: ['./songs-summary.component.css'],
})
export class SongsSummaryComponent {
  model$!: Observable<SongSummaryModel>; // add some code here.
  constructor(private store: Store) {}
}

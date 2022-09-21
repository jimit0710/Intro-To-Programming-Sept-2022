import { Injectable } from '@angular/core';
import { Actions, createEffect } from '@ngrx/effects';
import { tap } from 'rxjs';
@Injectable()
export class SongEffects {
  // the effect sees EVERY action that has been dispatched.
  // usually an effect turns one action into another action.
  loadSongs$ = createEffect(
    () => {
      return this.actions$.pipe(tap((a) => console.log(a.type)));
    },
    { dispatch: false }
  );

  // We are going to need an action that says "when the featureentered -> (go to the api) -> songs"
  constructor(private actions$: Actions) {}
}

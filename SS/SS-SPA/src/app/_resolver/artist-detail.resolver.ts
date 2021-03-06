import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Artist } from '../_models/artist';
import { ArtistApiService } from '../_services/artist.service/artist.api.service';
import { AlertifyService } from '../_services/alertify.service/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ArtistDetailResolver implements Resolve<Artist> {
  constructor(
    private _artistApi: ArtistApiService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Artist> {
    return this._artistApi.Get(route.params['id']).pipe(
      catchError((error) => {
        this.alertify.error('Problem retrieving data');
        this.router.navigate(['/artist']);
        return of(null);
      })
    );
  }
}

import { Injectable } from '@angular/core';
import { environment as env } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from 'src/app/_models/user';
import { Observable, EMPTY } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { UsState } from 'src/app/_models/usState';
import { Country } from 'src/app/_models/country';
import { UsCity } from 'src/app/_models/usCity';
import { UsZipCode } from 'src/app/_models/usZipCode';

@Injectable({
  providedIn: 'root',
})
export class UtilityApiService {
  constructor(private http: HttpClient) {}

  ListCountries() {
    const url = `${env.apiUrl}/${env.utilityListCountries}`;
    return this.http.get<Country[]>(url).pipe(
      catchError((error) => {
        console.log(error);
        return EMPTY;
      })
    );
  }

  ListUsStates() {
    const url = `${env.apiUrl}/${env.utilityListUsStates}`;
    return this.http.get<UsState[]>(url).pipe(
      catchError((error) => {
        console.log(error);
        return EMPTY;
      })
    );
  }

  ListUSStateCities(usStateId: number) {
    const url = `${env.apiUrl}/${env.utilityListUsStateCities}`;
    return this.http.get<UsCity[]>(`${url}/${usStateId}`).pipe(
      catchError((error) => {
        console.log(error);
        return EMPTY;
      })
    );
  }

  ListUSZipCodes(usCityId: number) {
    const url = `${env.apiUrl}/${env.utilityListZipCodes}`;
    return this.http.get<UsZipCode[]>(`${url}/${usCityId}`).pipe(
      catchError((error) => {
        console.log(error, url, 'usCityId:', usCityId);
        return EMPTY;
      })
    );
  }
}

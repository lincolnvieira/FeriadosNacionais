import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { NationalHoliday } from './models/national-holiday';

@Injectable({
  providedIn: "root"
})
export class NationalHolidayService {

  baseUrl = "https://localhost:44346/api/NationalHoliday/";

  constructor(private httpClient: HttpClient) { }

  getAllNationalHolidays(): Observable<NationalHoliday[]>  {
    return this.httpClient.get<NationalHoliday[]>(this.baseUrl + "GetAllNationalHoliday")
    .pipe(
      catchError(this.handleError)
    );
  }

  getNationalHoliday(id: number): Observable<NationalHoliday>  {
    return this.httpClient.get<NationalHoliday>(this.baseUrl + "GetNationalHoliday/" + id)
    .pipe(
      catchError(this.handleError)
    );
  }

  updateNationalHoliday(nationalHoliday: NationalHoliday){
    return this.httpClient.post(this.baseUrl + "UpdateNationalHoliday", nationalHoliday)
      .pipe(
        catchError(this.handleError)
      );
  };

  deleteNationalHoliday(id: string){
    return this.httpClient.delete(this.baseUrl + "DeleteNationalHoliday/" + id)
      .pipe(
        catchError(this.handleError)
      );
  };

  resetNationalHoliday(){
    return this.httpClient.post(this.baseUrl + "ResetOriginalDataHolidays", null)
      .pipe(
        catchError(this.handleError)
      );
  };

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('Um erro aconteceu:', error.error);
    } 
    else {
      console.error(`O servidor retornou o status code ${error.status}, erro: `, error.error);
    }
    return throwError(() => new Error('Algum erro aconteceu. Tente novamente mais tarde'));
  }
}

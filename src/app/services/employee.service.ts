import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService implements Resolve<any> {
  private url = `${environment.baseUrl}`;
  httpOptions = {
    headers: new HttpHeaders({
      'Access-Control-Allow-Origin': '*'    })
  }
  /**
   * Constructor
   *
   * @param {HttpClient} _httpClient
   */
  constructor(private _httpClient: HttpClient) { 

  }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    throw new Error('Method not implemented.');
  }

  getEmployees(): Observable<[]> {
    let headers = new HttpHeaders().set('Access-Control-Allow-Origin', '*')
    return this._httpClient.get<[]>(this.url + "Employee/GetEmployee",  { headers: headers});
  }

  deleteEmployee(employeeId: number): Observable<[]> {
    let headers = new HttpHeaders().set('Access-Control-Allow-Origin', '*')
    return this._httpClient.get<[]>(this.url + "Employee/DeleteEmployee?id=" + employeeId,  { headers: headers});
  }

  addEmployee(employee: any): Observable<string> {
    let headers = new HttpHeaders().set('Access-Control-Allow-Origin', '*')
    const requestOptions = {
      headers: headers,
      responseType: 'text' as 'json',
    };
    return this._httpClient.post<string>(this.url + "Employee/AddEmployee",employee,  requestOptions);
  }

  errorHandler(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }

}

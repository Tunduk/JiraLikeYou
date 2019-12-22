import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, publishReplay, refCount, share } from "rxjs/operators";
import { environment } from "../../environments/environment";


export class HttpService {

  protected readonly baseUrl: string;

  constructor(protected readonly http: HttpClient, baseMethod: string) {
    this.baseUrl = environment.apiUrl+baseMethod;
  }

  protected getText(path: string = ''): Observable<string> {
    return this.http
      .get(this.baseUrl + path, { 'responseType': "text" })
  }

  protected get<T>(path: string = '', shared: boolean = false): Observable<T> {
    return this.http.get<T>(this.baseUrl + path)
  }

  protected getById<T>(id: number, path: string = ''): Observable<T> {
    return this.http.get<T>(this.baseUrl + path + id);
  }

  protected delete(id: number): Observable<boolean> {
    let request = this.http.delete<boolean>(this.baseUrl + id)
     
    return request;
  }

  protected put<T>(id: number, payload: any): Observable<T> {
    return this.http
      .put<T>(this.baseUrl + id, payload)
  }

  protected putWithPath<T>(id: number, path: string = ''): Observable<T> {
    return this.http
      .put<T>(this.baseUrl + path + id, null)
  }

  protected putWithPathAndPayload<T>(id: number, path: string = '', payload: any): Observable<T> {
    return this.http
      .put<T>(this.baseUrl + path + id, payload)
  }

  protected post<T>(payload: any, path: string = ''): Observable<T> {
    return this.http
      .post<T>(this.baseUrl + path, payload)
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { UserRequestDTO } from '../models/user-request.dto';
import { UserResponseDTO } from '../models/user-response.dto';
import { BaseFilter } from '../models/base-filter';
import { UserFilter } from '../models/user-filter';

@Injectable({ providedIn: 'root' })
export class UserService {
  private apiUrl = `${environment.apiUrl}/User`;

  constructor(private http: HttpClient) {}

  getUsers(filter: BaseFilter<UserFilter>): Observable<UserResponseDTO[]> {
    return this.http.post<UserResponseDTO[]>(`${this.apiUrl}/GetUsers`, filter);
  }

  getById(id: number): Observable<UserResponseDTO> {
    return this.http.get<UserResponseDTO>(`${this.apiUrl}/GetById/${id}`);
  }

  create(dto: UserRequestDTO): Observable<any> {
    return this.http.post(`${this.apiUrl}/Create`, dto);
  }

  update(id: number, dto: UserRequestDTO): Observable<any> {
    return this.http.put(`${this.apiUrl}/Update/${id}`, dto);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/Delete/${id}`);
  }
}

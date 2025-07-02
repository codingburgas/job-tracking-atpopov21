import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { JobApplicationRequestDTO } from '../models/job-application-request.dto';
import { JobApplicationResponseDTO } from '../models/job-application-response.dto';

@Injectable({ providedIn: 'root' })
export class JobApplicationService {
  private apiUrl = `${environment.apiUrl}/JobApplication`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<JobApplicationResponseDTO[]> {
    return this.http.get<JobApplicationResponseDTO[]>(`${this.apiUrl}/GetAll`);
  }

  getByUser(userId: number): Observable<JobApplicationResponseDTO[]> {
    return this.http.get<JobApplicationResponseDTO[]>(`${this.apiUrl}/GetByUser/${userId}`);
  }

  getById(id: number): Observable<JobApplicationResponseDTO> {
    return this.http.get<JobApplicationResponseDTO>(`${this.apiUrl}/GetById/${id}`);
  }

  create(dto: JobApplicationRequestDTO): Observable<any> {
    return this.http.post(`${this.apiUrl}/Create`, dto);
  }

  updateStatus(id: number, status: string): Observable<any> {
    return this.http.put(`${this.apiUrl}/UpdateStatus/${id}?status=${status}`, {});
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/Delete/${id}`);
  }
}

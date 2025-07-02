import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { JobAdRequestDTO} from '../models/job-ad-request.dto';
import { JobAdResponseDTO } from '../models/job-ad-response.dto';

@Injectable({ providedIn: 'root' })
export class JobAdService {
  private apiUrl = `${environment.apiUrl}/JobAd`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<JobAdResponseDTO[]> {
    return this.http.get<JobAdResponseDTO[]>(`${this.apiUrl}/GetAll`);
  }

  getById(id: number): Observable<JobAdResponseDTO> {
    return this.http.get<JobAdResponseDTO>(`${this.apiUrl}/GetById/${id}`);
  }

  create(dto: JobAdRequestDTO): Observable<any> {
    return this.http.post(`${this.apiUrl}/Create`, dto);
  }

  update(id: number, dto: JobAdRequestDTO): Observable<any> {
    return this.http.put(`${this.apiUrl}/Update/${id}`, dto);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/Delete/${id}`);
  }
}

import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ShipmentDto {
  id: string;
  originCity: string;
  originCountry: string;
  destinationCity: string;
  destinationCountry: string;
  weightTons: number;
  cargoDescription: string;
  status: string;
  createdAt: string;
}

export interface CreateShipmentDto {
  shipperId: string;
  originLandmark: string;
  originCity: string;
  originCountry: string;
  destinationLandmark: string;
  destinationCity: string;
  destinationCountry: string;
  weightTons: number;
  cargoDescription: string;
  requiredVehicleType: string;
}

@Injectable({ providedIn: 'root' })
export class ShipmentService {
  private http = inject(HttpClient);
  private baseUrl = 'http://localhost:5264/api';

  getPendingShipments(): Observable<ShipmentDto[]> {
    return this.http.get<ShipmentDto[]>(`${this.baseUrl}/shipments/pending`);
  }

  createShipment(data: CreateShipmentDto): Observable<{ id: string }> {
    return this.http.post<{ id: string }>(`${this.baseUrl}/shipments`, data);
  }
}

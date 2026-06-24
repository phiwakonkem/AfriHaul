import { Component, inject, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { HttpClient } from '@angular/common/http';

interface Carrier {
  id: string;
  fullName: string;
  email: string;
  country: string;
  rating: number;
  isVerified: boolean;
}

@Component({
  selector: 'app-carrier-list',
  standalone: true,
  templateUrl: './carrier-list.html',
  styleUrl: './carrier-list.scss'
})
export class CarrierList {
  carriers = signal<Carrier[]>([]);
  loading = signal(true);
}
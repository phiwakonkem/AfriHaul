import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  {
    path: 'dashboard',
    loadComponent: () => import('./features/dashboard/dashboard/dashboard').then(m => m.Dashboard)
  },
  {
    path: 'shipments',
    loadComponent: () => import('./features/shipments/shipment-list/shipment-list').then(m => m.ShipmentList)
  },
  {
    path: 'shipments/create',
    loadComponent: () => import('./features/shipments/create-shipment/create-shipment').then(m => m.CreateShipment)
  },
  {
    path: 'carriers',
    loadComponent: () => import('./features/carriers/carrier-list/carrier-list').then(m => m.CarrierList)
  }
];

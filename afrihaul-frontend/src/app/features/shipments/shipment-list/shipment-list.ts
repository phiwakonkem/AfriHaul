import { Component, inject, OnInit, signal, computed } from '@angular/core';
import { RouterLink } from '@angular/router';
import { DatePipe } from '@angular/common';
import { ShipmentService, ShipmentDto } from '../../../core/services/shipment';

@Component({
  selector: 'app-shipment-list',
  standalone: true,
  imports: [RouterLink, DatePipe],
  templateUrl: './shipment-list.html',
  styleUrl: './shipment-list.scss'
})
export class ShipmentList implements OnInit {
  private shipmentService = inject(ShipmentService);
  shipments = signal<ShipmentDto[]>([]);
  loading = signal(true);
  activeStatus = signal('All');
  statuses = ['All', 'Pending', 'Matched', 'InTransit', 'Delivered'];

  filteredShipments = computed(() => {
    if (this.activeStatus() === 'All') return this.shipments();
    return this.shipments().filter(s => s.status === this.activeStatus());
  });

  ngOnInit() {
    this.shipmentService.getPendingShipments().subscribe({
      next: (data) => { this.shipments.set(data); this.loading.set(false); },
      error: () => this.loading.set(false)
    });
  }

  getStatusColor(status: string): string {
    const colors: Record<string, string> = {
      'Pending': 'bg-amber-900 text-amber-300',
      'Matched': 'bg-blue-900 text-blue-300',
      'InTransit': 'bg-violet-900 text-violet-300',
      'Delivered': 'bg-emerald-900 text-emerald-300',
      'Cancelled': 'bg-rose-900 text-rose-300'
    };
    return colors[status] || 'bg-gray-800 text-gray-300';
  }
}
import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ShipmentService, ShipmentDto } from '../../../core/services/shipment';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss'
})
export class Dashboard implements OnInit {
  private shipmentService = inject(ShipmentService);
  shipments = signal<ShipmentDto[]>([]);
  loading = signal(true);

  ngOnInit() {
    this.shipmentService.getPendingShipments().subscribe({
      next: (data) => {
        this.shipments.set(data);
        this.loading.set(false);
      },
      error: () => this.loading.set(false)
    });
  }
}

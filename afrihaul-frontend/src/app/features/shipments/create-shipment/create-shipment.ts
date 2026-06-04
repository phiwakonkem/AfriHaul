import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ShipmentService } from '../../../core/services/shipment';

@Component({
  selector: 'app-create-shipment',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './create-shipment.html',
  styleUrl: './create-shipment.scss'
})
export class CreateShipment {
  private fb = inject(FormBuilder);
  private shipmentService = inject(ShipmentService);
  private router = inject(Router);

  submitting = signal(false);
  error = signal('');

  vehicleTypes = [
    'Bakkie', 'LightTruck', 'FlatbedTruck',
    'ReeferTruck', 'Interlink', 'TankerTruck', 'ContainerTruck'
  ];

  countries = [
    'ZA', 'ZW', 'ZM', 'BW', 'NA', 'MZ',
    'TZ', 'KE', 'UG', 'RW', 'NG', 'GH', 'ET', 'SN'
  ];

  form = this.fb.group({
    shipperId: ['3fa85f64-5717-4562-b3fc-2c963f66afa6', Validators.required],
    originLandmark: ['', Validators.required],
    originCity: ['', Validators.required],
    originCountry: ['ZA', Validators.required],
    destinationLandmark: ['', Validators.required],
    destinationCity: ['', Validators.required],
    destinationCountry: ['', Validators.required],
    weightTons: [1, [Validators.required, Validators.min(0.1)]],
    cargoDescription: ['', Validators.required],
    requiredVehicleType: ['FlatbedTruck', Validators.required]
  });

  onSubmit() {
    if (this.form.invalid) return;
    this.submitting.set(true);
    this.error.set('');

    this.shipmentService.createShipment(this.form.value as any).subscribe({
      next: () => this.router.navigate(['/dashboard']),
      error: (err) => {
        this.error.set('Failed to create shipment. Please try again.');
        this.submitting.set(false);
      }
    });
  }
}
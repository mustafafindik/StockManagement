/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { VatRateService } from './vatRate.service';

describe('Service: VatRate', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VatRateService]
    });
  });

  it('should ...', inject([VatRateService], (service: VatRateService) => {
    expect(service).toBeTruthy();
  }));
});

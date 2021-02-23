import { TestBed } from '@angular/core/testing';

import { NetResultService } from './net-result.service';

describe('NetResultService', () => {
  let service: NetResultService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NetResultService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

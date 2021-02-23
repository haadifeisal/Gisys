import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultansComponent } from './consultans.component';

describe('ConsultansComponent', () => {
  let component: ConsultansComponent;
  let fixture: ComponentFixture<ConsultansComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultansComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultansComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

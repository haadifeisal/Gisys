import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateNetresultComponent } from './update-netresult.component';

describe('UpdateNetresultComponent', () => {
  let component: UpdateNetresultComponent;
  let fixture: ComponentFixture<UpdateNetresultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateNetresultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateNetresultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

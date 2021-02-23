import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SetNetresultComponent } from './set-netresult.component';

describe('SetNetresultComponent', () => {
  let component: SetNetresultComponent;
  let fixture: ComponentFixture<SetNetresultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SetNetresultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SetNetresultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

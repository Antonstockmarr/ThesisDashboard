import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckboxLineComponent } from './checkbox-line.component';

describe('CheckboxLineComponent', () => {
  let component: CheckboxLineComponent;
  let fixture: ComponentFixture<CheckboxLineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CheckboxLineComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckboxLineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InoutExcelComponent } from './inout-excel.component';

describe('InoutExcelComponent', () => {
  let component: InoutExcelComponent;
  let fixture: ComponentFixture<InoutExcelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InoutExcelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InoutExcelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

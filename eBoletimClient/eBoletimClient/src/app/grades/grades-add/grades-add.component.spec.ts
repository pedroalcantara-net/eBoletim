import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradesAddComponent } from './grades-add.component';

describe('GradesAddComponent', () => {
  let component: GradesAddComponent;
  let fixture: ComponentFixture<GradesAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GradesAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GradesAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

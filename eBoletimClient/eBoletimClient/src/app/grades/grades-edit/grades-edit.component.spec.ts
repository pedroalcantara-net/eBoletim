import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradesEditComponent } from './grades-edit.component';

describe('GradesEditComponent', () => {
  let component: GradesEditComponent;
  let fixture: ComponentFixture<GradesEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GradesEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GradesEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

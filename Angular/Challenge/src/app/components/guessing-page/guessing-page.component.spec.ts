import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GuessingPageComponent } from './guessing-page.component';

describe('GuessingPageComponent', () => {
  let component: GuessingPageComponent;
  let fixture: ComponentFixture<GuessingPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GuessingPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GuessingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

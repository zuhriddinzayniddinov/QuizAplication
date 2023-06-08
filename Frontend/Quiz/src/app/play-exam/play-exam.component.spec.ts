import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayExamComponent } from './play-exam.component';

describe('PlayExamComponent', () => {
  let component: PlayExamComponent;
  let fixture: ComponentFixture<PlayExamComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PlayExamComponent]
    });
    fixture = TestBed.createComponent(PlayExamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeQuizzesComponent } from './home-quizzes.component';

describe('HomeQuizzesComponent', () => {
  let component: HomeQuizzesComponent;
  let fixture: ComponentFixture<HomeQuizzesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HomeQuizzesComponent]
    });
    fixture = TestBed.createComponent(HomeQuizzesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

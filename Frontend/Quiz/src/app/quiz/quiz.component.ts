import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Quiz } from '../quiz';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent {

  quiz = new Quiz();
  subscription = new Subscription();
  constructor(public apiSvc: ApiService,private router: Router) {

  }

  post() {
    if (this.quiz.id)
      this.apiSvc.putQuiz(this.quiz);
    else
      this.apiSvc.postQuiz(this.quiz);
  }

  resetQuiz() {
    this.quiz = new Quiz();
  }

  ngOnInit(){
    this.subscription = this.apiSvc.getSelectedQuiz().subscribe( q => {
        this.quiz = q;
    });
}
navigateToQuestions(){
  this.router.navigate(['/question/' + this.quiz.id]);
}
ngOnDestroy() {
    this.subscription.unsubscribe();
}
}

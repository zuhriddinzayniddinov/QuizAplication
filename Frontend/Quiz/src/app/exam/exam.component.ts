import { Component } from '@angular/core';
import { Exam } from '../exam';
import { Subscription } from 'rxjs';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.css']
})
export class ExamComponent {
  exam = new Exam();
  quizzes: any;
  subscription = new Subscription();
  constructor(public apiSvc: ApiService,private router: Router) {

  }

  post() {    
      this.apiSvc.postExam(this.exam);
    this.resetExam();
  }

  resetExam() {
    this.exam = new Exam();
  }

  ngOnInit(){
    this.subscription = this.apiSvc.getSelectedExam().subscribe( q => {
        this.exam = q;
    });
    this.apiSvc.getQuizzesAll().subscribe(result => {
      this.quizzes = result;
    });
}
navigateToQuestions(){
  this.router.navigate(['/exam/' + this.exam.id]);
}
ngOnDestroy() {
    this.subscription.unsubscribe();
}
}

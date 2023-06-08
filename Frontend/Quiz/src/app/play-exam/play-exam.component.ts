import { Component, OnInit, forwardRef } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { Question } from '../question';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-play-exam',
  templateUrl: './play-exam.component.html',
  styleUrls: ['./play-exam.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => Question),
      multi: true,
    }
  ]
})
export class PlayExamComponent implements OnInit {
  questions: any;
  examId: number = 1;
  selects: string[] = [];

  constructor(
    public apiSvc: ApiService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.examId = Number(this.route.snapshot.paramMap.get('examid'));
    this.apiSvc.getQuestionsByExam(this.examId).subscribe(result => {
      this.questions = result;

      for (let index = 0; index < this.questions.length; index++) {
        for (const element in this.questions[index]) {
          if (this.questions[index].answerGuid && this.questions[index][element].answerGuid && this.questions[index][element].answerGuid == this.questions[index].answerGuid) {
            this.questions[index].respons = true;
            if (this.questions[index].answer)
              this.questions[index][element].color = 'green';
            else
              this.questions[index][element].color = 'red';
            this.questions[index].processed = true;
          }
        }
      }
    });
    this.apiSvc.getNewQuestion().subscribe(result => {
      this.questions.push(result);
    })
  }

  Bosdi(cheked: any, index: number) {
    for (const element in this.questions[index]) {
      if (this.questions[index][element].answerGuid && this.questions[index][element].answerGuid == cheked.as) {
        this.questions[index].respons = true;
        console.log(this.questions[index].id);

        this.apiSvc
          .answer({ id: 0, examId: this.examId, questionId: this.questions[index].id, answerGuid: cheked.as })
          .subscribe(obj => {
            if (obj)
              this.questions[index][element].color = 'green';
            else
              this.questions[index][element].color = 'red';
            this.questions[index].processed = true;
          });
      }
    }
  }
}
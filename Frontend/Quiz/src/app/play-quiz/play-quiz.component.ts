import { Component, OnInit, forwardRef } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ScoreDialogComponent } from '../score-dialog/score-dialog.component';
import { Answer, Question } from '../question';
import { NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-play-quiz',
  templateUrl: './play-quiz.component.html',
  styleUrls: ['./play-quiz.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => Question),
      multi: true,
    }
  ]
})

export class PlayQuizComponent implements OnInit {
  questions: any;
  quizId: number = 1;
  selects: string[] = [];

  constructor(
    public apiSvc: ApiService,
    private route: ActivatedRoute,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.quizId = Number(this.route.snapshot.paramMap.get('quizid'));
    this.apiSvc.getQuestions(this.quizId).subscribe(result => {
      this.questions = result;
    });
    this.apiSvc.getNewQuestion().subscribe(result => {
      this.questions.push(result);
    })
  }

  Bosdi(cheked: any, index: number) {
    // for (const element in this.questions[index]) {
    //   if (this.questions[index][element].answerGuid && this.questions[index][element].answerGuid == cheked.as) {
    //     this.questions[index].respons = true;
    //     this.apiSvc
    //       .answer({ id: this.questions[index].id, quizId: this.questions[index].quizId, answerGuid: cheked.as })
    //       .subscribe(obj => {
    //         if (obj)
    //           this.questions[index][element].color = 'green';
    //         else
    //           this.questions[index][element].color = 'red';
    //         this.questions[index].processed = true;
    //       });
    //   }
    // }
  }
}
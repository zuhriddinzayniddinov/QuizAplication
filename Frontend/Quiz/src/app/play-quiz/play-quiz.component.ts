import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';
import {MatDialog} from '@angular/material/dialog';
import { ScoreDialogComponent } from '../score-dialog/score-dialog.component';

@Component({
  selector: 'app-play-quiz',
  templateUrl: './play-quiz.component.html',
  styleUrls: ['./play-quiz.component.css']
})
export class PlayQuizComponent implements OnInit {
  
  questions:any;
  quizId: number = 1;
  step = 0;

  constructor(public apiSvc : ApiService,private route:ActivatedRoute,public dialog: MatDialog) {
    
  }

  ngOnInit(){
    this.quizId = Number(this.route.snapshot.paramMap.get('quizid'));
    this.apiSvc.getQuestions(this.quizId).subscribe(result => {
      this.questions = result;
      this.questions.forEach((q: { answers: { display: any; value: boolean; }[]; correctAnswer: any; wrongAnswer1: any; wrongAnswer2: any; wrongAnswer3: any; }) => {
        q.answers =
        [{ display: q.correctAnswer, value: true },
          { display: q.wrongAnswer1, value: false },
          { display: q.wrongAnswer2, value: false },
          { display: q.wrongAnswer3, value: false }];
          this.shuffleAnswers(q.answers);
      });
    });
}

finishTest(){
  let correctAnswer = 0;
  this.questions.forEach((q: { selectedQuestion: any; }) =>{
    if (q.selectedQuestion) {
      correctAnswer++;
    }
  });
  
  const dialogRef = this.dialog.open(ScoreDialogComponent, {
    data: {correctAnswer,totalQuestions: this.questions.length },
  });

  dialogRef.afterClosed().subscribe(result => {
    console.log('The dialog was closed');
  });
}



setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  shuffleAnswers(answers: { display: string, value: boolean }[]): { display: string, value: boolean }[] {
    for (let i = answers.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [answers[i], answers[j]] = [answers[j], answers[i]];
    }
    return answers;
  }
}
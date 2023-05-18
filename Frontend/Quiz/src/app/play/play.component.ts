import { Component } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent {
  quizzes: any;

  constructor(public apiSvc: ApiService) {

  }

  ngOnInit() {
    this.apiSvc.getAllQuizzes().subscribe(result => {
      this.quizzes = result;
    });
  }
}

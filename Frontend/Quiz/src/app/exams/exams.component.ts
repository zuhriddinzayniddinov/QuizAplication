import { Component } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.css']
})
export class ExamsComponent {
  exams:any;
  constructor(public apiSvc:ApiService) {}

  ngOnInit() {
    this.apiSvc.getExams().subscribe(result => {
      this.exams = result;
    });
    this.apiSvc.getNewExam().subscribe(exam => {
      this.exams.push(exam);
  });
  }
}

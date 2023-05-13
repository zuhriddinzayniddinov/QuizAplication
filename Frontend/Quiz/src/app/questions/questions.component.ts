import { Component } from "@angular/core";
import { ApiService } from "../api.service";
import { ActivatedRoute } from "@angular/router";

@Component ({
    templateUrl: './questions.component.html',
    selector: 'questions'
})
export class QuestionsComponent {
    questions:any;
    
    constructor(public apiSvc: ApiService,private router: ActivatedRoute){

    }

    ngOnInit()  {
        this.apiSvc.getQuestions(Number(this.router.snapshot.paramMap.get('quizid'))).subscribe(result => {
            this.questions = result;
        });
        this.apiSvc.getNewQuestion().subscribe(question => {
            this.questions.push(question);
        });
    }
}
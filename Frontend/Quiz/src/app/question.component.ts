import { Component } from "@angular/core";
import { ApiService } from "./api.service";
import { Question } from "./question";
import { Subscription } from "rxjs";
import { ActivatedRoute } from "@angular/router";

@Component ({
    templateUrl: './question.component.html',
    selector: 'question'
})
export class QuestionComponent {
    question = new Question();

    subscription: Subscription = Subscription.EMPTY;
    constructor(private apiSvc: ApiService,private router : ActivatedRoute){

    }
    ngOnInit(){
        this.subscription = this.apiSvc.getSelectedQuestion().subscribe( q => {
            this.question = q;
            this.question.quizid = Number(this.router.snapshot.paramMap.get('quizid'));
            console.log(this.question.quizid);
        });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    post() {
        this.question.quizid = Number(this.router.snapshot.paramMap.get('quizid'));
        if(this.question.id)
            this.apiSvc.putQuestion(this.question);
        else
            this.apiSvc.postQuestion(this.question);

        this.resetQuesttion();
    }

    resetQuesttion() {
        this.question = new Question();
        this.question.quizid = Number(this.router.snapshot.paramMap.get('quizid'));
    }
}
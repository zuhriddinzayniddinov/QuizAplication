import { Component } from "@angular/core";
import { ApiService } from "./api.service";
import { Question } from "./question";
import { Subscription } from "rxjs";

@Component ({
    templateUrl: './question.component.html',
    selector: 'question'
})
export class QuestionComponent {
    question = new Question();

    
    subscription: Subscription = Subscription.EMPTY;
    constructor(private apiSvc: ApiService){

    }
    ngOnInit(){
        this.subscription = this.apiSvc.getSelectedQuestion().subscribe( q => {
            this.question = q;
        });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    post() {
        if(this.question.id)
            this.apiSvc.putQuestion(this.question);
        else
            this.apiSvc.postQuestion(this.question);
    }

    resetQuesttion() {
        this.question = new Question();
    }
}
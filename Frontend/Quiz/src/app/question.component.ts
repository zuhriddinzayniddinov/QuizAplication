import { Component } from "@angular/core";
import { ApiService } from "./api.service";

@Component ({
    templateUrl: './question.component.html',
    selector: 'question'
})
export class QuestionComponent {
    question = {
        text: 'O\'zbekiston poytaxti',
        correctAsnwer:'Toshkent',
        worngAsnwers: ['Samarqand','Navoiy','Andijon'],
        stringworngAsnwers:''
    };

    constructor(private apiSvc: ApiService){

    }

    post() {
        this.apiSvc.postQuestion(this.question);
    }
}
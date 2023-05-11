import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { Subject } from 'rxjs';
import { Question } from './question';
 
@Injectable()
export class ApiService {
    private selectedQuestion = new Subject<Question>();

    selectQuestion(question : Question) {
        this.selectedQuestion.next(question);
    }

    getSelectedQuestion(){
        return this.selectedQuestion.asObservable();
    }

    constructor(private http: HttpClient){}
    postQuestion(question: Question){
        this.http.post('https://localhost:44315/api/Question',question)
            .subscribe(response => {
                console.log(response);
            });
    }
    putQuestion(question: Question){
        this.http.put('https://localhost:44315/api/Question/' + question.id,question)
            .subscribe(response => {
                console.log(response);
            });
    }
    getQuestions(){
        return this.http.get('https://localhost:44315/api/Question');
    }
}
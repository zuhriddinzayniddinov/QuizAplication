import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Subject } from 'rxjs';
import { Question } from './question';
import { Quiz } from './quiz';

@Injectable()
export class ApiService {
    private selectedQuestion = new Subject<Question>();
    private selectedQuiz = new Subject<Quiz>();
    constructor(private http: HttpClient) { }

    selectQuestion(question: Question) {
        this.selectedQuestion.next(question);
    }

    selectQuiz(quiz: Quiz) {
        this.selectedQuiz.next(quiz);
    }

    getSelectedQuestion() {
        return this.selectedQuestion.asObservable();
    }

    getSelectedQuiz() {
        return this.selectedQuiz.asObservable();
    }

    postQuestion(question: Question) {
        this.http.post('https://localhost:44315/api/Question', question)
            .subscribe(response => {
                console.log(response);
            });
    }
    putQuestion(question: Question) {
        this.http.put('https://localhost:44315/api/Question/' + question.id, question)
            .subscribe(response => {
                console.log(response);
            });
    }
    getQuestions() {
        return this.http.get('https://localhost:44315/api/Question');
    }

    getQuizzes() {
        return this.http.get('https://localhost:44315/api/Quizzes');
    }

    postQuiz(quiz: Quiz) {
        this.http.post('https://localhost:44315/api/quizzes', quiz)
            .subscribe(response => {
                console.log(response);
            });
    }
    
    putQuiz(quiz: Quiz) {
        this.http.put('https://localhost:44315/api/quizzes/' + quiz.id, quiz)
            .subscribe(response => {
                console.log(response);
            });
    }
}
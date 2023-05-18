import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Subject } from 'rxjs';
import { Question } from './question';
import { Quiz } from './quiz';

@Injectable()
export class ApiService {
    private selectedQuestion = new Subject<Question>();
    private addQuestion = new Subject<Question>();
    private selectedQuiz = new Subject<Quiz>();
    private addQuiz = new Subject<Quiz>();

    constructor(private http: HttpClient) { }

    getNewQuestion() {
        return this.addQuestion.asObservable();
    }

    addNewQuestion(question:Question) {
        return this.addQuestion.next(question);
    }

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

    getNewQuiz() {
        return this.addQuiz.asObservable();
    }

    addNewQuiz(quiz:Quiz) {
        return this.addQuiz.next(quiz);
    }

    postQuestion(question: Question) {
        this.http.post('https://localhost:44315/api/Question', question)
            .subscribe(response => {
                this.addNewQuestion(response as Question);
                console.log(response);
            });
    }
    putQuestion(question: Question) {
        this.http.put('https://localhost:44315/api/Question/' + question.id, question)
            .subscribe(response => {
                console.log(response);
            });
    }

    getQuestions(quizId:number) {
        return this.http.get('https://localhost:44315/api/Question/'+quizId);
    }

    getQuizzes() {
        return this.http.get('https://localhost:44315/api/Quizzes');
    }

    postQuiz(quiz: Quiz) {
        this.http.post('https://localhost:44315/api/quizzes', quiz)
            .subscribe(response => {
                this.addNewQuiz(response as Quiz);
                console.log(response);
            });
    }

    getAllQuizzes(){
        return this.http.get('https://localhost:44315/api/Quizzes/All');
    }

    putQuiz(quiz: Quiz) {
        this.http.put('https://localhost:44315/api/quizzes/' + quiz.id, quiz)
            .subscribe(response => {
                console.log(response);
            });
    }
}
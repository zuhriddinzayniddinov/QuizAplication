import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable, Subject, map } from 'rxjs';
import { Question } from './question';
import { Quiz } from './quiz';
import { UserMorify } from './admin-edit-user/user';
import { SentReply } from './sentReply';
import { Exam } from './exam';

@Injectable()
export class ApiService {
    private selectedQuestion = new Subject<Question>();
    private addQuestion = new Subject<Question>();
    private selectedQuiz = new Subject<Quiz>();
    private addQuiz = new Subject<Quiz>();
    private selectedExam = new Subject<Exam>();
    private addExam = new Subject<Exam>();

    constructor(private http: HttpClient) { }

    getNewQuestion() {
        return this.addQuestion.asObservable();
    }

    addNewQuestion(question: Question) {
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

    addNewQuiz(quiz: Quiz) {
        return this.addQuiz.next(quiz);
    }
//----------------------------
    selectExam(exam: Exam) {
        this.selectedExam.next(exam);
    }

    addNewExam(exam: Exam) {
        return this.addExam.next(exam);
    }

    getNewExam() {
        return this.addExam.asObservable();
    }

    postExam(exam: Exam) {
        this.http.post('https://localhost:44315/api/Exam/Create', exam)
            .subscribe(response => {
                this.addNewExam(response as Exam);
                console.log(response);
            });
    }

    getSelectedExam() {
        return this.selectedExam.asObservable();
    }

    getExams() {
        return this.http.get('https://localhost:44315/api/Exam');
    }

    getQuestionsByExam(examId: number) {
        return this.http.get('https://localhost:44315/api/Exam/' + examId);
    }
    
    answer(sentReply : SentReply) : Observable<boolean>{

        return this.http.post('https://localhost:44315/api/Exam',sentReply)
        .pipe(
            map(response => {
                return response.toString() == 'true';
            })
        )
    }
//----------------

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

    getQuestions(quizId: number) {
        return this.http.get('https://localhost:44315/api/Question/' + quizId);
    }

    getQuizzes() {
        return this.http.get('https://localhost:44315/api/Quizzes');
    }

    getQuizzesAll() {
        return this.http.get('https://localhost:44315/api/Quizzes/All');
    }

    postQuiz(quiz: Quiz) {
        this.http.post('https://localhost:44315/api/quizzes', quiz)
            .subscribe(response => {
                this.addNewQuiz(response as Quiz);
                console.log(response);
            });
    }

    getAllQuizzes() {
        return this.http.get('https://localhost:44315/api/Quizzes/All');
    }

    getAllUsers() {
        return this.http.get('https://localhost:44315/api/Admin');
    }

    putUser(userMorify: UserMorify) {
        this.http.put('https://localhost:44315/api/Admin', userMorify)
            .subscribe(response => {
                console.log(response);
            });
    }

    getByIdUser(userId: Number) {
        return this.http.get('https://localhost:44315/api/Admin/' + userId);
    }

    putQuiz(quiz: Quiz) {
        this.http.put('https://localhost:44315/api/quizzes/' + quiz.id, quiz)
            .subscribe(response => {
                console.log(response);
            });
    }
}
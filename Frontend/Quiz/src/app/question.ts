export class Question {
    id: number = 0;
    text: string = '';
    answer1: Answer = new Answer();
    answer2: Answer = new Answer();
    answer3: Answer = new Answer();
    answer4: Answer = new Answer();
    quizid: number = 0;
  }
  
export class Answer {
  text: string = '';
  answerGuid: string = '';
}
import 'question.dart';

class QuestionRepository {
  static List<Question> questionSelect(Category question) {
    const allQuestions = <Question> [
      Question(
        questionId: Category.question1,
        question: "Which element is the most reactive?",
        time: 4,
        answer: 'Oxygen',
        options: ['Oxygen', 'Hydrogen', 'Helium', 'Carbon'],
        explained: "I'm pretty sure this is right, it's only a test."
      ),
      Question(
        questionId: Category.question2,
        question: "What smells the best?",
        time: 4,
        answer: 'Lavender',
        options: ['Old Grease', 'Dead Chicken', 'Lavender', 'Skunk Soup'],
        explained: "Lavender do smell pretty darn good",
      ),
      Question(
        questionId: Category.question3,
        question: "Which one's the best answer?",
        time: 4,
        answer: 'Pick this one',
        options: ['Try Again', 'Not this one', 'Nope', 'Pick this one'],
        explained: "I really hope you pressed the right one",
      ),
    ];
    return allQuestions.where((Question q) {
      return q.questionId == question;
    }).toList();
  }
}
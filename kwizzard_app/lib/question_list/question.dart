import 'package:flutter/foundation.dart';

enum Category{question1, question2, question3, question4}

class Question{
  const Question({
    @required this.questionId,
    @required this.question,
    @required this.answer,
    @required this.time,
    @required this.options,
    @required this.explained,
  })  : assert(questionId != null),
        assert(question != null),
        assert(answer != null),
        assert(time != null),
        assert(options != null),
        assert(explained != null);

  final Category questionId;
  final String question;
  final String answer;
  final int time;
  final List options;
  final String explained;

}
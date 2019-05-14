import 'package:flutter/material.dart';
import 'app_build/backdrop.dart';
import 'settings.dart';
import 'landing.dart';
import 'question_list/question.dart';
import 'question_list/question_repository.dart';

class HomePage extends StatelessWidget {
  final Category category;

  const HomePage({this.category});

  @override
  Widget build(BuildContext context) => (category == null)
      ? Backdrop(
          currentCategory: this.category,
          frontLayer: LandingPage(),
          backLayer: SettingsPage(),
          frontTitle: Text('KWIZZARD'),
          backTitle: Text('SETTINGS'),
        )
      : Backdrop(
          currentCategory: this.category,
          frontLayer: LandingPage(
              q: QuestionRepository.questionSelect(this.category),
              cat: this.category),
          backLayer: SettingsPage(),
          frontTitle: Text('KWIZZARD'),
          backTitle: Text('SETTINGS'),
        );
}

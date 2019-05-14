import 'package:flutter/material.dart';
import 'question_list/question.dart';
import 'supplemental/question_view.dart';

class LandingPage extends StatelessWidget {
  final List<Question> q;
  final Category cat;
  const LandingPage({this.q, this.cat});

  @override
  Widget build(BuildContext context) {
    if (q == null) {
      return Scaffold(
        body: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            mainAxisSize: MainAxisSize.max,
            children: <Widget>[
              SizedBox(height: 140.0),
              Text(
                'You have no new questions to answer!',
                style: Theme.of(context).textTheme.display1,
                textAlign: TextAlign.center,
              ),
            ]),
      );
    } else {
      return Scaffold(
        body: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            mainAxisSize: MainAxisSize.min,
            children: <Widget>[
              SizedBox(height: 80.0),
              Padding(
                padding: const EdgeInsets.all(20.0),
                child: Text(
                  'You have a new question!',
                  style: TextStyle(fontSize: 32.0, fontFamily: 'Rubik'),
                  textAlign: TextAlign.center,
                ),
              ),
              SizedBox(
                height: 15.0,
              ),
              Padding(
                padding: const EdgeInsets.all(15.0),
                child: Text(
                  'Tap below to answer it.',
                  style: Theme.of(context).textTheme.title,
                  textAlign: TextAlign.center,
                ),
              ),
              SizedBox(height: 120.0),
              RaisedButton(
                  child: Text('Show it!'),
                  elevation: 8.0,
                  shape: BeveledRectangleBorder(
                    borderRadius: BorderRadius.all(Radius.circular(4.0)),
                  ),
                  onPressed: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => QuestionPage(q: this.q)
                        ));
                  }),
            ]),
      );
    }
  }
}

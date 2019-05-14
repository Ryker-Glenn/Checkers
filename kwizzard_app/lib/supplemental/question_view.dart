import 'package:flutter/material.dart';
import '../question_list/question.dart';
import '../app_build/colors.dart';
import '../home.dart';

class QuestionPage extends StatefulWidget {
  final List<Question> q;
  const QuestionPage({@required this.q}) : assert(q != null);
  @override
  _QuestionPageState createState() => _QuestionPageState();
}

class _QuestionPageState extends State<QuestionPage> {
  String answer, opt0, opt1, opt2, opt3;
  bool locked, press0, press1, press2, press3;
  Color answered = buttonColor;
  Color unanswered = buttonColor;

  @override
  void initState() {
    super.initState();
    answer = widget.q.elementAt(0).answer;
    opt0 = widget.q.elementAt(0).options.elementAt(0);
    opt1 = widget.q.elementAt(0).options.elementAt(1);
    opt2 = widget.q.elementAt(0).options.elementAt(2);
    opt3 = widget.q.elementAt(0).options.elementAt(3);
    locked = false;
    press0 = false;
    press1 = false;
    press2 = false;
    press3 = false;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        mainAxisSize: MainAxisSize.min,
        children: <Widget>[
          SizedBox(height: 100.0),
          Padding(
            padding: const EdgeInsets.all(32.0),
            child: Text(
              widget.q.elementAt(0).question,
              style: Theme.of(context).textTheme.display1,
              textAlign: TextAlign.center,
            ),
          ),
          SizedBox(height: 60.0),
          ButtonTheme(
            minWidth: 180.0,
            height: 50.0,
            child: RaisedButton(
                child: Text(opt0,
                    style: TextStyle(
                        color: Colors.black,
                        fontFamily: 'Rubik',
                        fontSize: 18)),
                color: (!press0) ? unanswered : answered,
                elevation: 8.0,
                shape: BeveledRectangleBorder(
                  borderRadius: BorderRadius.all(Radius.circular(4.0)),
                ),
                onPressed: () {
                  setState(() {
                    if (!locked) {
                      locked = !locked;
                      press0 = !press0;
                      (opt0 == answer)
                          ? answered = correctGreen
                          : answered = siueRed;
                    }
                  });
                }),
          ),
          SizedBox(height: 20.0),
          ButtonTheme(
            minWidth: 180.0,
            height: 50.0,
            child: RaisedButton(
                child: Text(opt1,
                    style: TextStyle(
                        color: Colors.black,
                        fontFamily: 'Rubik',
                        fontSize: 18)),
                color: (!press1) ? unanswered : answered,
                elevation: 8.0,
                shape: BeveledRectangleBorder(
                  borderRadius: BorderRadius.all(Radius.circular(4.0)),
                ),
                onPressed: () {
                  setState(() {
                    if (!locked) {
                      locked = !locked;
                      press1 = !press1;
                      (opt1 == answer)
                          ? answered = correctGreen
                          : answered = siueRed;
                    }
                  });
                }),
          ),
          SizedBox(height: 20.0),
          ButtonTheme(
            minWidth: 180.0,
            height: 50.0,
            child: RaisedButton(
                child: Text(opt2,
                    style: TextStyle(
                        color: Colors.black,
                        fontFamily: 'Rubik',
                        fontSize: 18)),
                color: (!press2) ? unanswered : answered,
                elevation: 8.0,
                shape: BeveledRectangleBorder(
                  borderRadius: BorderRadius.all(Radius.circular(4.0)),
                ),
                onPressed: () {
                  setState(() {
                    if (!locked) {
                      locked = !locked;
                      press2 = !press2;
                      (opt2 == answer)
                          ? answered = correctGreen
                          : answered = siueRed;
                    }
                  });
                }),
          ),
          SizedBox(height: 20.0),
          ButtonTheme(
            minWidth: 180.0,
            height: 50.0,
            child: RaisedButton(
                child: Text(opt3,
                    style: TextStyle(
                        color: Colors.black,
                        fontFamily: 'Rubik',
                        fontSize: 18)),
                color: (!press3) ? unanswered : answered,
                elevation: 8.0,
                shape: BeveledRectangleBorder(
                  borderRadius: BorderRadius.all(Radius.circular(4.0)),
                ),
                onPressed: () {
                  setState(() {
                    if (!locked) {
                      locked = !locked;
                      press3 = !press3;
                      (opt3 == answer)
                          ? answered = correctGreen
                          : answered = siueRed;
                    }
                  });
                }),
          ),
          SizedBox(height: 60.0),
          RaisedButton(
              child: Text('FINISH'),
              elevation: 8.0,
              shape: BeveledRectangleBorder(
                borderRadius: BorderRadius.all(Radius.circular(4.0)),
              ),
              onPressed: () {
                Navigator.pop(context);
                Navigator.pushReplacement(
                  context, 
                  new MaterialPageRoute(builder: (context) => HomePage())
                );
              }),
        ],
      ),
    );
  }
}

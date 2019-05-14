import 'package:flutter/material.dart';
import 'app_build/colors.dart';
import 'home.dart';
import 'login.dart';
import 'question_list/question.dart';
import 'supplemental/cut_corner_border.dart';

class KwizzardApp extends StatefulWidget {
  @override
  KwizzardAppState createState() => KwizzardAppState();
}

class KwizzardAppState extends State<KwizzardApp> {
  Category _currentCategory = Category.question1;

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Kwizzard',
      debugShowCheckedModeBanner: false,
      home: HomePage(
        category: _currentCategory,
      ),
      initialRoute: '/login',
      onGenerateRoute: _getRoute,
      theme: _kwizzardTheme,
    );
  }

  Route<dynamic> _getRoute(RouteSettings settings) {
    if (settings.name != '/login') {
      return null;
    }

    return MaterialPageRoute<void>(
      settings: settings,
      builder: (BuildContext context) => LoginPage(),
      fullscreenDialog: true,
    );
  }
}

final ThemeData _kwizzardTheme = _buildKwizzardTheme();

ThemeData _buildKwizzardTheme() {
  final ThemeData base = ThemeData.dark();
  return base.copyWith(
    accentColor: foreground,
    primaryColor: foreground,
    scaffoldBackgroundColor: foreground,
    cardColor: foreground,
    textSelectionColor: iconsColor,
    errorColor: siueRed,
    buttonTheme: base.buttonTheme.copyWith(
      buttonColor: siueRed,
      textTheme: ButtonTextTheme.normal,
    ),
    primaryIconTheme: base.iconTheme.copyWith(color: iconsColor),
    inputDecorationTheme: InputDecorationTheme(
      border: CutCornersBorder(),
    ),
    textTheme: _buildKwizzardTextTheme(base.textTheme),
    primaryTextTheme: _buildKwizzardTextTheme(base.primaryTextTheme),
    accentTextTheme: _buildKwizzardTextTheme(base.accentTextTheme),
  );
}

TextTheme _buildKwizzardTextTheme(TextTheme base) {
  return base
      .copyWith(
        headline: base.headline.copyWith(
          fontWeight: FontWeight.w500,
        ),
        title: base.title.copyWith(fontSize: 18.0),
        caption: base.caption.copyWith(
          fontWeight: FontWeight.w400,
          fontSize: 14.0,
        ),
        body2: base.body2.copyWith(
          fontWeight: FontWeight.w500,
          fontSize: 16.0,
        ),
      )
      .apply(
        fontFamily: 'Rubik',
        displayColor: text,
        bodyColor: text,
      );
}

import 'package:flutter/material.dart';
import 'app_build/colors.dart';

class SettingsPage extends StatefulWidget {
  @override
  _SettingsPageState createState() => _SettingsPageState();
}

class _SettingsPageState extends State<SettingsPage> {
  bool pushNotific = true;
  bool textNotific = true;
  bool videoSwitch = true;
  bool imageSwitch = true;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        mainAxisAlignment: MainAxisAlignment.start,
        mainAxisSize: MainAxisSize.max,
        children: <Widget>[
          SwitchListTile(
            value: pushNotific,
            onChanged: (value) {
              setState(() {
                pushNotific = value;
              });
            },
            activeTrackColor: siueRed,
            activeColor: Colors.red,
            title: new Text(
              'Send Push Notifications',
              style: Theme.of(context).textTheme.subhead,
            ),
          ),
          SwitchListTile(
            value: textNotific,
            onChanged: (value) {
              setState(() {
                textNotific = value;
              });
            },
            activeTrackColor: siueRed,
            activeColor: Colors.red,
            title: new Text(
              'Send Text Notifications',
              style: Theme.of(context).textTheme.subhead,
            ),
          ),
          SwitchListTile(
            value: videoSwitch,
            onChanged: (value) {
              setState(() {
                videoSwitch = value;
              });
            },
            activeTrackColor: siueRed,
            activeColor: Colors.red,
            title: new Text(
              'Display Videos Over N Size',
              style: Theme.of(context).textTheme.subhead,
            ),
          ),
          SwitchListTile(
            value: imageSwitch,
            onChanged: (value) {
              setState(() {
                imageSwitch = value;
              });
            },
            activeTrackColor: siueRed,
            activeColor: Colors.red,
            title: new Text(
              'Allow Images',
              style: Theme.of(context).textTheme.subhead,
            ),
          ),
        ],
      ),
    );
  }
}

import 'screens/screen_about_us/screen_about_us.dart';
import 'screens/screen_ask_expert/screen_ask_expert_form.dart';
import 'screens/screen_ask_expert/screen_ask_expert_category.dart';
import 'screens/screen_clothing_donation/screen_clothing_donation.dart';
import 'screens/../common/widgets/custom_outline_button.dart';
import 'screens/screen_experts/screen_experts.dart';
import 'screens/screen_introduction/screen_splash.dart';
import 'screens/screen_introduction/screen_start.dart';
import 'screens/screen_login/screen_login.dart';
import 'screens/screen_register/screen_register.dart';
import 'package:flutter/material.dart';

void main() => runApp(
      MaterialApp(
        theme: ThemeData(
          brightness: Brightness.light,
          primaryColor: Colors.lightBlue[800],
          fontFamily: 'Amatic SC',
          textTheme: const TextTheme(
            headline1: TextStyle(fontSize: 72.0, fontWeight: FontWeight.bold),
            headline2: TextStyle(fontSize: 36.0, fontWeight: FontWeight.bold),
            bodyText1: TextStyle(fontSize: 16.0, fontFamily: 'Montserrat'),
            bodyText2: TextStyle(fontSize: 14.0),
          ),
        ),
        title: "App for family backup",
        initialRoute: '/', // TODO: Change back to start screen
        routes: {
          '/': (context) => ScreenExperts(1),
          ScreenLogin.route: (context) => ScreenLogin(),
          ScreenRegister.route: (context) => ScreenRegister(),
          ScreenAboutUs.route: (context) => ScreenAboutUs(),
          ScreenAskExpertCategory.route: (context) => ScreenAskExpertCategory(),
          ScreenExperts.route: (context) => ScreenExperts(1),
          ScreenClothingDonation.route: (context) => ScreenClothingDonation(),
          ScreenSplash.route: (context) => ScreenSplash(),
          StartScreen.route: (context) => StartScreen(),
          ScreenAskExpertCategory.route: (context) => ScreenAskExpertCategory(),
          ScreenAskExpertForm.route: (context) => ScreenAskExpertForm(),
        },
      ),
    );

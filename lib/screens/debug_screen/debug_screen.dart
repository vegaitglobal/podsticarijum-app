import 'package:flutter/material.dart';

import '../../common/enums/age_group_type.dart';
import '../../common/enums/development_ascpect_type.dart';
import '../../common/enums/flag_type.dart';
import '../../screens/category_details_screen/category_flags_screen.dart';
import '../about_us_screen/screen_about_us.dart';
import '../ask_expert_screen/faq_categories_screen.dart';
import '../../common/widgets/custom_outline_button.dart';
import '../donation_screen/donation_screen.dart';
import '../experts_screen/experts_screen.dart';
import '../splash_screen/splash_screen.dart';

class DebugScreen extends StatelessWidget {
  static const String route = "/debug ";
  const DebugScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(title: const Text("Podsticarijum")),
        body: Center(
            child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            CustomOutlineButton(
                text: "Pitaj stručnjaka",
                onClick: () {
                  Navigator.pushNamed(context, FaqCategoriesScreen.route);
                }),
            CustomOutlineButton(
                text: "Forma",
                onClick: () {
                  /**
                   *  SEND NECESSARY ARGUMENTS HERE!!!
                   */
                  Navigator.pushNamed(
                    context,
                    CategoryFlagsScreen.route,
                    arguments: CategoryFlagsScreenArguments(AgeGroupType.first,
                        DevelopmentAspectType.cognitive, FlagType.green),
                  );
                }),
            CustomOutlineButton(
                text: "Donacija robe",
                onClick: () {
                  Navigator.pushNamed(context, DonationScreen.route);
                }),
            CustomOutlineButton(
                text: "O nama",
                onClick: () {
                  Navigator.pushNamed(context, AboutUsScreen.route);
                }),
            CustomOutlineButton(
                text: "Stručnjaci",
                onClick: () {
                  Navigator.pushNamed(context, ExpertsScreen.route);
                }),
            CustomOutlineButton(
                text: "Introduction",
                onClick: () {
                  Navigator.pushNamed(context, SplashScreen.route);
                }),
          ],
        )));
  }
}

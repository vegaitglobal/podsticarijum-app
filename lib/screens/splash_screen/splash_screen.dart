import 'package:flutter/material.dart';

import '../../common/widgets/custom_outline_button.dart';
import '../../common/widgets/default_header.dart';
import '../../common/widgets/useful_widgets.dart';
import '../categories_screen/categories_screen.dart';

class SplashScreen extends StatelessWidget {
  SplashScreen({Key? key}) : super(key: key);

  static const String route = "/splash ";
  static const String info =
      '"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliqui';
  static const Duration _navDelayDuration = Duration(seconds: 2);

  final Future<bool> _navFuture = Future.delayed(
    _navDelayDuration,
    () => true,
  );

  Widget buildInitialScreen(BuildContext context) =>
      centeredContainerWithFooter(
        buildLogoWidget(
          context,
          buildTitle(context, "Podsticarijum"),
        ),
        buildFooterWidget(context),
      );

  Widget buildSucceederScreen(BuildContext context) => Column(
        mainAxisAlignment: MainAxisAlignment.spaceAround,
        children: [
          buildLogoWidget(
            context,
            buildTitle(context, "Podsticarijum"),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 44),
            child: Text(
              info,
              style: Theme.of(context).textTheme.bodyText1,
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 20),
            child: CustomOutlineButton(
              text: "Počni",
              onClick: () => Navigator.popAndPushNamed(
                context,
                CategoriesScreen.route,
              ),
            ),
          ),
        ],
      );

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Theme.of(context).primaryColor,
      body: FutureBuilder(
        future: _navFuture,
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return buildSucceederScreen(context);
          } else {
            return buildInitialScreen(context);
          }
        },
      ),
    );
  }
}

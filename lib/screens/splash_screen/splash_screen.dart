import 'package:app_for_family_backup/api/podsticariju_api.dart';
import 'package:flutter/material.dart';

import '../../common/widgets/custom_outline_button.dart';
import '../../common/widgets/default_header.dart';
import '../../common/widgets/useful_widgets.dart';
import '../categories_screen/categories_screen.dart';

class SplashScreen extends StatefulWidget {
  SplashScreen({Key? key}) : super(key: key);

  static const String route = "/splash ";
  static const Duration _navDelayDuration = Duration(seconds: 2);

  @override
  State<SplashScreen> createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  String? text = null;

  final Future<bool> _navFuture = Future.delayed(
    SplashScreen._navDelayDuration,
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

  Widget buildSucceederScreen(BuildContext context, String content) => Column(
        mainAxisAlignment: MainAxisAlignment.spaceAround,
        children: [
          buildLogoWidget(
            context,
            buildTitle(context, "Podsticarijum"),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 44),
            child: Text(
              content,
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

  void getText() async {
    var response = await PodsticarijumApi.getMainScreenContent("MainScreen");
    setState(() {
      text = response?.text.substring(0, 250);
    });
  }

  @override
  Widget build(BuildContext context) {
    if (text == null) getText();

    return Scaffold(
      backgroundColor: Theme.of(context).primaryColor,
      body: FutureBuilder(
        future: _navFuture,
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return buildSucceederScreen(context, text ?? "");
          } else {
            return buildInitialScreen(context);
          }
        },
      ),
    );
  }
}

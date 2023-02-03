import 'package:flutter/material.dart';

import '../../common/enums/development_ascpect_type.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/custom_outline_button.dart';
import '../frequent_questions_screen/frequent_questions_screen.dart';

class FaqCategoriesScreen extends StatelessWidget {
  static const String route = '/faq_categories';
  static const double _padding = 12;

  const FaqCategoriesScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        appBar: const NewAppBar(),
        backgroundColor: Theme.of(context).primaryColor,
        body: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 20),
          child: SingleChildScrollView(
            child: Column(
              children: [
                const SizedBox(height: 24),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 44),
                  child: Text(
                    'Najčešće postavljena pitanja iz aspekta: ',
                    style: Theme.of(context).textTheme.headline2,
                    textAlign: TextAlign.center,
                  ),
                ),
                const SizedBox(height: 25),
                ...DevelopmentAspectType.values
                    .map((e) => _getColumnElement(e, context))
                    .toList()
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _getColumnElement(DevelopmentAspectType type, BuildContext context) {
    return Column(
      children: [
        CustomOutlineButton(
          text: type.title,
          onClick: () {
            Navigator.pushNamed(
              context,
              FaqAnswersScreen.route,
              arguments: FaqAnswersScreenArguments(type),
            );
          },
        ),
        const SizedBox(height: _padding),
      ],
    );
  }
}

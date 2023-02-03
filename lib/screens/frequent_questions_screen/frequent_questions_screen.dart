import 'package:flutter/material.dart';

import '../../common/enums/development_ascpect_type.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/default_header.dart';
import '../../common/widgets/info_section_widget.dart';
import '../../common/widgets/default_container.dart';

class FaqAnswersScreenArguments {
  DevelopmentAspectType type;
  FaqAnswersScreenArguments(this.type);
}

class FaqAnswersScreen extends StatelessWidget {
  static const String route = '/screen_frequent_question';
  final Map<String, String> questionAndAnswers;
  final String categoryName;
  final List<Widget> questionAndAnswersWidgetList = [];

  FaqAnswersScreen(this.questionAndAnswers, this.categoryName, {super.key}) {
    for (int i = 0; i < questionAndAnswers.length - 1; ++i) {
      String question = questionAndAnswers.keys.elementAt(i);
      String answer = questionAndAnswers.values.elementAt(i);
      questionAndAnswersWidgetList.add(_questionAnswerWidget(question, answer));
    }

    questionAndAnswersWidgetList.add(
      Padding(
        padding: const EdgeInsets.only(bottom: 30.0),
        child: _questionAnswerWidget(
          questionAndAnswers.keys.last,
          questionAndAnswers.values.last,
          hasBorder: false,
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    final args =
        ModalRoute.of(context)!.settings.arguments as FaqAnswersScreenArguments;

    return Scaffold(
      appBar: const NewAppBar(),
      body: DefaultContainer(
        scale: 0.79,
        leftOffset: -30,
        children: [
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              buildSubtitle(context, "Najčešća pitanja"),
              buildTitle(
                context,
                args.type.title,
              ),
              const SizedBox(height: 35),
              ...questionAndAnswersWidgetList
            ],
          ),
        ],
      ),
    );
  }

  Widget _questionAnswerWidget(
    String question,
    String answer, {
    bool hasBorder = true,
  }) {
    return Column(
      children: [
        const SizedBox(height: 20),
        InfoSectionWidget(
          title: question,
          content: answer,
          hasBorder: hasBorder,
          spacing: 15,
        ),
      ],
    );
  }
}

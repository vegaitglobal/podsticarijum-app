import 'package:flutter/material.dart';

import '../../api/podsticariju_api.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/default_header.dart';
import '../../common/widgets/info_section_widget.dart';
import '../../common/widgets/default_container.dart';

class FaqUiModel {
  String subcategoryName;
  Map<String, String> questionAndAnswers;

  FaqUiModel(
    this.subcategoryName,
    this.questionAndAnswers,
  );
}

class FaqAnswersScreenArguments {
  int subcategoryId;
  FaqAnswersScreenArguments(this.subcategoryId);
}

class FaqAnswersScreen extends StatefulWidget {
  static const String route = '/screen_frequent_question';

  @override
  State<FaqAnswersScreen> createState() => _FaqAnswersScreenState();
}

class _FaqAnswersScreenState extends State<FaqAnswersScreen> {
  FaqUiModel? faqUiModel = null;

  void getFaqCategoryUiModel(int subcategoryId) async {
    var responseFaqModelList = await PodsticarijumApi.getFaqList(subcategoryId);
    var responseSubcategory =
        await PodsticarijumApi.getSubcategory(subcategoryId);

    var questionAnswerMap = {
      for (var faqModel in responseFaqModelList)
        faqModel.question: faqModel.answer
    };

    setState(() {
      faqUiModel = FaqUiModel(
        responseSubcategory?.name ?? "",
        questionAnswerMap,
      );
    });
  }

  @override
  Widget build(BuildContext context) {
    final args =
        ModalRoute.of(context)!.settings.arguments as FaqAnswersScreenArguments;

    if (faqUiModel == null) getFaqCategoryUiModel(args.subcategoryId);

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
                faqUiModel?.subcategoryName ?? "",
              ),
              const SizedBox(height: 35),
              ..._buildQuestinoAnswerContent(faqUiModel?.questionAndAnswers)
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

  List<Widget> _buildQuestinoAnswerContent(
      Map<String, String>? questionAndAnswers) {
    if (questionAndAnswers == null) return [const Text("No questions")];

    final List<Widget> questionAndAnswersWidgetList = [];
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

    return questionAndAnswersWidgetList;
  }
}

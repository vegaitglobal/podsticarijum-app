import 'package:app_for_family_backup/api/podsticariju_api.dart';
import 'package:app_for_family_backup/common/widgets/useful_widgets.dart';
import 'package:flutter/material.dart';

import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/custom_outline_button.dart';
import '../frequent_questions_screen/frequent_questions_screen.dart';

class FaqCategoriesElementUiModel {
  String subcategoryName;
  int subcategoryId;

  FaqCategoriesElementUiModel(
    this.subcategoryName,
    this.subcategoryId,
  );
}

class FaqCategoriesScreen extends StatefulWidget {
  static const String route = '/faq_categories';
  static const double _padding = 12;

  const FaqCategoriesScreen({super.key});

  @override
  State<FaqCategoriesScreen> createState() => _FaqCategoriesScreenState();
}

class _FaqCategoriesScreenState extends State<FaqCategoriesScreen> {
  List<FaqCategoriesElementUiModel>? faqCategoriesElementUiModelList = null;
  bool isError = false;

  void getFaqCategoryUiModel() async {
    var response = await PodsticarijumApi.getSubcategoryList()
        .catchError((Object e, StackTrace stackTrace) {
      setState(() {
        isError = true;
        return null;
      });
    });

    setState(() {
      faqCategoriesElementUiModelList = response
          .map(
            (subcategory) => FaqCategoriesElementUiModel(
              subcategory.name,
              subcategory.id,
            ),
          )
          .toList();
    });
  }

  @override
  Widget build(BuildContext context) {
    if (faqCategoriesElementUiModelList == null && !isError)
      getFaqCategoryUiModel();

    return SafeArea(
      child: Scaffold(
          appBar: const NewAppBar(),
          backgroundColor: Theme.of(context).primaryColor,
          body: isError
              ? buildErrorScreen()
              : faqCategoriesElementUiModelList == null
                  ? buildLoadingWidget(context)
                  : _buildContent()),
    );
  }

  Widget _buildContent() {
    return Padding(
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
            ...?faqCategoriesElementUiModelList
                ?.map(
                  (faqCategoryElement) => _getColumnElement(
                    faqCategoryElement.subcategoryName,
                    faqCategoryElement.subcategoryId,
                    // subcategory.name,
                    // subcategory.id,
                    context,
                  ),
                )
                .toList()
          ],
        ),
      ),
    );
  }

  Widget _getColumnElement(
    String subcategoryName,
    int subcategoryId,
    BuildContext context,
  ) {
    return Column(
      children: [
        CustomOutlineButton(
          text: subcategoryName,
          onClick: () {
            Navigator.pushNamed(
              context,
              FaqAnswersScreen.route,
              arguments: FaqAnswersScreenArguments(subcategoryId),
            );
          },
        ),
        const SizedBox(height: FaqCategoriesScreen._padding),
      ],
    );
  }
}

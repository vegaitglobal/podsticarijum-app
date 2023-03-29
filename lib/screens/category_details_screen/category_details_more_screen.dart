import 'package:flutter/material.dart';

import '../../api/podsticariju_api.dart';
import '../../common/enums/flag_type.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/custom_outline_button.dart';
import '../../common/widgets/default_container.dart';
import '../../common/widgets/default_header.dart';
import '../../common/widgets/useful_widgets.dart';
import '../categories_screen/categories_screen.dart';
import 'category_flags_screen.dart';

class CategoryDetailsMoreScreenArguments {
  int subcategoryId;
  CategoryDetailsMoreScreenArguments(this.subcategoryId);
}

class CategoryDetailsMoreUiModel {
  String subtitle;
  String title;
  List<String> paragraphList;

  CategoryDetailsMoreUiModel(
    this.subtitle,
    this.title,
    this.paragraphList,
  );
}

class CategoryDetailsMoreScreen extends StatefulWidget {
  static const String route = '/category_details_more_screen';

  CategoryDetailsMoreScreen({Key? key}) : super(key: key);

  @override
  State<CategoryDetailsMoreScreen> createState() =>
      _CategoryDetailsMoreScreenState();
}

class _CategoryDetailsMoreScreenState extends State<CategoryDetailsMoreScreen> {
  CategoryDetailsMoreUiModel? categoryDetailsMoreUiModel = null;
  bool isError = false;
  void getCategoryDetailsMoreUiModel(int subcategoryId) async {
    var subcategory = await PodsticarijumApi.getSubcategory(subcategoryId)
        .catchError((Object e, StackTrace stackTrace) {
      setState(() {
        isError = true;
        return null;
      });
    });

    setState(() {
      if (subcategory != null && !isError) {
        categoryDetailsMoreUiModel = CategoryDetailsMoreUiModel(
          subcategory.categoryName,
          subcategory.name,
          subcategory.detailedDescription.split('\n'),
        );
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    final args = ModalRoute.of(context)!.settings.arguments
        as CategoryDetailsMoreScreenArguments;

    getCategoryDetailsMoreUiModel(args.subcategoryId);

    return SafeArea(
      child: Scaffold(
          appBar: const NewAppBar(),
          backgroundColor: Colors.white,
          body: isError
              ? buildErrorScreen()
              : categoryDetailsMoreUiModel == null
                  ? buildLoadingWidget(context)
                  : _buildContent(
                      categoryDetailsMoreUiModel!, args.subcategoryId)),
    );
  }

  Widget _buildContent(CategoryDetailsMoreUiModel categoryDetailsMoreUiModel,
      int subcategoryId) {
    return DefaultContainer(
      scale: 0.79,
      leftOffset: -50,
      children: [
        Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            buildSubtitle(context, categoryDetailsMoreUiModel.subtitle),
            buildTitle(context, categoryDetailsMoreUiModel.title),
            const SizedBox(height: 100),
            ...categoryDetailsMoreUiModel.paragraphList.map(
              (paragraph) => _buildParagraph(paragraph, context),
            ),
            CustomOutlineButton(
              text: "Podsticajne razvojne aktivnosti",
              onClick: () => Navigator.pushNamed(
                context,
                CategoryFlagsScreen.route,
                arguments: CategoryFlagsScreenArguments(
                  subcategoryId,
                  FlagType.green,
                ),
              ),
              isYellow: true,
            ),
            const SizedBox(height: 33),
            CustomOutlineButton(
              text: "Znaci odstupanja",
              onClick: () => Navigator.pushNamed(
                context,
                CategoryFlagsScreen.route,
                arguments: CategoryFlagsScreenArguments(
                  subcategoryId,
                  FlagType.red,
                ),
              ),
              isYellow: true,
            ),
            const SizedBox(height: 33),
            Image.asset(
              'images/separator.png',
              width: double.infinity,
              fit: BoxFit.fitWidth,
            ),
            const SizedBox(height: 33),
            buildDefaultCustomForm(subcategoryId, context),
            const SizedBox(height: 10),
            Align(
              alignment: Alignment.center,
              child: TextButton(
                onPressed: () => Navigator.popUntil(
                  context,
                  ModalRoute.withName(CategoriesScreen.route),
                ),
                child: Text(
                  style: Theme.of(context).textTheme.headline4,
                  "Vrati se na početnu stranu",
                ),
              ),
            ),
            const SizedBox(height: 10),
          ],
        ),
      ],
    );
  }

  Widget _buildParagraph(String paragraphText, BuildContext context) {
    return Column(
      children: [
        Text(
          paragraphText,
          style: Theme.of(context).textTheme.bodyText1,
        ),
        const SizedBox(
          height: 15,
        ),
      ],
    );
  }
}

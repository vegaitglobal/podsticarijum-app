import 'package:app_for_family_backup/common/widgets/useful_widgets.dart';
import 'package:flutter/material.dart';
import '../../api/podsticariju_api.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/custom_outline_button.dart';
import '../../common/widgets/default_header.dart';
import 'category_details_more_screen.dart';

class CategoryIntroUiModel {
  String subcategoryName;
  String description;
  List<String> bulletpointList;

  CategoryIntroUiModel(
    this.subcategoryName,
    this.description,
    this.bulletpointList,
  );
}

class CategoryIntroScreenArguments {
  int subcategoryId;

  CategoryIntroScreenArguments(
    this.subcategoryId,
  );
}

class CategoryIntroScreen extends StatefulWidget {
  static const String route = '/category_details_intro';

  const CategoryIntroScreen({Key? key}) : super(key: key);

  @override
  State<CategoryIntroScreen> createState() => _CategoryIntroScreenState();
}

class _CategoryIntroScreenState extends State<CategoryIntroScreen> {
  CategoryIntroUiModel? categoryIntroUiModel = null;
  bool isError = false;

  void getCategoryIntro(int subcategoryId) async {
    var result = await PodsticarijumApi.getSubcategory(subcategoryId)
        .catchError((Object e, StackTrace stackTrace) {
      setState(() {
        isError = true;
        return null;
      });
    });

    setState(() {
      if (result != null && !isError) {
        categoryIntroUiModel = CategoryIntroUiModel(
          result.name,
          result.description,
          result.detailedDescription.split("\n"),
        );
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    final args = ModalRoute.of(context)!.settings.arguments
        as CategoryIntroScreenArguments;

    getCategoryIntro(args.subcategoryId);

    return SafeArea(
      child: Scaffold(
        appBar: const NewAppBar(),
        backgroundColor: Colors.white,
        body: isError
            ? buildErrorScreen()
            : categoryIntroUiModel != null
                ? _buildContent(categoryIntroUiModel!, args.subcategoryId)
                : buildLoadingWidget(context),
      ),
    );
  }

  Widget _buildContent(
      CategoryIntroUiModel categoryIntroUiModel, int subcategoryId) {
    return SingleChildScrollView(
      child: Column(
        children: [
          Container(
            padding: const EdgeInsets.symmetric(horizontal: 20),
            color: Theme.of(context).primaryColor,
            width: double.infinity,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                const SizedBox(height: 25),
                buildTitle(context, categoryIntroUiModel.subcategoryName),
                const SizedBox(height: 10),
                Text(
                  categoryIntroUiModel.description,
                  textAlign: TextAlign.start,
                  style: Theme.of(context).textTheme.bodyText1,
                ),
              ],
            ),
          ),
          Container(
            height: 70,
            width: MediaQuery.of(context).size.width,
            decoration: const BoxDecoration(
              image: DecorationImage(
                fit: BoxFit.fill,
                image: AssetImage('images/about_us_bg.png'),
              ),
            ),
          ),
          const SizedBox(height: 20),
          Text(
            'Senzo-motorni razvoj utiče na procese učenja',
            style: Theme.of(context).textTheme.bodyText1?.copyWith(
                  fontWeight: FontWeight.bold,
                  fontSize: 14,
                ),
          ),
          const SizedBox(height: 20),
          ...categoryIntroUiModel.bulletpointList
              .map(
                (bulletpoint) => _textWithIcon(bulletpoint, context),
              )
              .toList(),
          const SizedBox(height: 20),
          Text(
            'Pogledaj više informacija za određeni uzrast',
            style: Theme.of(context).textTheme.bodyText1?.copyWith(
                  fontWeight: FontWeight.bold,
                  fontSize: 14,
                ),
          ),
          const SizedBox(height: 12.5),
          CustomOutlineButton(
            text: 'Pogledaj više',
            onClick: () {
              Navigator.pushNamed(
                context,
                CategoryDetailsMoreScreen.route,
                arguments: CategoryDetailsMoreScreenArguments(subcategoryId),
              );
            },
          ),
          const SizedBox(height: 10),
        ],
      ),
    );
  }

  Widget buildParagraph(String paragraphText, BuildContext context) {
    return SizedBox(
      child: Column(
        children: [
          Text(
            paragraphText,
            style: Theme.of(context).textTheme.bodyText1,
          ),
          const SizedBox(height: 15),
        ],
      ),
    );
  }

  Widget _textWithIcon(String text, BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(right: 25),
      child: Row(
        children: [
          const SizedBox(width: 20), //shared padding
          const ImageIcon(
            AssetImage('images/bulletpoint.png'),
            size: 12,
          ),
          const SizedBox(width: 12),
          Expanded(
            child: Text(
              text,
              style: Theme.of(context).textTheme.bodyText1,
            ),
          ),
        ],
      ),
    );
  }
}

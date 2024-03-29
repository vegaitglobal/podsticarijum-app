import 'dart:convert';

import 'package:app_for_family_backup/api/models/SubcategoryModel.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart';

import '../../api/podsticariju_api.dart';
import '../../common/enums/flag_type.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/default_container.dart';
import '../../common/widgets/default_header.dart';
import '../../common/widgets/useful_widgets.dart';
import '../categories_screen/categories_screen.dart';

class CategoryFlagsUiModel {
  String categoryName;
  List<String> flagList;

  CategoryFlagsUiModel(
    this.categoryName,
    this.flagList,
  );
}

class EmailPayloadDto {
  String nameSurname;
  String mail;
  String question;

  EmailPayloadDto(this.nameSurname, this.mail, this.question);

  Map<String, dynamic> toJson() => {
        'appPackageName': 'com.example.app_for_family_backup',
        'userMailAddress': mail,
        'subject': 'Novo pitanje od: $mail',
        'body': question,
      };
}

class CategoryFlagsScreenArguments {
  int subcategoryId;
  FlagType flagType;

  CategoryFlagsScreenArguments(
    this.subcategoryId,
    this.flagType,
  );
}

class CategoryFlagsScreen extends StatefulWidget {
  static const String route = '/category_flags';

  CategoryFlagsScreen({
    Key? key,
  }) : super(key: key);

  @override
  State<CategoryFlagsScreen> createState() => _CategoryFlagsScreenState();
}

class _CategoryFlagsScreenState extends State<CategoryFlagsScreen> {
  bool isError = false;
  CategoryFlagsUiModel? categoryFlagsUiModel = null;

  void getCategoryFlags(int subcategoryId, FlagType flagType) async {
    var subcategory = await PodsticarijumApi.getSubcategory(subcategoryId)
        .catchError((Object e, StackTrace stackTrace) {
      setState(() {
        isError = true;
        return null;
      });
    });

    var flagList = await PodsticarijumApi.getSubcategorySpecificContent(
            subcategoryId, flagType)
        .catchError((Object e, StackTrace stackTrace) {
      setState(() {
        isError = true;
        return null;
      });
    });

    setState(() {
      if (subcategory != null) {
        // switch (flagType) {
        //   case FlagType.green:
        //     // flagList = subcategory.positiveSigns;
        //     break;
        //   case FlagType.red:
        //     // flagList = subcategory.negativeSigns;
        //     break;
        // }
        categoryFlagsUiModel = CategoryFlagsUiModel(
          subcategory.categoryName,
          flagList,
        );
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    final args = ModalRoute.of(context)!.settings.arguments
        as CategoryFlagsScreenArguments;

    if (categoryFlagsUiModel == null && !isError) {
      getCategoryFlags(args.subcategoryId, args.flagType);
    }

    return SafeArea(
      child: Scaffold(
          appBar: const NewAppBar(),
          backgroundColor: Colors.white,
          body: isError
              ? buildErrorScreen()
              : categoryFlagsUiModel == null
                  ? buildLoadingWidget(context)
                  : _buildContent(args.subcategoryId, args.flagType)),
    );
  }

  Widget _buildContent(int subcategoryId, FlagType flagType) {
    return DefaultContainer(
      scale: 0.71,
      leftOffset: -50,
      children: [
        Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            buildSubtitle(
              context,
              categoryFlagsUiModel?.categoryName ?? "",
              // args.ageGroupType.title,
            ),
            buildTitle(
              context,
              flagType == FlagType.green
                  ? "Stimulativne igre i aktivnosti za razvoj vaše bebe i deteta."
                  : 'Znakovi odstupanja od neurotipičnog razvoja',
            ),
            const SizedBox(height: 100),
            ...?categoryFlagsUiModel?.flagList.map(
              (paragraph) => _buildParagraph(context, flagType, paragraph),
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
                child: Text(
                  style: Theme.of(context).textTheme.headline4,
                  "Vrati se na početnu stranu",
                ),
                onPressed: () {
                  Navigator.popUntil(
                    context,
                    ModalRoute.withName(CategoriesScreen.route),
                  );
                },
              ),
            ),
            const SizedBox(height: 10),
          ],
        ),
      ],
    );
  }

  Widget _buildParagraph(
      BuildContext context, FlagType flagType, String paragraphText) {
    return Column(
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Image.asset(
              flagType == FlagType.green
                  ? 'images/green_flag_img.png'
                  : 'images/red_flag_img.png',
            ),
            const SizedBox(width: 10),
            Expanded(
              child: Text(
                paragraphText,
                style: Theme.of(context).textTheme.bodyText1,
                overflow: TextOverflow.clip,
              ),
            ),
          ],
        ),
        const SizedBox(height: 15),
      ],
    );
  }
}

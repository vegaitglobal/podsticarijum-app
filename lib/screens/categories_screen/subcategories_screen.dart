import 'package:app_for_family_backup/api/models/SubcategoryModel.dart';
import 'package:flutter/material.dart';

import '../../api/podsticariju_api.dart';
import '../../common/enums/age_group_type.dart';
import '../../common/enums/app_bar_type.dart';
import '../../common/enums/development_ascpect_type.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/custom_outline_button.dart';
import '../category_details_screen/category_intro_screen.dart';

class SubCategoriesScreenArguments {
  int categoryId;

  SubCategoriesScreenArguments(this.categoryId);
}

class SubCategoriesScreen extends StatefulWidget {
  static const route = '/subcategories';
  static const double _padding = 12;
  static const List<String> subCategories = [
    'Motorički razvoj',
    'Govorno-jezički razvoj',
    'Senzo-motorički razvoj',
    'Socio-emotivni razvoj',
    'Kognitivni razvoj',
  ];

  const SubCategoriesScreen({Key? key}) : super(key: key);

  @override
  State<SubCategoriesScreen> createState() => _SubCategoriesScreenState();
}

class _SubCategoriesScreenState extends State<SubCategoriesScreen> {
  List<SubcategoryModel> subcategoryList = List.empty();

  void getSubcategoryNameList(int categoryId) async {
    var result = await PodsticarijumApi.getSubcategoryList(categoryId);

    setState(() {
      subcategoryList = result;
    });
  }

  @override
  Widget build(BuildContext context) {
    SubCategoriesScreenArguments? args = ModalRoute.of(context)!
        .settings
        .arguments as SubCategoriesScreenArguments;

    getSubcategoryNameList(args.categoryId);

    return SafeArea(
      child: Scaffold(
        backgroundColor: Theme.of(context).primaryColor,
        appBar: const NewAppBar(appBarType: AppBarType.rootNav),
        body: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 20),
          child: Center(
            child: SingleChildScrollView(
              child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    ...subcategoryList.map(
                      (subcategory) => _getColumnElement(
                        context,
                        subcategory.name,
                        args.categoryId,
                        subcategory.id,
                      ),
                    )
                    // ...DevelopmentAspectType.values
                    //     .map((aspectType) =>
                    //         _getColumnElement(context, aspectType, args))
                    //     .toList(),
                  ]),
            ),
          ),
        ),
      ),
    );
  }

  Widget _getColumnElement(
    BuildContext context,
    String text,
    int categoryId,
    int subcategoryId,
  ) {
    return Column(
      children: [
        CustomOutlineButton(
          text: text,
          onClick: () {
            Navigator.pushNamed(context, CategoryIntroScreen.route,
                arguments: CategoryIntroScreenArguments(
                  categoryId,
                  subcategoryId,
                  // args.ageGroupType,
                  // AgeGroupType.first,
                  // DevelopmentAspectType.cognitive,
                ));
          },
        ),
        const SizedBox(height: SubCategoriesScreen._padding),
      ],
    );
  }
}

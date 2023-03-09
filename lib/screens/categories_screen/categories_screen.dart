import 'package:app_for_family_backup/api/models/CategoryModel.dart';
import 'package:app_for_family_backup/api/podsticariju_api.dart';
import 'package:flutter/material.dart';

import '../../common/enums/age_group_type.dart';
import '../../common/enums/app_bar_type.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/custom_outline_button.dart';
import 'subcategories_screen.dart';

class CategoriesScreen extends StatefulWidget {
  static const route = '/categories';
  static const double _padding = 12;

  const CategoriesScreen({Key? key}) : super(key: key);

  @override
  State<CategoriesScreen> createState() => _CategoriesScreenState();
}

class _CategoriesScreenState extends State<CategoriesScreen> {
  List<CategoryModel> categoryList = List.empty();

  void getCategoryNames() async {
    List<CategoryModel> categoryNamesResponse =
        await PodsticarijumApi.getCategoryList();
    print("00>99 - $categoryList");
    setState(() {
      categoryList = categoryNamesResponse;
    });
  }

  @override
  void initState() {
    getCategoryNames();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: Theme.of(context).primaryColor,
        appBar: const NewAppBar(appBarType: AppBarType.rootNav),
        body: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 21),
          child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: getCategoryButtons(categoryList)
              // [
              //   ...getCategoryButtons(categoryNames),
              //   ...[
              //     CustomOutlineButton(
              //         text: AgeGroupType.first.title,
              //         onClick: () {
              //           _navigate(AgeGroupType.first, context);
              //         }),
              //     const SizedBox(height: CategoriesScreen._padding),
              //     CustomOutlineButton(
              //         text: AgeGroupType.second.title,
              //         onClick: () {
              //           _navigate(AgeGroupType.second, context);
              //         }),
              //     const SizedBox(height: CategoriesScreen._padding),
              //     CustomOutlineButton(
              //         text: AgeGroupType.third.title,
              //         onClick: () {
              //           _navigate(AgeGroupType.third, context);
              //         }),
              //     const SizedBox(height: CategoriesScreen._padding),
              //     CustomOutlineButton(
              //         text: AgeGroupType.fourth.title,
              //         onClick: () {
              //           _navigate(AgeGroupType.fourth, context);
              //         }),
              //   ],
              // ]
              ),
        ),
      ),
    );
  }

  void _navigate(int cateogryId, BuildContext context) {
    Navigator.pushNamed(
      context,
      SubCategoriesScreen.route,
      arguments: SubCategoriesScreenArguments(cateogryId),
    );
  }

  List<Widget> getCategoryButtons(List<CategoryModel> categoryList) {
    List<Widget> widgetList = [];

    if (categoryList.isNotEmpty) {
      widgetList.add(buildCustomOutlineButton(
          categoryList[0].categoryName, categoryList[0].id));
    }

    categoryList.skip(1).forEach((category) {
      widgetList.add(const SizedBox(height: CategoriesScreen._padding));
      widgetList
          .add(buildCustomOutlineButton(category.categoryName, category.id));
    });

    return widgetList;
  }

  Widget buildCustomOutlineButton(String text, int id) {
    return CustomOutlineButton(
        text: text,
        onClick: () {
          _navigate(id, context);
        });
  }
}

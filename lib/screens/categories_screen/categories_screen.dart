import 'package:flutter/material.dart';

import '../../common/enums/age_group_type.dart';
import '../../common/enums/app_bar_type.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/custom_outline_button.dart';
import '../category_details_screen/category_details_screen.dart';
import 'subcategories_screen.dart';

class CategoriesScreen extends StatelessWidget {
  static const route = '/categories';
  static const double _padding = 12;

  const CategoriesScreen({Key? key}) : super(key: key);

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
            children: [
              CustomOutlineButton(
                  text: "0-1 godina",
                  onClick: () {
                    _navigate(AgeGroupType.first, context);
                  }),
              const SizedBox(height: _padding),
              CustomOutlineButton(
                  text: "1-3 godina",
                  onClick: () {
                    _navigate(AgeGroupType.second, context);
                  }),
              const SizedBox(height: _padding),
              CustomOutlineButton(
                  text: "3-5 godina",
                  onClick: () {
                    _navigate(AgeGroupType.third, context);
                  }),
              const SizedBox(height: _padding),
              CustomOutlineButton(
                  text: "5-7 godina",
                  onClick: () {
                    _navigate(AgeGroupType.fourth, context);
                  }),
            ],
          ),
        ),
      ),
    );
  }

  void _navigate(AgeGroupType type, BuildContext context) {
    Navigator.pushNamed(
      context,
      SubCategoriesScreen.route,
      arguments: SubCategoriesScreenArguments(type),
    );
  }
}

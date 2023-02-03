import 'package:flutter/material.dart';

import '../../common/enums/age_group_type.dart';
import '../../common/enums/app_bar_type.dart';
import '../../common/enums/development_ascpect_type.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/custom_outline_button.dart';
import '../category_details_screen/category_intro_screen.dart';

class SubCategoriesScreenArguments {
  AgeGroupType ageGroupType;

  SubCategoriesScreenArguments(this.ageGroupType);
}

class SubCategoriesScreen extends StatelessWidget {
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
  Widget build(BuildContext context) {
    SubCategoriesScreenArguments? args = ModalRoute.of(context)!
        .settings
        .arguments as SubCategoriesScreenArguments;

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
                    ...DevelopmentAspectType.values
                        .map((aspectType) =>
                            _getColumnElement(context, aspectType, args))
                        .toList(),
                  ]),
            ),
          ),
        ),
      ),
    );
  }

  Widget _getColumnElement(BuildContext context, DevelopmentAspectType type,
      SubCategoriesScreenArguments args) {
    return Column(
      children: [
        CustomOutlineButton(
          text: type.title,
          onClick: () {
            Navigator.pushNamed(context, CategoryIntroScreen.route,
                arguments: CategoryIntroScreenArguments(
                  args.ageGroupType,
                  type,
                ));
          },
        ),
        const SizedBox(height: _padding),
      ],
    );
  }
}

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
  //  data
  // final List<String> paragraphList = [
  //   'Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia, molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium optio, eaque rerum!',
  //   'Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia, molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium optio, eaque rerum!',
  //   'Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia, molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium optio, eaque rerum!',
  //   'Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia, molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium optio, eaque rerum!',
  // ];
  CategoryDetailsMoreUiModel categoryDetailsMoreUiModel =
      CategoryDetailsMoreUiModel("", "", []);

  void getCategoryDetailsMoreUiModel(int subcategoryId) async {
    var subcategory = await PodsticarijumApi.getSubcategory(subcategoryId);

    setState(() {
      if (subcategory != null) {
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
        body: DefaultContainer(
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
                      // args.ageGroupType,
                      // args.developmentAspectType,
                      args.subcategoryId,
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
                      // args.ageGroupType,
                      // args.developmentAspectType,
                      args.subcategoryId,
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
                buildDefaultCustomForm(sendEmail, context),
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
        ),
      ),
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

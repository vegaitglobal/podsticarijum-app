import 'package:flutter/material.dart';

import '../../common/enums/age_group_type.dart';
import '../../common/enums/development_ascpect_type.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/custom_outline_button.dart';
import '../../common/widgets/default_header.dart';
import 'category_details_more_screen.dart';

class CategoryIntroScreenArguments {
  AgeGroupType ageGroupType;
  DevelopmentAspectType developmentAspectType;

  CategoryIntroScreenArguments(
    this.ageGroupType,
    this.developmentAspectType,
  );
}

class CategoryIntroScreen extends StatelessWidget {
  static const String route = '/category_details_intro';

  final String description =
      ' Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia, molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium optio, eaque rerum! Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia, molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium optio, eaque rerum! ';

  final List<String> bulletpointList = [
    'Lorem ipsum dolor sit amet consectetur adipisicing elit.',
    'Lorem ipsum dolor sit amet consectetur adipisicing elit.',
    'Lorem ipsum dolor sit amet consectetur adipisicing elit.',
    'Lorem ipsum dolor sit amet consectetur adipisicing elit.',
    'Lorem ipsum dolor sit amet consectetur adipisicing elit.',
    'Lorem ipsum dolor sit amet consectetur adipisicing elit.'
  ];

  CategoryIntroScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final args = ModalRoute.of(context)!.settings.arguments
        as CategoryIntroScreenArguments;

    return SafeArea(
      child: Scaffold(
        appBar: const NewAppBar(),
        backgroundColor: Colors.white,
        body: SingleChildScrollView(
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
                    buildTitle(context, args.developmentAspectType.title),
                    const SizedBox(height: 10),
                    Text(
                      description,
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
              ...bulletpointList
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
                    arguments: CategoryDetailsMoreScreenArguments(
                      args.ageGroupType,
                      args.developmentAspectType,
                    ),
                  );
                },
              ),
              const SizedBox(height: 10),
            ],
          ),
        ),
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
    return Row(
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
    );
  }
}

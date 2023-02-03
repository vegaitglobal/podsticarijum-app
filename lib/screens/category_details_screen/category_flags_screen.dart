import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart';

import '../../common/enums/age_group_type.dart';
import '../../common/enums/development_ascpect_type.dart';
import '../../common/enums/flag_type.dart';
import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/default_container.dart';
import '../../common/widgets/default_header.dart';
import '../../common/widgets/useful_widgets.dart';
import '../categories_screen/categories_screen.dart';

class EmailPayloadDto {
  String nameSurname;
  String mail;
  String question;

  EmailPayloadDto(this.nameSurname, this.mail, this.question);

  Map<String, dynamic> toJson() => {
        'AppPackageName': 'com.example.app_for_family_backup',
        'UserMailAddress': mail,
        'ExpertMail': 'djuro.radusinovic@vegait.rs',
        'Body': question,
      };
}

Future<bool> sendEmail(String name, String mail, String question) async {
  EmailPayloadDto emailPayload = EmailPayloadDto(name, mail, question);

  try {
    Response response = await post(
      Uri.parse('https://podsticarijum.codeforacause.rs/email'),
      headers: {'Content-Type': 'application/json; charset=UTF-8'},
      body: jsonEncode(emailPayload.toJson()),
    ).timeout(
      const Duration(seconds: 5),
    );

    return response.statusCode == 200;
  } on Exception catch (_) {
    return false;
  }
}

class CategoryFlagsScreenArguments {
  AgeGroupType ageGroupType;
  DevelopmentAspectType developmentAspectType;
  FlagType flagType;

  CategoryFlagsScreenArguments(
      this.ageGroupType, this.developmentAspectType, this.flagType);
}

class CategoryFlagsScreen extends StatelessWidget {
  static const String route = '/category_flags';

  //data
  final List<String> paragraphList = [
    'Lorem ipsum dolor sit ',
    'Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia, molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium optio, eaque rerum!',
    'Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia, molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium optio, eaque rerum!',
    'Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia, molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium optio, eaque rerum!',
  ];

  CategoryFlagsScreen({
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final args = ModalRoute.of(context)!.settings.arguments
        as CategoryFlagsScreenArguments;

    return SafeArea(
      child: Scaffold(
        appBar: const NewAppBar(),
        backgroundColor: Colors.white,
        body: DefaultContainer(
          scale: 0.71,
          leftOffset: -50,
          children: [
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                buildSubtitle(
                  context,
                  args.ageGroupType.title,
                ),
                buildTitle(
                  context,
                  args.flagType == FlagType.green
                      ? "Podsticarijum igre i aktivnosti, stimulativne za razvoj vaše bebe i deteta."
                      : 'Znakovi odstupanja od neurotipičnog razvoja',
                ),
                const SizedBox(height: 100),
                ...paragraphList.map(
                  (paragraph) =>
                      _buildParagraph(context, args.flagType, paragraph),
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
        ),
      ),
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

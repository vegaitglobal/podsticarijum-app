import 'package:app_for_family_backup/api/podsticariju_api.dart';

import '../../screens/thank_you_screen/thank_you_screen.dart';
import 'package:flutter/material.dart';

import 'custom_form.dart';
import 'custom_text_form_field.dart';

Text textWidget(BuildContext context, String text) {
  return Text(
    maxLines: 20,
    overflow: TextOverflow.ellipsis,
    text,
    style: Theme.of(context).textTheme.headline5,
    textAlign: TextAlign.center,
  );
}

Widget buildLogoWidget(
  BuildContext context,
  Text textWidget,
) {
  return Container(
    color: Theme.of(context).primaryColor,
    padding: const EdgeInsets.symmetric(horizontal: 20),
    child: Stack(
      fit: StackFit.loose,
      alignment: Alignment.center,
      children: [
        SizedBox(
          width: double.infinity,
          child: Image.asset(
            'images/cloud_with_heart.png',
            scale: 0.5,
          ),
        ),
        Container(
          width: 230,
          height: 150,
          alignment: Alignment.center,
          child: SizedBox(child: textWidget),
        ),
      ],
    ),
  );
}

Widget buildFooterWidget(BuildContext context) => Column(
      children: [
        Text(
          "Powered by",
          style: Theme.of(context).textTheme.bodyText1,
        ),
        Image.asset('images/czpn_logo.png'),
        const SizedBox(height: 30)
      ],
    );

Widget centeredContainerWithFooter(
  Widget centeredWidget,
  Widget footerWidget,
) {
  return SizedBox(
    height: double.infinity,
    child: Stack(
      alignment: Alignment.center,
      children: [
        Align(
          alignment: Alignment.center,
          child: centeredWidget,
        ),
        Positioned(
          bottom: 0,
          child: Align(
            alignment: Alignment.bottomCenter,
            child: footerWidget,
          ),
        )
      ],
    ),
  );
}

Widget buildDefaultCustomForm(
  // Future<bool> Function(
  //   String nameAndSurname,
  //   String email,
  //   String question,
  // )
  //     onValidFormCallback,
  int subcategoryId,
  BuildContext context,
) {
  const double marginBottom = 15;
  String? nameAndSurname;
  String? email;
  String? question;

  return CustomForm(
    submitButtonText: 'Postavi pitanje',
    onClick: () async {
      if (nameAndSurname != null && email != null && question != null) {
        bool result = await PodsticarijumApi.sendEmail(
            nameAndSurname!, email!, question!, subcategoryId);

        const snackBar = SnackBar(
          content:
              Text('Mail nije poslat. Provjerite vašu Internet konekciju.'),
        );

        result == true
            ? Navigator.pushNamed(context, ThankYouScreen.route)
            : ScaffoldMessenger.of(context).showSnackBar(snackBar);
      }
    },
    onValidCallback: (value) {
      if (nameAndSurname != null && email != null && question != null) {
        PodsticarijumApi.sendEmail(
            nameAndSurname!, email!, question!, subcategoryId);
      }
    },
    children: [
      CustomTextFormField(
        labelText: 'Ime i prezime',
        hint: 'Unesi ime i prezime',
        onSaved: (value) => {nameAndSurname = value},
      ),
      const SizedBox(height: marginBottom),
      CustomTextFormField(
        labelText: 'Adresa',
        hint: 'Unesi e-mail adresu',
        isValid: (value) {
          return RegExp(// copied this regex from stack overflow
                  r"^[a-zA-Z0-9.a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9]+\.[a-zA-Z]+")
              .hasMatch(value);
        },
        invalidErrorMessage: '*Neispravan e-mail',
        onSaved: (value) => {email = value},
      ),
      const SizedBox(height: marginBottom),
      CustomTextFormField(
        labelText: 'Pitanje',
        hint: 'Postavi pitanje specijalisti.',
        largeInputField: true,
        onSaved: (value) => {question = value},
      ),
      const SizedBox(height: marginBottom),
    ],
  );
}

Widget buildLoadingWidget(BuildContext context) {
  return Container(
    alignment: Alignment.center,
    color: Theme.of(context).primaryColor,
    child: const CircularProgressIndicator(
      strokeWidth: 5,
      valueColor:
          AlwaysStoppedAnimation<Color>(Color.fromARGB(255, 157, 57, 175)),
    ),
  );
}

Widget buildErrorScreen() {
  return const ThankYouScreen(
    text:
        "Pojavila se greška pri komunikaciji sa serverom. Molimo Vas provjerite Vašu internet konekciju",
    isMenuVisible: false,
  );
}

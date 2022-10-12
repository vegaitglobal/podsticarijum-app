import '../../common/widgets/app_bar/app_bar.dart';
import '../../common/widgets/form_scrollable.dart';
import '../../common/widgets/custom_text_form_field.dart';
import 'package:flutter/material.dart';

class ScreenAskExpertForm extends StatefulWidget {
  static const String route = '/ask_expert_form_screen';

  const ScreenAskExpertForm({super.key});

  @override
  State<ScreenAskExpertForm> createState() => _ScreenAskExpertFormState();
}

class _ScreenAskExpertFormState extends State<ScreenAskExpertForm> {
  final double _padding = 30;

  String? imePrezime = null;
  String? email = null;
  String? pitanje = null;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: CustomAppBar(), //default background paint is white
      body: FormScrollable(
        children: [
          Padding(
            padding: const EdgeInsets.only(bottom: 30.0),
            child: Text(
              "Postavi pitanje",
              style: Theme.of(context).textTheme.headline2,
            ),
          ),
          CustomTextFormField(
            hint: "Unesi ime i prezime",
            labelText: "Ime i prezime",
            padding: _padding,
            onSaved: (value) => {imePrezime = value},
          ),
          CustomTextFormField(
            hint: "Unesi e-mail adresu",
            labelText: "Adresa",
            padding: _padding,
            onSaved: (value) => {email = value},
          ),
          CustomTextFormField(
            hint: "Pošalji pitanje",
            labelText: "Pitanje",
            largeInputField: true,
            padding: _padding,
            onSaved: (value) => {pitanje = value},
          ),
        ],
        submitButtonText: "SUBMIT YEAH",
        onValidCallback: () =>
            {print("Form input -> $imePrezime $email $pitanje")},
      ),
    );
  }
}

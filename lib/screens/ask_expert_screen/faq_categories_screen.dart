import 'package:flutter/material.dart';

import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/custom_outline_button.dart';

class FaqCategoriesScreen extends StatelessWidget {
  static const String route = '/faq_categories';
  static const double _padding = 12;
  static const List<String> subCategories = [
    'Motorički razvoj',
    'Govorno-jezički razvoj',
    'Senzo-motorički razvoj',
    'Socio-emotivni razvoj',
    'Ishrana',
  ];

  const FaqCategoriesScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        appBar: const NewAppBar(),
        backgroundColor: Theme.of(context).primaryColor,
        body: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 20),
          child: SingleChildScrollView(
            child: Column(
              children: [
                const SizedBox(height: 24),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 44),
                  child: Text(
                    'Najčešće postavljena pitanja iz aspekta: ',
                    style: Theme.of(context).textTheme.headline2,
                    textAlign: TextAlign.center,
                  ),
                ),
                SizedBox(height: 25),
                ...subCategories.map((e) => _getColumnElement(e)).toList()
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _getColumnElement(String buttonText) {
    return Column(
      children: [
        CustomOutlineButton(text: buttonText, onClick: () {}),
        const SizedBox(height: _padding),
      ],
    );
  }
}

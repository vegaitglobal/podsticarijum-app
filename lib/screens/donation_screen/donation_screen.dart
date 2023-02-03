import 'package:flutter/material.dart';

import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/info_section_widget.dart';
import '../../common/widgets/default_container.dart';
import '../../common/widgets/default_header.dart';

class DonationScreen extends StatelessWidget {
  static const String route = '/clothing_donation';
  static const String loremIpsum =
      '"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliqui "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ';

  const DonationScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const NewAppBar(),
      body: DefaultContainer(
        children: [
          buildTitle(context, "Donacije"),
          const SizedBox(height: 68),
          const InfoSectionWidget(content: loremIpsum),
          const InfoSectionWidget(
            title: 'Informacije',
            content: loremIpsum,
            hasBorder: false,
          ),
          const SizedBox(height: 18),
        ],
      ),
    );
  }
}

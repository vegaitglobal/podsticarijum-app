import 'package:app_for_family_backup/api/podsticariju_api.dart';
import 'package:flutter/material.dart';

import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/info_section_widget.dart';
import '../../common/widgets/default_container.dart';
import '../../common/widgets/default_header.dart';

class DonationUiModel {
  String intro;
  String information;

  DonationUiModel(
    this.intro,
    this.information,
  );
}

class DonationScreen extends StatefulWidget {
  static const String route = '/clothing_donation';
  static const String loremIpsum =
      '"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliqui "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ';

  const DonationScreen({super.key});

  @override
  State<DonationScreen> createState() => _DonationScreenState();
}

class _DonationScreenState extends State<DonationScreen> {
  DonationUiModel? donationUiModel = null;

  void getDonationUiModel() async {
    var response = await PodsticarijumApi.getMainScreenContent("Donations");
    setState(() {
      if (response != null) {
        donationUiModel = DonationUiModel(
          response.text,
          response.additionalText ?? "",
        );
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    if (donationUiModel == null) getDonationUiModel();

    return Scaffold(
      appBar: const NewAppBar(),
      body: DefaultContainer(
        children: [
          buildTitle(context, "Donacije"),
          const SizedBox(height: 68),
          InfoSectionWidget(content: donationUiModel?.intro ?? ""),
          InfoSectionWidget(
            title: 'Informacije',
            content: donationUiModel?.information ?? "",
            hasBorder: false,
          ),
          const SizedBox(height: 18),
        ],
      ),
    );
  }
}

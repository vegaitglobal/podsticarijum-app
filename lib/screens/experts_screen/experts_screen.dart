import 'package:flutter/material.dart';

import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/default_container.dart';
import '../../common/widgets/default_header.dart';
import '../../common/widgets/text_with_header_widget.dart';

class ExpertsScreen extends StatelessWidget {
  static const String route = '/experts';
  const ExpertsScreen(this.teamNumber, {super.key});

  final int teamNumber;

  Widget buildExpertSection(String title, String content) {
    return Column(children: []);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: NewAppBar(),
      body: DefaultContainer(
        scale: 0.85,
        children: [
          buildTitle(context, "Tim $teamNumber"),
          const SizedBox(height: 68),
          TextWithHeaderWidget(
            "Petar Peric",
            _description,
          ),
          TextWithHeaderWidget(
            "Nikola Ivanovic",
            _description,
          ),
          TextWithHeaderWidget(
            "Djuro Radusinovic",
            _description,
            hasBorder: false,
          ),
          const SizedBox(height: 20),
        ],
      ),
    );
  }

  static const _description =
      """Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliqui "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.""";
}

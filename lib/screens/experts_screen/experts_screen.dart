import 'package:app_for_family_backup/api/models/ExpertModel.dart';
import 'package:app_for_family_backup/api/podsticariju_api.dart';
import 'package:app_for_family_backup/common/widgets/useful_widgets.dart';
import 'package:flutter/material.dart';

import '../../common/widgets/app_bar/new_app_bar.dart';
import '../../common/widgets/default_container.dart';
import '../../common/widgets/default_header.dart';
import '../../common/widgets/info_section_widget.dart';

class ExpertUiModel {
  List<ExpertHolder> expertList;
  ExpertUiModel(this.expertList);
}

class ExpertHolder {
  String fullName;
  String description;
  ExpertHolder(this.fullName, this.description);
}

class ExpertsScreen extends StatefulWidget {
  static const String route = '/experts';
  const ExpertsScreen({super.key});

  @override
  State<ExpertsScreen> createState() => _ExpertsScreenState();

  static const _description =
      """Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliqui "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.""";
}

class _ExpertsScreenState extends State<ExpertsScreen> {
  ExpertUiModel? expertUiModel = null;
  bool isError = false;

  void getExpertList() async {
    var response = await PodsticarijumApi.getExpertInfoList()
        .catchError((Object e, StackTrace stackTrace) {
      setState(() {
        isError = true;
        return null;
      });
    });
    List<ExpertHolder> expertList = [];
    response.forEach((element) {
      expertList.add(ExpertHolder(element.name, element.description));
    });
    setState(() {
      expertUiModel = ExpertUiModel(expertList);
    });
  }

  @override
  Widget build(BuildContext context) {
    if (expertUiModel == null && !isError) getExpertList();
    return Scaffold(
        appBar: const NewAppBar(),
        body: isError
            ? buildErrorScreen()
            : expertUiModel == null
                ? buildLoadingWidget(context)
                : _buildContent());
  }

  Widget _buildContent() {
    return DefaultContainer(
      scale: 0.85,
      children: [
        buildTitle(context, "Tim stručnjaka"),
        const SizedBox(height: 68),
        ...?expertUiModel?.expertList
            .getRange(
                0,
                expertUiModel == null
                    ? 0
                    : expertUiModel!.expertList.length - 1)
            .map((e) => InfoSectionWidget(
                  title: e.fullName,
                  content: e.description,
                )),
        InfoSectionWidget(
          title: expertUiModel?.expertList.last.fullName ?? "",
          content: expertUiModel?.expertList.last.description ?? "",
          hasBorder: false,
        ),
        const SizedBox(height: 20),
      ],
    );
  }
}

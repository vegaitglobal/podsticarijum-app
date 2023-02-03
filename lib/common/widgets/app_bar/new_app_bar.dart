import 'package:flutter/material.dart';

import '../../../screens/menu_screen/menu_screen.dart';
import '../../enums/app_bar_type.dart';

class NewAppBar extends StatelessWidget implements PreferredSizeWidget {
  static const double _topMargin = 30;
  const NewAppBar({
    Key? key,
    this.appBarType = AppBarType.rootNav,
  })  : preferredSize = const Size.fromHeight(kToolbarHeight + _topMargin),
        super(key: key);

  final AppBarType appBarType;

  @override
  final Size preferredSize;

  Color getBackgroundColor(BuildContext context) {
    if (appBarType == AppBarType.rootNav) {
      return Theme.of(context).primaryColor;
    } else {
      return Theme.of(context).scaffoldBackgroundColor;
    }
  }

  IconButton buildMenuAction(BuildContext context) {
    if (appBarType == AppBarType.rootNav) {
      return IconButton(
        onPressed: () => Navigator.pushNamed(context, MenuScreen.route),
        icon: const ImageIcon(
          AssetImage('images/menu_icon.png'),
          color: Colors.black,
        ),
      );
    } else {
      return IconButton(
        onPressed: () => Navigator.pop(context),
        icon: const Icon(
          Icons.close,
          color: Colors.black,
        ),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          //sized box didn't work here
          height: _topMargin,
          color: getBackgroundColor(context),
        ),
        AppBar(
          automaticallyImplyLeading: false,
          backgroundColor: getBackgroundColor(context),
          title: const Text('Podsticarijum'),
          titleTextStyle: Theme.of(context).textTheme.headline5,
          elevation: 0,
          actions: [buildMenuAction(context)],
        ),
      ],
    );
  }
}

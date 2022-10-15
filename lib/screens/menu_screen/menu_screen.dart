import 'package:flutter/material.dart';

import 'widgets/menu_item.dart';
import '../about_us_screen/screen_about_us.dart';
import '../ask_expert_screen/faq_categories_screen.dart';
import '../donation_screen/donation_screen.dart';
import '../experts_screen/experts_screen.dart';

class MenuScreen extends StatefulWidget {
  static const route = '/menu';

  const MenuScreen({super.key});

  @override
  State<MenuScreen> createState() => _MenuScreenState();
}

class _MenuScreenState extends State<MenuScreen> {
  int? selectedItemId;
  static const _navigationDelayMillis = 300;

  void onMenuSelected(BuildContext context, int menuItemId) async {
    setState(() {
      selectedItemId = menuItemId;
    });
    await Future.delayed(const Duration(milliseconds: _navigationDelayMillis));
    final String? routeName = getNavRoute();
    print("Selected menu item $menuItemId");
    if (routeName != null) {
      Navigator.pushNamed(context, routeName);
    }
  }

  String? getNavRoute() {
    switch (selectedItemId) {
      case 1:
        return AboutUsScreen.route;
      case 2:
        return ExpertsScreen.route;
      case 3:
        return DonationScreen.route;
      case 4:
        return FaqCategoriesScreen.route;
      default:
        return null;
    }
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        appBar: AppBar(
          automaticallyImplyLeading: false,
          title: const Text('Podsticarium'),
          titleTextStyle: Theme.of(context).textTheme.headline6,
          elevation: 0,
          actions: [
            IconButton(
              onPressed: () {},
              icon: const Icon(
                Icons.close,
                color: Color(0xFF0A0909),
              ),
            )
          ],
        ),
        body: Padding(
          padding: const EdgeInsets.only(top: 96),
          child: Column(
            children: [
              MenuItemWidget(
                id: 1,
                title: 'O nama',
                selectedItemId: selectedItemId,
                onSelected: onMenuSelected,
              ),
              MenuItemWidget(
                id: 2,
                title: 'Tim stručnjaka',
                selectedItemId: selectedItemId,
                onSelected: onMenuSelected,
              ),
              MenuItemWidget(
                id: 3,
                title: 'Donacije',
                selectedItemId: selectedItemId,
                onSelected: onMenuSelected,
              ),
              MenuItemWidget(
                id: 4,
                title: 'Najčešće postavljena pitanja',
                selectedItemId: selectedItemId,
                onSelected: onMenuSelected,
              ),
            ],
          ),
        ),
      ),
    );
  }
}

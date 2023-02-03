import 'package:app_for_family_backup/screens/debug_screen/debug_screen.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:flutter/material.dart';

import 'common/theme.dart';
import 'screens/categories_screen/subcategories_screen.dart';
import 'screens/categories_screen/categories_screen.dart';
import 'screens/category_details_screen/category_flags_screen.dart';
import 'screens/category_details_screen/category_details_more_screen.dart';
import 'screens/category_details_screen/category_details_screen.dart';
import 'screens/category_details_screen/category_intro_screen.dart';
import 'screens/donation_screen/donation_screen.dart';
import 'screens/frequent_questions_screen/frequent_questions_screen.dart';
import 'screens/about_us_screen/screen_about_us.dart';
import 'screens/ask_expert_screen/faq_categories_screen.dart';
import 'screens/experts_screen/experts_screen.dart';
import 'screens/menu_screen/menu_screen.dart';
import 'screens/splash_screen/splash_screen.dart';
import 'screens/thank_you_screen/thank_you_screen.dart';
import 'firebase_options.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Firebase.initializeApp(
    options: DefaultFirebaseOptions.currentPlatform,
  );
  runApp(const FamilyBackupApp());
}

class FamilyBackupApp extends StatelessWidget {
  const FamilyBackupApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: FamilyBackupTheme.familyAppThemeData,
      title: 'Podsticarijum',
      initialRoute: SplashScreen.route,
      routes: {
        DebugScreen.route: (context) => const DebugScreen(),
        SplashScreen.route: (context) => SplashScreen(),
        CategoriesScreen.route: (context) => const CategoriesScreen(),
        SubCategoriesScreen.route: (context) => const SubCategoriesScreen(),
        CategoryIntroScreen.route: (context) => CategoryIntroScreen(),
        CategoryDetailsScreen.route: (context) => const CategoryDetailsScreen(),
        CategoryDetailsMoreScreen.route: (context) =>
            CategoryDetailsMoreScreen(),
        CategoryFlagsScreen.route: (context) => CategoryFlagsScreen(),
        MenuScreen.route: (context) => const MenuScreen(),
        AboutUsScreen.route: (context) => const AboutUsScreen(),
        ExpertsScreen.route: (context) => const ExpertsScreen(),
        DonationScreen.route: (context) => const DonationScreen(),
        FaqCategoriesScreen.route: (context) => const FaqCategoriesScreen(),
        FaqAnswersScreen.route: (context) => FaqAnswersScreen(
              const {
                "neko pitanje": "neki odgovor",
                "neko pitanje 2": "neki odgovor 2",
                "neko pitanje 3": "neki odgovor 3",
                "PITANJE ALLOO": "neki odgovor",
                "neko pitanje 5": "neki odgovor",
                "neko pitanje 6": "neki odgovor",
                "neko pitanje 7": "neki odgovor",
              },
              "Motorički razvoj",
            ),
        ThankYouScreen.route: (context) => const ThankYouScreen()
      },
    );
  }
}

import 'package:app_for_family_backup/common/widgets/CustomForm.dart';
import 'package:flutter/material.dart';

class LoginScreen extends StatelessWidget {
  static String route = '/login';

  const LoginScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return FormCustom();
  }
}

import 'package:flutter/material.dart';

import 'default_header.dart';

class InfoSectionWidget extends StatelessWidget {
  final String content;
  final double spacing;
  final bool hasBorder;
  final TextStyle? textStyle;
  final String? title;

  const InfoSectionWidget({
    Key? key,
    required this.content,
    this.title,
    this.textStyle,
    this.spacing = 20.0,
    this.hasBorder = true,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        title != null ? buildTitle(context, title!) : const SizedBox.shrink(),
        SizedBox(height: spacing),
        Text(
          content,
          style: textStyle ?? Theme.of(context).textTheme.bodyText1,
        ),
        hasBorder
            ? Padding(
                padding: const EdgeInsets.symmetric(vertical: 24.0),
                child: Image.asset(
                  'images/separator.png',
                  width: double.infinity,
                  fit: BoxFit.fitWidth,
                ),
              )
            : const SizedBox.shrink()
      ],
    );
  }
}

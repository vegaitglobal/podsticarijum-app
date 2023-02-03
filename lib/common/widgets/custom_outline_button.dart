import 'package:flutter/material.dart';

class CustomOutlineButton extends StatelessWidget {
  final String text;
  final Function()? onClick;
  final bool isYellow;

  const CustomOutlineButton({
    super.key,
    required this.text,
    required this.onClick,
    this.isYellow = false,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 100,
      width: MediaQuery.of(context).size.width,
      decoration: BoxDecoration(
        image: DecorationImage(
          image: isYellow
              ? const AssetImage('images/button_bg_yellow.png')
              : const AssetImage('images/button_bg.png'),
          fit: BoxFit.contain,
        ),
      ),
      child: OutlinedButton(
        onPressed: onClick,
        style: OutlinedButton.styleFrom(
          side: const BorderSide(
            color: Colors.transparent,
          ),
          backgroundColor: Colors.transparent,
        ),
        child: Text(text.toUpperCase(),
            style: Theme.of(context).textTheme.headline2?.copyWith(
                  fontSize: 33,
                ) //some text weren't able to fit with larger letters,
            ),
      ),
    );
  }
}

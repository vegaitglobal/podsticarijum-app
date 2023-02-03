import 'package:flutter/material.dart';

class ScrollableContentWidget extends StatelessWidget {
  const ScrollableContentWidget({
    super.key,
    required this.title,
    required this.content,
    this.subtitle,
    this.children,
  });

  final String? subtitle;
  final String title;
  final String content;
  final List<Widget>? children;

  double get backgroundOffset => subtitle != null ? 0 : -100;

  Widget _renderSubtitle(BuildContext context) {
    if (subtitle == null) return const SizedBox(height: 0);

    return Column(
      children: [
        Text(
          subtitle!,
          style: Theme.of(context).textTheme.headline4,
        ),
        const SizedBox(height: 16),
      ],
    );
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Stack(
        children: [
          Positioned(
            top: backgroundOffset,
            child: Image.asset('images/about_us_bg.png', scale: 0.8),
          ),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(height: 20),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 20),
                child: _renderSubtitle(context),
              ),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 20),
                child: Text(
                  title,
                  style: Theme.of(context).textTheme.headline3,
                ),
              ),
              const SizedBox(height: 68),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 20),
                child: Text(
                  content,
                  style: Theme.of(context).textTheme.bodyText1,
                ),
              ),
              const SizedBox(height: 35),
              ...?children,
              Padding(
                padding: const EdgeInsets.only(top: 22, bottom: 36),
                child: Image.asset('images/logo.png'),
              )
            ],
          ),
        ],
      ),
    );
  }
}

import 'package:flutter/material.dart';

class CustomTextFormField extends StatelessWidget {
  static const Color _hintColor = Color(0xFF706F6F);
  static const double _borderWidth = 1;
  static const double _borderRadius = 10;

  final String emptyErrorMessage;
  final String invalidErrorMessage;
  final String hint;
  final String? labelText;
  final double? width = null;
  final double bottomMargin;
  final bool largeInputField;
  final bool Function(String value) isValid;
  final void Function(String?)? onSaved;

  const CustomTextFormField({
    this.isValid = _foo,
    this.invalidErrorMessage = "",
    this.emptyErrorMessage = "*Obavezno polje",
    this.bottomMargin = 0,
    this.hint = "hint",
    this.labelText,
    this.largeInputField = false,
    this.onSaved,
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          labelText ?? "",
          style: Theme.of(context).textTheme.bodyText1?.copyWith(fontSize: 20),
        ),
        const SizedBox(height: 10),
        Container(
          alignment: Alignment.center,
          child: TextFormField(
            textAlign: TextAlign.start,
            minLines: largeInputField ? 12 : 1,
            maxLines: largeInputField ? 20 : 1,
            style: Theme.of(context)
                .textTheme
                .bodyText1
                ?.copyWith(color: Colors.black),
            decoration: InputDecoration(
                contentPadding:
                    const EdgeInsets.symmetric(horizontal: 13, vertical: 10),
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(_borderRadius),
                  borderSide: const BorderSide(
                    width: _borderWidth,
                    color: Colors.black,
                  ),
                ),
                focusedBorder: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(_borderRadius),
                  borderSide: const BorderSide(
                    width: _borderWidth,
                    color: Colors.black,
                  ),
                ),
                hintText: hint,
                hintStyle: Theme.of(context).textTheme.bodyText1?.copyWith(
                      color: _hintColor,
                    ),
                errorStyle: Theme.of(context)
                    .textTheme
                    .bodyText1
                    ?.copyWith(color: Colors.red)),
            validator: (value) {
              if (value == null || value.isEmpty) return emptyErrorMessage;
              if (!isValid(value)) return invalidErrorMessage;

              return null;
            },
            onSaved: (value) {
              if (onSaved != null) onSaved!(value);
            },
          ),
        ),
        SizedBox(
          height: bottomMargin,
        )
      ],
    );
  }

  static bool _foo(String str) => true; // default placeholder
}

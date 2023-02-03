import 'package:flutter/material.dart';
import 'custom_outline_button.dart';

class CustomForm extends StatefulWidget {
  final List<Widget> children;
  final String submitButtonText;
  final Function(bool) onValidCallback; // data contains information about
  final Future<void> Function() onClick; // pass async function as parameter

  const CustomForm({
    Key? key,
    required this.children,
    required this.submitButtonText,
    required this.onValidCallback,
    required this.onClick,
  }) : super(key: key);

  @override
  State<CustomForm> createState() => _CustomFormState();
}

class _CustomFormState extends State<CustomForm> {
  final _formKey = GlobalKey<FormState>();
  bool _loading = false;

  @override
  Widget build(BuildContext context) {
    // widget.button!.setOnClickAsync(updateAsyncFun);
    void toggleLoading() {
      setState(() {
        _loading = !_loading;
      });
    }

    void validateForm() {
      if (_formKey.currentState!.validate()) {
        _formKey.currentState?.save();
      }
    }

    return SingleChildScrollView(
      child: Form(
        key: _formKey,
        child: Container(
          color: Colors.transparent,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              ...widget.children,
              CustomOutlineButton(
                isYellow: _loading ? false : true,
                text: _loading ? 'Mail se šalje...' : widget.submitButtonText,
                onClick: _loading
                    ? null
                    : () async {
                        if (!_loading) {
                          validateForm();
                          toggleLoading();
                          await widget.onClick();
                          toggleLoading();
                          // await widget.onValidCallback();
                        }
                      },
              ),
            ],
          ),
        ),
      ),
    );
  }
}

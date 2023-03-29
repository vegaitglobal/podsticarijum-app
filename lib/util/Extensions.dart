extension StringUtils on String? {
  String orEmpty() {
    return this ?? "";
  }
}

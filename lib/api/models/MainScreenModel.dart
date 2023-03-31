class MainScreenModel {
  int id;
  String contentType;
  String text;
  String? additionalText;

  MainScreenModel.fromJson(Map<String, dynamic> json)
      : id = json['id'],
        contentType = json['contentType'],
        text = json['text'],
        additionalText = json['additionalText'];
}

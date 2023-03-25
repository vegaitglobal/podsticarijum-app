class AboutUsModel {
  String description;

  AboutUsModel.fromJson(Map<String, dynamic> json) : description = json['text'];
}

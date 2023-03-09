class FAQModel {
  String description;
  String information;

  FAQModel.fromJson(Map<String, dynamic> json)
      : description = json['question'],
        information = json['answer'];
}

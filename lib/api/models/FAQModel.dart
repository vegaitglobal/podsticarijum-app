class FAQModel {
  String question;
  String answer;

  FAQModel.fromJson(Map<String, dynamic> json)
      : question = json['question'],
        answer = json['answer'];
}

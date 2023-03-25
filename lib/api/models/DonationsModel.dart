class DonationsModel {
  String description;
  String information;

  DonationsModel.fromJson(Map<String, dynamic> json)
      : description = "some random description",
        information = json['text'];
  // : description = json['description'],
  // information = json['text'];
}

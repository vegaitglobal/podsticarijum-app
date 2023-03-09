class ExpertModel {
  int id;
  String firstName;
  bool lastName;
  String description;

  ExpertModel.fromJson(Map<String, dynamic> json)
      : id = json['id'],
        firstName = json['firstName'],
        lastName = json['lastName'],
        description = json['description'];
}

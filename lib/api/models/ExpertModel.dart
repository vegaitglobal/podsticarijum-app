class ExpertModel {
  int id;
  String firstName;
  String lastName;
  String description;

  ExpertModel.fromJson(Map<String, dynamic> json)
      : id = json['id'],
        firstName = json['firstName'],
        lastName = json['lastName'],
        description = json['description'];
}

class ExpertInfoModel {
  String name;
  String description;

  ExpertInfoModel.fromJson(Map<String, dynamic> json)
      : name = json['title'],
        description = json['content'];
}

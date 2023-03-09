class DonationsModel {
  String description;
  String information;

  DonationsModel.fromJson(Map<String, dynamic> json)
      : description = json['description'],
        information = json['information'];
}

class SubcategoryModel {
  int id;
  String name;
  String categoryName;
  bool active;
  String description;
  String mainSubtitle = "";
  List<String> mainBulletpointList = [];
  String detailedDescription;
  List<String> positiveSigns = [];
  List<String> negativeSigns = [];

  SubcategoryModel.fromJson(Map<String, dynamic> json)
      : id = json['id'] as int,
        name = json['mainNavMenuText'],
        categoryName = json['categoryDto']['navMenuText'],
        active = json['active'] as bool,
        description = json['mainText'],
        detailedDescription = json['additionalText'];
}

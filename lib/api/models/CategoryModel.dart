class CategoryModel {
  int id;
  String categoryName;
  String description;
  CategoryModel(
      {required this.id,
      required this.categoryName,
      required this.description});

  CategoryModel.fromJson(Map<String, dynamic> json)
      : id = json['id'] as int,
        categoryName = json['navMenuText'],
        description = json['description'];
}

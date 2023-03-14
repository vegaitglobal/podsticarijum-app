import 'dart:convert';
import 'package:app_for_family_backup/api/models/AboutUsModel.dart';
import 'package:app_for_family_backup/api/models/DonationsModel.dart';
import 'package:app_for_family_backup/api/models/ExpertModel.dart';
import 'package:app_for_family_backup/api/models/SubcategoryModel.dart';
import 'package:get/get.dart';
import 'package:http/http.dart' as http;
import 'models/CategoryModel.dart';

class PodsticarijumApi {
  static const String BASE_URL = "http://10.0.2.2:23000";
  static PodsticarijumApi? _instance = null;
  PodsticarijumApi._internal();

  static PodsticarijumApi getInstance() {
    if (_instance == null) {
      _instance = PodsticarijumApi._internal();
    }

    return _instance!;
  }

  static Future<List<CategoryModel>> getCategoryList() async {
    const String url = "$BASE_URL/api/category";
    List<CategoryModel> categoryList = [];

    final response = await http.get(
      Uri.parse(url),
      // headers: {'Content-Type': 'application/json; charset=UTF-8'},
    );
    if (response.statusCode != 200) return categoryList;
    // print("RESPONSE - $response");
    List<dynamic> categoryListJson = json.decode(response.body);
    categoryListJson.forEach((value) {
      categoryList.add(CategoryModel.fromJson(value as Map<String, dynamic>));
    });

    return categoryList;
  }

  static Future<List<SubcategoryModel>> getSubcategoryList(
      int categoryId) async {
    String url = "${BASE_URL}/api/category/$categoryId/sub-category";
    List<SubcategoryModel> subcategoryList = [];
    var response = await http.get(Uri.parse(url));
    if (response.statusCode != 200) return subcategoryList;

    List<dynamic> subcategoryListJson = json.decode(response.body);
    subcategoryListJson.forEach((json) {
      if (json["active"]) subcategoryList.add(SubcategoryModel.fromJson(json));
    });

    return subcategoryList;
  }

  static Future<SubcategoryModel?> getSubcategory(int subcategoryId) async {
    String url = "${BASE_URL}/api/sub-category/$subcategoryId";
    var response = await http.get(Uri.parse(url));

    return SubcategoryModel.fromJson(json.decode(response.body));
  }

  static Future<SubcategoryModel?> getSubcategoryWithCategoryId(
      int categoryId, int subcategoryId) async {
    var subcategoryList = await getSubcategoryList(categoryId);
    SubcategoryModel subcategory;
    return subcategoryList
        .firstWhereOrNull((element) => element.id == subcategoryId);
  }

  static Future<List<ExpertModel>> getExperts() async {
    String url = "${BASE_URL}/api/expert";
    List<ExpertModel> expertList = [];
    var response = await http.get(Uri.parse(url));
    List<dynamic> expertListJson = json.decode(response.body);
    expertListJson.forEach((json) {
      expertList.add(ExpertModel.fromJson(json));
    });

    return expertList;
  }

  static Future<DonationsModel> getDonation() async {
    String url = "${BASE_URL}/api/donation";
    var response = await http.get(Uri.parse(url));
    Map<String, dynamic> donationJson = json.decode(response.body);

    return DonationsModel.fromJson(donationJson);
  }

  static Future<AboutUsModel> getAboutUs() async {
    String url = "${BASE_URL}/api/aboutus";
    var response = await http.get(Uri.parse(url));
    Map<String, dynamic> aboutusJson = json.decode(response.body);

    return AboutUsModel.fromJson(aboutusJson);
  }
}

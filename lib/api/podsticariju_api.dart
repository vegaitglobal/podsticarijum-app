import 'dart:convert';
import 'package:app_for_family_backup/api/models/AboutUsModel.dart';
import 'package:app_for_family_backup/api/models/DonationsModel.dart';
import 'package:app_for_family_backup/api/models/ExpertModel.dart';
import 'package:app_for_family_backup/api/models/FAQModel.dart';
import 'package:app_for_family_backup/api/models/MainScreenModel.dart';
import 'package:app_for_family_backup/api/models/SubcategoryModel.dart';
import 'package:get/get.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';
import '../screens/category_details_screen/category_flags_screen.dart';
import 'models/CategoryModel.dart';

class PodsticarijumApi {
  static const String BASE_URL = "https://podsticarijum.codeforacause.rs";
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
    );
    if (response.statusCode != 200) return categoryList;
    List<dynamic> categoryListJson = json.decode(response.body);
    categoryListJson.forEach((value) {
      categoryList.add(CategoryModel.fromJson(value as Map<String, dynamic>));
    });

    if (categoryList.isEmpty == null) {
      return Future.error("Parsing error occured");
    }
    return categoryList;
  }

  static Future<List<SubcategoryModel>> getSubcategoryListByCategoryId(
      int categoryId) async {
    String url = "${BASE_URL}/api/category/$categoryId/sub-category";
    List<SubcategoryModel> subcategoryList = [];
    var response = await http.get(Uri.parse(url));
    if (response.statusCode != 200) return subcategoryList;

    List<dynamic> subcategoryListJson = json.decode(response.body);
    subcategoryListJson.forEach((json) {
      subcategoryList.add(SubcategoryModel.fromJson(json));
    });

    if (subcategoryList.isEmpty == null) {
      return Future.error("Parsing error occured");
    }
    return subcategoryList;
  }

  static Future<SubcategoryModel?> getSubcategory(int subcategoryId) async {
    String url = "${BASE_URL}/api/sub-category/$subcategoryId";
    var response = await http.get(Uri.parse(url));

    return SubcategoryModel.fromJson(json.decode(response.body));
  }

  static Future<SubcategoryModel?> getSubcategoryWithCategoryId(
      int categoryId, int subcategoryId) async {
    var subcategoryList = await getSubcategoryListByCategoryId(categoryId);
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
    if (expertList.isEmpty == null) {
      return Future.error("Parsing error occured");
    }
    return expertList;
  }

  static Future<DonationsModel> getDonation() async {
    String url = "${BASE_URL}/api/main-screen?contentType=donations";
    // final uri =
    //     Uri.https(BASE_URL, "api/main-screen", {'contentType': 'donations'});
    var response = await http.get(Uri.parse(url));
    var donationJson = json.decode(response.body);

    return DonationsModel.fromJson(donationJson);
  }

  static Future<AboutUsModel> getAboutUs() async {
    String url = "${BASE_URL}/api/main-screen?contentType=aboutUs";
    var response = await http.get(Uri.parse(url));
    Map<String, dynamic> aboutusJson = json.decode(response.body);

    return AboutUsModel.fromJson(aboutusJson);
  }

  static Future<MainScreenModel?> getMainScreenContent(
      String contentType) async {
    String url = "${BASE_URL}/api/main-screen";
    var response = await http.get(Uri.parse(url));
    List<dynamic> mainScreenModelListJson = json.decode(response.body);

    MainScreenModel? result = null;
    mainScreenModelListJson.forEach((elementJson) {
      MainScreenModel data = MainScreenModel.fromJson(elementJson);
      if (data.contentType == contentType) result = data;
    });
    if (result == null) {
      return Future.error("Parsing error occured");
    }
    return result;
  }

  static Future<List<FAQModel>> getFaqList(int subcategoryId) async {
    String url = "${BASE_URL}/api/category/$subcategoryId/faq";
    var response = await http.get(Uri.parse(url));
    List<dynamic> faqList = json.decode(response.body);
    List<FAQModel> faqModelList = [];
    faqList.forEach((element) {
      faqModelList.add(FAQModel.fromJson(element));
    });
    if (faqModelList.isEmpty == null) {
      return Future.error("Parsing error occured");
    }
    return faqModelList;
  }

  static Future<List<SubcategoryModel>> getSubcategoryList() async {
    String url = "$BASE_URL/api/sub-category";
    var response = await http.get(Uri.parse(url));
    List<SubcategoryModel> subcategoryList = [];
    List<dynamic> subcategoryListJson = json.decode(response.body);
    subcategoryListJson.forEach((element) {
      subcategoryList.add(SubcategoryModel.fromJson(element));
    });

    if (subcategoryList.isEmpty == null) {
      return Future.error("Parsing error occured");
    }
    return subcategoryList;
  }

  static Future<List<String>> getSubcategoryEmailList(int subcategoryId) async {
    String url = "$BASE_URL/api/sub-category/$subcategoryId/email";
    var response = await http.get(Uri.parse(url));
    List<String> emailList = [];
    List<dynamic> emailListJson = json.decode(response.body);
    emailListJson.forEach((element) {
      emailList.add(element["userMailAddress"]);
    });

    if (emailList.isEmpty == null) {
      return Future.error("Parsing error occured");
    }
    return emailList;
  }

  static Future<bool> sendEmail(
      String name, String mail, String question, int subcategoryId) async {
    EmailPayloadDto emailPayload = EmailPayloadDto(name, mail, question);

    final url = "$BASE_URL/api/sub-categeory/$subcategoryId/email";

    try {
      http.Response response = await post(
        Uri.parse('https://podsticarijum.codeforacause.rs/email'),
        headers: {'Content-Type': 'applicatfion/json; charset=UTF-8'},
        body: jsonEncode(emailPayload.toJson()),
      ).timeout(
        const Duration(seconds: 5),
      );

      return response.statusCode == 200;
    } on Exception catch (_) {
      return false;
    }
  }
}

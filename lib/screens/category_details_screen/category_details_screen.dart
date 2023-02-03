import 'package:flutter/material.dart';

import '../../common/widgets/scrollable_content/scrollable_content_widget.dart';
import '../../common/enums/flag_type.dart';
import '../../common/widgets/scrollable_content/flag_section.dart';

class CategoryDetailsScreen extends StatelessWidget {
  static String route = '/category-details';

  const CategoryDetailsScreen({super.key});

  static const String _greenFlag1Content =
      'Dajte detetu sve vrste taktilnih stimulaija - blage dodire (maženje, dodire sa nekim lakim materijalom, prljavština na koži, voda, hrana oko usana), duboke pritiske koji se stvaraju aktivnostima kao što su masaže, medveđi zagrljaj,tapkanje, kotrljanje (ovi taktilni doživljaji daju senzorne informacije zglobovima i mišićima), vibracije(vibrirajuće stolice,igračke, masažeri). Dajte im priliku da oseti različite površine (celim telom, šakama i stopalima) i tako primeti razlike.Napravite male jastučiće da može njima da manipuliše, trlja po licu i telu,opipava, baca i ubacuje. napravite male taktilne podloge da leži i prelazi preko njih..Boravite u prirodi i opipavajte travu, pesak, cveće.. ';

  static const String _greenFlag2Content =
      'Koristite mobile (predmeti koji doprinose razvoju zapažanja i  stimulišu zadržavanje bebine pažnje na nečemu),okačite ih tamo gde beba spava ili provodi vreme dok je na leđima, na par nedelja ili na mesečnom nivou, menjajte ih – npr. mobil sa kuglama, mobil sa plesačima I slično. Okačite predmete za elastičnu traku, da vise iznad bebe ( balone, mekane kugle, lopte, tkanine, razne krupne predmete i igraćke), kako bi ih pratila očima, dirala, udarala, hvatala, držala.. – ujedno uvežbavala kontrolu šake i ruke';

  static const String _greenFlag3Content =
      'Puštajte različite bele šumove (zvuci prirode, npr.talase,kišu..);obezbedite više zvečki koje različito zveckaju (dajete jednu po jednu, da istažuje i osluškuje pojedinačno, posle određenog vremena, dana, nedelja, kada primetite da je motivacija opala, zamenite sledećom). Možete napraviti loptu od neke tkanine u kojoj ćete ubaciti zvončiće ili praporce i držati i igrati se sa detetom ili okačiti iznad mesta gde dete provodi vreme da bi rukama i nogama, dok leži na leđima, mogla da udara i hvata, da se odiže od podloge..dakle tako stimulišete i motoričke radnje.';

  static const String _greenFlag4Content =
      'Što češće da boravi na stomaku (motivišite i animirajte omiljenom igračkom, da posegne za njom, da je dohvati, da pokušava da se pomeri do nje..).Kkoristite valjak preko kojeg će da se odiže, leži, prelazi preko njega. Nekaa boravi na pilates ili lopti za skakanje - na stomaku, da se odiže, održava ravnotežu glave, ramena, da se drži za štap(da bude ispred nje), za drvene krugove (koji mogu visiti). Valjkastim predmetima je stiskajte i masirajte dajući joj dublji pritisak na zglobove i mišiće; napravite jestivi plastelin, da stiska, kida i njime vežba šake i prste.';

  static const String _redFlag1Content =
      'Problemi u samoregulaciji – prekomerno plakanje,poremećaji organizacije spavanja i budnosti i problemi u hranjenju. 10-12 mesec prekomerni strah od odvajanja od roditelja,majke i strah od nepoznatih ljudi(da ne podnosi da ga dodiruju i nose).';
  static const String _redFlag2Content =
      'Ne reaguje na svetlo, ne prati pogledom, ne zadržava pogled na lice osobe, predmet..';
  static const String _redFlag3Content =
      'Ne reaguje na zvuke u prvim mesecima, a do godinu dana izostaju reakcije na slabije zvuke. Izostaje gugutanje, brbljanje.';
  static const String _redFlag4Content =
      'Preterano mirno ili razdražljivo, mlitavo ili zgrčeno  ';

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: ScrollableContentWidget(
          title: 'NEUROTIPIČAN SENZO-MOTORNI RAZVOJ',
          subtitle: '0-1 GODINA',
          content: _description,
          children: [
            Container(
              decoration: const BoxDecoration(
                image: DecorationImage(
                  image: AssetImage('images/green_flag_section_bg.png'),
                  fit: BoxFit.fill,
                ),
              ),
              child: Padding(
                padding: const EdgeInsets.symmetric(horizontal: 20),
                child: Column(
                  children: [
                    const SizedBox(height: 20),
                    Text(
                      'PODSTICARIJUMNE IGRE I AKTIVNOSTI, STIMULATIVNE ZA RAZVOJ VAŠE BEBE I DETETA',
                      style: Theme.of(context).textTheme.headline3,
                    ),
                    const SizedBox(height: 12),
                    const FlagSection(
                      content: _greenFlag1Content,
                      flagType: FlagType.green,
                    ),
                    const FlagSection(
                      content: _greenFlag2Content,
                      flagType: FlagType.green,
                    ),
                    const FlagSection(
                      content: _greenFlag3Content,
                      flagType: FlagType.green,
                    ),
                    const FlagSection(
                      content: _greenFlag4Content,
                      flagType: FlagType.green,
                    ),
                    const SizedBox(height: 16),
                  ],
                ),
              ),
            ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 20),
              child: Column(
                children: [
                  const SizedBox(height: 20),
                  Text(
                    'ZNAKOVI ODSTUPANJA OD NEUROTIPIČNOG RAZVOJA',
                    style: Theme.of(context).textTheme.headline3,
                  ),
                  const SizedBox(height: 12),
                  const FlagSection(
                    content: _redFlag1Content,
                    flagType: FlagType.red,
                  ),
                  const SizedBox(height: 16),
                  const FlagSection(
                    content: _redFlag2Content,
                    flagType: FlagType.red,
                  ),
                  const SizedBox(height: 54),
                  const FlagSection(
                    content: _redFlag3Content,
                    flagType: FlagType.red,
                  ),
                  const SizedBox(height: 48),
                  const FlagSection(
                    content: _redFlag4Content,
                    flagType: FlagType.red,
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }

  static const _description =
      """Osećaji koji dolaze preko kože, putem dodira, su veoma važni tokom prvih meseci života bebe, ali i tokom celog perioda odrastanja. Preko čula dodira dete ostvaruje kontakt sa majkom dok ga doji, sa roditeljima dok ga kupaju, masiraju, mažu, maze, a dok stavlja svoje prste, šake, stopala u usta, dete upoznaje svoje telo.Vremenom se navikava na dodire, maženje i nošenje ostalih članova porodice i ljudi iz okruženja.

Novorođenče vidi crno-bele slike. U prvim mesecima na svetlo reaguje trepćući, a prijaju mu i privlače ga kontrasti boja.Registruje lice osobe (privlače ga pokreti očiju i usana) a zatim počinje da prati osobu koja se kreće. Do 6.og meseca, beba je u stanju da razgleda okolinu, primećuje sitnije predmete i očima prati predmete koji se kreću, padnu, sijaju..vidi i poseže za njima. Do navršene prve godine prepoznaje mnoge predmete iz svog okruženja, prati pogledom putanju predmeta koji se brzo kreću, približavaju,udaljavaju (npr..loptu). Ume da se zaigra jednom igračkom par minuta i zadrži pažnju na osobi koja govori. Reaguje na emocionalni izraz odraslog.

Dete, u prvim mesecima,reaguje na jače i iznenadne zvukove pokretima ruku i nogu ili treptanjem. Smiruje se kada.mu se priča ujednačenim tonom ili kada sluša laganu muziku.Pokušavaće da odredi odakle dopire zvuk (okretanjem glave) i prepoznavaće ljudski glas (npr.reagovaće osmehom). Otprilike do 6og meseca već obraća pažnju na govor drugih i pokušava da reprodukuje(gugutanje, brbljanje),da namerno pomoću predmeta proizvodi zvukove.U narednom periodu počinje da reaguje na muzičke ritmove, pokretom(da cupka, klati se), da sluša i imitira zvukove iz okoline, pravilno lokalizuje izvor zvuka.
Novorođenče ima veoma razvijeno čulo mirisa koje mu omogućava da prepozna miris svoje majke, njenog tela i njenog mleka(prema kom se okreće). Istražuje predmete mirišući ih.
Ukoliko mu nešto mije po ukusu, menja izraz lica, okreće glavu i luči veću količinu pljuvačke.Jasno  stavlja do znanja koja mu hrana manje odnosno više prija. 

U prva 3,4 meseca, dete odiže glavu od podloge ležeći na trbuhu i u tom položaju se oslanja na podlaktice .Može da zadrži predmet koji mu je stavljen u ruku i da hvata 1predmet na dodir. Igra se i upoznaje sa svojim rukama. Do otprilike 6og meseca, manipuliše i trese predmet stavljen u ruku,ispituje predmete oralno (stavlja ih u usta). Ležeći na stomaku veći deo težine oslanja na ruke, prevrće se iz trbušnog u leđni položaj. Prinosi i ispituje stopala ustima. Polako počinje da sedi, po nekoliko sekundi, uz oslonac, dok glavu drži čvrsto. Počinje da puzi, može da lupa jednim predmetom o drugi, kažiprstom da gura predmete, uzima i svojevoljno pušta predmete,doseže i hvata predmet nadohvat ruke. Počinje samostalno da sedi.(7-9). Oko 1.godine samostalno stoji po nekoliko sekundi , hoda dok ga držite za ruke i menja položaje tela  da bi dohvatio predmete
 """;
}

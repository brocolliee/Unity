# Save Data with XML



 Unity에서는 다양한 방법으로 게임 데이터를 관리 할 수 있다.  여러가지 방법 중 XML 파일을 사용하여 게임 데이터를 관리 하는 방법에 대해 알아보고자 한다.

 게임 아이템, 사용자의 정보, 게임 진행 상황 (점수), 설정 등을 저장하기 위해서 사용한다. 

##### 장점

- 쉽게 사용 가능
- 전체 클래스 혹은 단독 데이터 저장 가능
- 유니티 외부에서도 쉽게 수정 가능

##### 단점

- 유니티 외부에서도 쉽게 수정 가능



#### xml 파일 저장 경로

- **Windows** :  Application.dataPath

- **Android** :  Application.persistentDataPath



## XML 생성

처음에 XML 파일을 생성 (게임 완전 처음 시작, 회원가입 등)

 `using System.Xml;`  -> Xml 관련 함수 사용하기 위함

~~~~c#
public void WriteXML()
    {
        string filepath;

        // Android 일 때 file path
#if UNITY_ANDROID
        filepath = Application.persistentDataPath + "/test.xml";
#endif
        // Windows 일 때 file path
#if UNITY_STANDALONE_WIN
        filepath = Application.dataPath + "/test.xml";
#endif

        // 새로운 XML Document 만들기
        XmlDocument Document = new XmlDocument();

        // XML 버전, 인코딩 등 정보 추가
        XmlDeclaration xmlDeclaration = Document.CreateXmlDeclaration("1.0", "UTF-8", null);
        // Document에 추가 하기
        Document.AppendChild(xmlDeclaration);

        // Element 생성
        XmlElement element = Document.CreateElement("Players");
        // Element를 Document에 추가
        Document.AppendChild(element);

        // player 5개 생성
        for(int i = 0; i < 5; i++)
        {
            // Element 생성
            XmlElement playerEle = Document.CreateElement("Player");
            // Element의 attribute 넣기
            playerEle.SetAttribute("id", i.ToString());

            // playerEle 의 child - Name
            XmlElement nameEle = Document.CreateElement("Name");
            nameEle.InnerText = "player" + i;
            playerEle.AppendChild(nameEle);

            // playerEle 의 child Name
            XmlElement scoreEle = Document.CreateElement("Score");
            scoreEle.InnerText = "0";
            playerEle.AppendChild(scoreEle);

            element.AppendChild(playerEle);
        }
        
        //Document저장하기
        Document.Save(filepath);
        Debug.Log(Document);

    }
~~~~



- 결과 test.xml 파일

  ~~~xml
  <?xml version="1.0" encoding="UTF-8"?>
  <Players>
    <Player id="0">
      <Name>player0</Name>
      <Score>0</Score>
    </Player>
    <Player id="1">
      <Name>player1</Name>
      <Score>0</Score>
    </Player>
    <Player id="2">
      <Name>player2</Name>
      <Score>0</Score>
    </Player>
    <Player id="3">
      <Name>player3</Name>
      <Score>0</Score>
    </Player>
    <Player id="4">
      <Name>player4</Name>
      <Score>0</Score>
    </Player>
  </Players>
  ~~~

  

## XML 파일 읽기

기기에 저장되어있는 XML 파일을 읽기 (로그인 등)

~~~c#
public void ReadXML()
    {
        string filepath;

        // Android 일 때 file path
#if UNITY_ANDROID
        filepath = Application.persistentDataPath + "/test.xml";
#endif
        // Windows 일 때 file path
#if UNITY_STANDALONE_WIN
        filepath = Application.dataPath + "/test.xml";
#endif

        // 새로운 XML Document 만들기
        XmlDocument Document = new XmlDocument();

        // file path에서 XML 문서 불러오기
        Document.Load(filepath);

        //첫번째 element 불러오기
        XmlElement Players = Document["Players"];
        
        // Players element에 있는 자식 노드를 하나씩 읽어온다. 
        foreach(XmlElement player in Players.ChildNodes)
        {
            // Attribute 읽어오기
            string id = player.GetAttribute("id");

            // Child element의 text 읽어오기
            string name = player.SelectSingleNode("Name").InnerText;
            string score = player.SelectSingleNode("Score").InnerText;

            Debug.Log(name + " -  id " + id + " , score : " + score);

        }

    }
~~~



## XML 파일 수정

존재하는 XML 파일을 읽어와 수정

~~~c#
 public void ModifyXML()
    {
        string filepath;

        // Android 일 때 file path
#if UNITY_ANDROID
        filepath = Application.persistentDataPath + "/test.xml";
#endif
        // Windows 일 때 file path
#if UNITY_STANDALONE_WIN
        filepath = Application.dataPath + "/test.xml";
#endif
        // 새로운 XML Document 만들기
        XmlDocument Document = new XmlDocument();

        // file path에서 XML 문서 불러오기
        Document.Load(filepath);
        //첫번째 element 불러오기
        XmlElement Players = Document["Players"];

        // Players element에 있는 자식 노드를 하나씩 읽어온다. 
        foreach (XmlElement player in Players.ChildNodes)
        {
            // Player element에 attribute 추가
            player.SetAttribute("pw", "1234");

            //Score 값 변경
            player.SelectSingleNode("Score").InnerText = "3";

            // Name element 지우기
            player.RemoveChild(player.SelectSingleNode("Name"));

            // Item element 추가
            XmlElement itemEle = Document.CreateElement("Item");
            itemEle.InnerText = "None";
            player.AppendChild(itemEle);

            // 수정한 데이터를 바꿔주기
            Players.ReplaceChild(player, player);
        }

        //Document저장하기
        Document.Save(filepath);
    }
~~~

- 결과 test.xml 파일

  ~~~xml
  <?xml version="1.0" encoding="UTF-8"?>
  <Players>
    <Player id="0" pw="1234">
      <Score>3</Score>
      <Item>None</Item>
    </Player>
    <Player id="1" pw="1234">
      <Score>3</Score>
      <Item>None</Item>
    </Player>
    <Player id="2" pw="1234">
      <Score>3</Score>
      <Item>None</Item>
    </Player>
    <Player id="3" pw="1234">
      <Score>3</Score>
      <Item>None</Item>
    </Player>
    <Player id="4" pw="1234">
      <Score>3</Score>
      <Item>None</Item>
    </Player>
  </Players>
  ~~~

  
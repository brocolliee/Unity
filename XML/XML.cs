using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml; 

public class XML : MonoBehaviour
{
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
}

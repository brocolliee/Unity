# Text - Unity UI

class in UnityEngine.UI

### Text

- 글꼴 데이터를 화면에 그리는 기본 그래픽
- UI의 Visual Components 중 하나

- Inspector 에서 Text 속성 설정
  - 글자의 텍스트, Font, Font Style, Size, Line Spacing , Rich Text 를 설정 가능
  - 문단의 Alignment, Align By Geometry, Horizontal OverFlow , Vertical OverFlow, Best Fit 설정 가능
  - 텍스트의  색상, Meterial, Raycast Target 설정 가능

- 스크립트를 사용하여 Text 속성을 설정할 때 Inspector에서 설정하는 것보다 많이 지원한다.
  - 자세한 사항은 [Unity Text 사이트]( https://docs.unity3d.com/kr/530/ScriptReference/UI.Text.html  ) 참고



## 개발 노트

- Button 자식으로 기본 생성 되어 글자가 보임
- Canvas에도 작성 했듯이 Screen을 Overlay 했을 때 블러된 것 처럼 흐려보이는 현상이 나타나기도하여 Canvas의 Pixel Perfect 사용

- 경고창 같은 경우 글자를 경우에 따라 바꿔줘야해 Text class 에 있는 변수 text를 사용해 바꿔주었다. 
- 하지만 그 외의 속성은 프로그램 실행 중에 바뀌는 경우가 없었으므로 Inspector를 주로 사용하여 Text 속성 설정


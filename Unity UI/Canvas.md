# Canvas - Unity UI

### Canvas

- Canvas는 UI 요소들을 배치 하기 위하여 사용하며 UI 요소들을 자식으로 가진다.
  - UI 요소 : Text, Raw Image , Image ,  Button, Toggle, SlideBar, DropDown, InputField etc
- UI 요소는 모두 Canvas에 속해있어야한다.  
  - Canvas를 생성하지 않아도 UI 요소를 추가하면 Canvas 자동 생성됨
- 계층 구조(Heirarchy)에서 Canvas 정렬된 자식 순으로 그림이 그려진다. 
  - 만약 화면에서 겹쳐지는 경우 먼저 오는 자식이 먼저 그려진다.
    - ex) Canvas - Image1 , Image2 순으로 계층구조에 있다면 Image2가 Image1위에 그려진다. 
  - 계층 구조를 직접 드래그 하여 순서 변경 가능하며 스크립트 상에서 Transform 컴포넌트의 함수 ( SetAsFirstSibling, SetAsLastSibling, SetSiblingIndex) 를 사용하여 순서 변경이 가능하다. 
- EventSystem 게임 오브젝트가 Canvas를 추가 하면 생기게 되는것을 볼 수 있는데 메시지 시스템 즉, 클릭 등과 같은 작동을 하기 위해 사용한다. 
- 한 씬에는 여러개의 Canvas를 만들 수 있다.



#### Render Mode

렌더링을 설정하기 위함

##### Screen Space - Overlay

- Default로 다른 게임 오브젝트 위에 렌더링된다.
- 화면의 크기 및 해상도가 변경되어도 상관없이 자동으로 조절된다.
- Pixel Perfect를 통해  픽셀과 정렬하여 요소를 선명하게 표시되기 위해 사용.



##### Screen Space - Camera

- 특정 Camera를 설정하여 Canvas가 지정된 거리만큼 Camera 앞에 위치

- Camera에 따라 UI 요소들의 모양에 영향

  *주로 Render Camera에 Main Camera지정하여 개발*

  

##### World Space

- Canvas가 일반적인 오브젝트처럼 인식



## 개발 노트

- 주로 Screen Space - Overlay , Screen Space - Camera를 사용하여 구현

  - Screen Space - Overlay : 주로 UI 프레임 등을 구현할 때 사용
    - 사용자에게 점수 판을 알려주는 Text 부분이 흐릿하게 보이는 현상 발생 => Pixel Perfect를 사용
  - Screen Space - Camera :  주로 실제 게임 동작할 때 사용하는 게임 요소 구현 할때 사용 

  

- EventSystem이 삭제된 경우 Button이 클릭 되지 않는 등의 문제 발생



- Canvas 내의 UI  요소들의 계층 구조를 스크립트로 이용하여 변경하기도 함.

  - 예 : 드래그 앤 드롭 기능 구현할 때 사용자가 클릭한 요소가 무조건 화면 앞에 나오도록  구현

  
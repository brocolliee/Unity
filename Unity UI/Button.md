# Button - Unity UI

class in UnityEngine.UI

### Button

- 클릭할 수 있는 일반적인 버튼으로 많이 사용

- 주로 onClick를 이용하여 버튼을 눌렀을 때 실행 되는 기능을 구현 (UnityEvent)

- 버튼 이벤트 할당 

  - Inspector를 이용하여 추가 가능 (OnClick)
  - ButtonClickedEvent 클래스 함수를 통해 스크립트상에서 버튼 클릭 Event  할당 (주로 비 지속성일 때)

  

  자세한 사항은 [Unity Button 사이트]( https://docs.unity3d.com/kr/530/ScriptReference/UI.Button.html ) 참고

- Implement interfaces ( UnityEngine.EventSystems)

  - [IDeselectHandler](https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IDeselectHandler.html)
  - [IEventSystemHandler](https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IEventSystemHandler.html)
  - [IEventSystemHandler](https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IEventSystemHandler.html)
  - [IMoveHandler](https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IMoveHandler.html)
  - [IPointerClickHandler](https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IPointerClickHandler.html)
  - [IPointerDownHandler](https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IPointerDownHandler.html)
  -  [IPointerEnterHandler](https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IPointerEnterHandler.html)
  - [IPointerExitHandler](https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IPointerExitHandler.html) 
  - [IPointerUpHandler](https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IPointerUpHandler.html)
  -  [ISelectHandler](https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.ISelectHandler.html)
  - [ISubmitHandler](https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.ISubmitHandler.html)

  

  단순히 클릭했을 때 뿐만 아니라 그 외 추가 기능을 추가 하고 싶을 때 사용

  

#### ButtonClickedEvent

- 버튼 클릭 이벤트에 대한 함수 정의 하는 클래스

-  버튼에 할당된 이벤트에 관한 함수 존재

  - **AddListener**
  - Invoke
  - **RemoveListener**
  - GetPersistentEventCount
  - GetPersistentMethodName
  - GetPersistentTarget
  - **RemoveAllListeners**
  - SetPersistentListenerState

  

  자세한 사항은 [Unity ButtonClickedEvent 사이트]( https://docs.unity3d.com/kr/530/ScriptReference/UI.Button.ButtonClickedEvent.html ) 참고

  

## 개발 노트

- 주로 Inspector를 사용하여 버튼에 이벤트 할당

- 비 지속성 이벤트를 할당할 때 AddListener과 RemoveListener 함수를 사용하여 이벤트 할당



- 드래그 앤 드롭을 사용할 때 게임 요소는 버튼으로 만들고 IBeginDragHandler, IEndDragHandler, IDragHandler를 사용하여 버튼을 드래그 시작, 드래그 하는 중 , 끝났을 때 필요한 기능 추가하였다. 

  - [IBeginDragHandler]( https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IBeginDragHandler.html )의 OnBeginDrag(PointerEventData eventData)  사용
    - 드래그가 시작되기 전에 BaseInputModule에 의해 호출
  - [IDragHandler]( https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IDragHandler.html )의 OnDrag(PointerEventData eventData) 사용
    - 드래그가 발생하는 경우, 커서가 움직일 때마다 호출
    - 드래그되고 있는 게임 요소의 위치를 가지고 올 때 사용
  - [IEndDragHandler]( https://docs.unity3d.com/kr/530/ScriptReference/EventSystems.IEndDragHandler.html )의 OnEndDrag(PointerEventData eventData) 사용
    - 드래그가 종료 시 BaseInputModule에 의해 호출
    - 드래그가 끝난 게임 요소의 위치 계산 및 조정할 때 사용

  
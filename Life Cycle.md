# Unity Life Cycle (생명주기)

### MonoBehaviour

- MonoBehaviour은 모든 유니티 스크립트가 상속받는 기본 클래스로 C#에서 명시적으로 상속 받는다.

~~~c#
public class ClassName : MonoBehaviour
{ ...} 
~~~

- MonoBehaviour 는 기본으로 여러가지 변수와 함수를 제공한다. ([자세한 사항]( https://docs.unity3d.com/kr/530/ScriptReference/MonoBehaviour.html ) 은 유니티 사이트를 참고)



### 생명주기

- 보통 유니티 생명주기, 스크립트 생명주기, MonoBehaviour의 생명주기라고 한다.

- MonoBehaviour에 있는 멤버 함수 중 사용자가 호출 하지 않아도 호출 되는 함수들의 순서를 의미한다. 

- 순서는 변경될 수 없으며 Unity에서 개발 할 때 알아두면 유용한 함수들이 존재한다.
- 유니티 사이트에서 찾은 생명주기 이미지

 <img src="https://docs.unity3d.com/kr/current/uploads/Main/monobehaviour_flowchart.svg" alt="Unity Life Cycle" style="zoom:45%;" /> 

- **주요 함수**

  - **Awake** : 씬이 처음 로드 될 때, 스크립트가 실행될때 처음에 한번 호출된다. 모든 게임 오브젝트가 초기화 된 후 호출 되므로 다른 게임 오브젝트를 연결 시켜주는 GameObject.Find()를 안전하게 사용할 수 있다.  Start 함수 전에 호출되므로 초기화 해줄때 주로 사용한다. 각 게임 오브젝트 별 Awake()의 순서는 임의의 순서로 호출된다. 스크립트가 활성화 여부에 상관 없이 호출 되기때문에 Coroutine을 사용할 수 없다. 
  - **OnEnable** : 게임 오브젝트가 활성화 될 때 마다 호출 되는 함수이다.
  - **Reset** : 게임 오브젝트에 스크립트가 처음 연결 될때 혹은 Reset 명령어를 사용 할 때 스크립트의 속성을 초기화하기 위해 호출 된다.
  - **Start** : 첫 프레임이 업데이트 되기 전에 호출 되는 함수로  Update 되기 바로 직전에 호출 된다.  Start도 한번 호출이되지만 Awake와 다르게 스크립트가 활성화된 경우에만 호출 한다.
  - **FixedUpdate** :  Update와 다르게 매 고정된 프레임율의 프레임마다 호출된다. 즉 고정된 프레임마다 힘을 작용할 때와 같이 고정된 프레임을 사용할 때 호출 한다. 0.02초 마다 오브젝트별로 호출한다.
  - OnTriggerXXX
  - OnCollisionXXX
  - **Update** : 게임 오브젝트가 활성화 되어있을 때 프레임당 한번씩 호출되는 함수로 주로 많이 사용한다.  프레임 단위이기 때문에 시간 간격이 고정되어있지 않다.
  - **LateUpdate** : 모든 Update 뒤에 호출 되는 함수로 Update에서 움직인 캐릭터 따라가는 카메라와 같은 기능을 사용할 때 호출한다.
  - **OnDisable** : 비활성화되는 경우, 오브젝트가 제거되는 경우에 사용된다. 
  - **OnDestroy** : 오브젝트를 없앨 때 오브젝트가 마지막 프레임의 업데이트를 모두 마친 후에 호출된다. 
  - **OnApplicationQuit** : 어플리케이션 종료 전 모든 게임 오브젝트에서 호출된다. 

  주로 Awake, OnEnable, Start, Update 함수를 사용했다. 


# APK Debugging

- APK 가 돌고 있는 모바일 기기를 USB로 연결 한 뒤 디버깅 하기
- Unity에서 cmd 창을 띄워 로그캣을 확일 할 수 있음

- sdk의 platform-tools를 사용해서 디버깅 가능



#### 사용 방법



1. Android sdk 폴더의 platform-tools 폴더로 이동 한 뒤 cmd 창 실행

   - Unity Editor안에 있는 AndroidPlayer SDK platform-tools 사용 가능
     - path : "C:\Program Files\Unity\Editor\Data\PlaybackEngines\AndroidPlayer\SDK\platform-tools"
   - 설치 환경마다 다를 수 있음

   

2. cmd 창에 `adb logcat -s Unity`명령어 입력

   - adb logcat은 기기에서 발생하는 로그 출력
   - -s Unity 옵션을 통해 필요한 부분의 로그 출력
   - Unity는 무조건 U는 대문자로 입력

   - 안드로이드 스튜디오 설명서 :  [adb 명령어](https://developer.android.com/studio/command-line/adb?hl=ko ) 


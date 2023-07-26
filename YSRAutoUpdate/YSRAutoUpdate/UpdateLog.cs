﻿// 2022-01-16 포스트 캡쳐 기능

// 2022년 8월
/*
    // 2022-08-16 환경설정 xml 일부 저장기능

    // 2022-08-18 로그가 실행이 드디어 됨. 그러나 너무 길어진 거 같음. 그럴바에 메인에 로그 넣는게 낫지 않나

    // 2022-08-19 비활성 마우스 입력이 안되는 것 같다.
    // 2022-08-19 텍스트만 썼는데도 불구하고 메모리가 조금씩 올라간다 해결 방법은?

    // 2022-08-22 질문창 Y가 클릭이 안되어서 SIK (키보드 입력으로 대체) PostMessage 로 해도 되는 것인가?
    // 2022-08-22 키보드 입력 대신 SendMessage 버튼 클릭으로 대체

    // 2022-08-24 32비트로 이미지 교체 완료, 이미지 비교 시 32비트로 비교를 해야하는데 24비트는 안된다. 캡처 도구 로만 캡처하자(알캡처, 포토샵 안됨 ㅠ.ㅠ)
    // 2022-08-24 24비트로 비교하려면 비트 변환을 해야한다.
    // 2022-08-24 AppPlayerName을 쓰는 지역변수가 있어서 공유를 할 수 없었다. 변경 해주니 전역변수로 공유 할 수 있었다.

    // 2022-08-25 while문 중 두 줄이상에서 값이 변했는데 안나오는 이유를 모르겠다. >> while문은 반복을 완료하고 값을 검사한다.
    // 2022-08-25 while문에서 SendMessage랑 잘 안맞는가 보다. 계속 멈추는 이유를 찾았다. PostMessage로 바꾸니 작동을 한다.
    // 2022-08-25 한꺼번에 업데이트가 안되어 하나씩 업데이트 하기로 하였다.
    // 2022-08-25 창 찾는중...3 에서 종료되어 넘어가지 않고 무한 루프를 한다.

    // 2022-08-26 while은 빨리 돌기 때문에 Delay를 걸어놔야한다.
    // 2022-08-26 send로 다시 바꾸었다.
    // 2022-08-26 'YSRAutoUpdate' 로 바꾸었다.
    // 2022-08-26 로그 출력 문자들을 정리해보려 했으나 완성 못시켰다.

    // 2022-08-29 로그 폰트 문제였다.
    // 2022-08-29 post로 다시 바꾸었다. post= 쪽지만 보내기, send 바로 답장 받기
    // 2022-08-29 자동모드 진행 중 추가
    // 2022-08-29 자동모드를 스레드로 바꿈
    // 2022-08-29 while문을 넣으면 폼이 안보임

    // 2022-08-30 폼 띄우기 전에 while 문이 들어가버렸던 문제 해결
    // 2022-08-30 스레드로 나뉘었으나 Join.. 문제 생김 원인 불명

    // 2022-08-31 send로 바꿈, 핸들 항상 위로. 핸들 숨기기 등 넣음.
*/

// 2022년 9월
/*
 * 01 labelProgressBar1, 2 추가, DB 미연결 시 오류 추가, YSR2000 - SQL Anywhere 네트워크 서버, WATCOM SQL NT234c 비활성 DB 네트워크 추가, 자동모드 종료 추가
 * 05 labelProgressBar 최대값 자동 변경 기능 구현, 여러가지 추가하였으나 추후 자세히 기재, 콤보값 변경 시 자동 변경 기능... 미구현,
 * 06 이미지 오류, 파일 다시 추가로 해결, comboBox1.SelectedIndex = 0 으로 초기화 구현
 * 07 메시지2 계산이 좀 걸리는 듯 함. 확인 해서 다시 바꿀지 결정해야할 듯. >> 단순 디버그 오류 인 듯,
 * 07 TETBL 자동 업데이트에 설정값을 넣기, 자동 업데이트 중에는 TETBL 설정 막기
 * 07 자동모드중_스레드 오류 수정
 * 07 SelectedIndexChanged 에서 SelectionChangeCommitted 로 변경.
 * 13 기존 네트워크가 있으면 종료 시키고 네트워크 실행하여 연결되는 것을 확인하고 다음으로 넘기는 것 적용.
 * 13 TETBL 최소화 시켰음.
 * 14 TETBL 최소화 기능 유무를 저장하고 불러오기 넣음.
 * 19 Custom Title Bar 구현, == > label로 타이틀명, TrackBar로 Opastiy, X버튼 = Application.Exit().
 * 19 label과 tableLayoutTable 마우스 다운 시 창(handle) move 적용.
 * 20 화면 최상위 해제 기능, 최상위 이미지, taskbar 표시, 최소화, 아이콘 추가, 최상위 설정 저장, 버젼번호 추가, 로그 저장, 폼 실행 후부터 함수 실행.
 * 21 셋폼을 만드는 중...
 * // 파일경로를 가져왔지만 lnk파일은 타겟 주소만 가져온다....
 * lnk파일 주소만 가져오는 것 성공! 
 * 학장자명을 제거 해 줄 수 없나? => 성공!
 * 22 버튼을 마우스 가져가거나 벗어나면 배경색 변경(// x 표시 가까이 대면 빨갛게, -는 회색)
 * 26 // System.NullReferenceException: '개체 참조가 개체의 인스턴스로 설정되지 않았습니다.'
 * => 메인에서 셋폼까지 건드려고 해서 오류, 비껴서 따로 함수 만듦.
 * 26 설정창 위치를 기존창 위치로 변경.
 * 26 설정창 로드, 저장기능 구현 (설정환경2), FormClosing 일 때 저장하기
 * 27 설정 변수들 수정 중...
 * 28 설정 변수 중 콤보 박스 관련 수정 완료...
 * 29 환경설정 모두 불러와야 콤보1,2,3 선택 가능함. enabled = true;
 * 29 콤보3 병의원이름 연동완료.
*/

// 2022년 10월
/*
 * 04 환경설정 모두 불러오면 각종 버튼들 사용할 수 있게 변경
 * 04 자동 업데이트 환경설정과 연동 완료, 지정된 파일이 없을 시(2번째) return
 * 04 콤보3 값 오류에 대한 대처.
 * 04 TETBL 주소 부분 수정
 * 25 메시지박스 제거, 닫기 오류 대처 등록, 중복 실행 방지, 디비 중복 방지
 * TETBL 이미지 인식 or 예 아니오 문제인 듯.... >>> 눈이 안좋아서 글자크기를 올렸더니 그게 문제 다시 원상 복귀 >> 정상 작동
*/

// 2022년 11월
/*
 *  18일 각 의원 별 최종 성공 TETLBL숫자 저장 및 표현 업데이트 시작
 *  21일 업데이트 시 버튼,콤보박스 변경 불가 후 변경 가능으로 업데이트 하였음.
 *  28일 새로 설정해주세요 라고 되어 있을 경우 오류 라고 말해주면서 설정하게 유도.
 */

// 2022년 12월
/*
 *  12일 성공 업데이트 로그 반영하여 저장하고, 표시하고, 자동 업데이트를 바로 중지할 수 있도록
 *  13일 성공 업데이트 로그 불러오기 설정, 콤보박스 설정 시 불러오기
 */

// 일시중지 또는 정지 버튼 등을 설정하려고 하였으나 스레드를 실행하였는데 스레드 상태가 변경이 안됨.


// >> 임의로 설정해보려함.


// 파일, 주소 = NuGet에서 WindowsAPICodePack-Core 1.2, WindowsAPICodePack-Core-Shell 1.2 설치

// 텍스트박스 숫자만 입력가능하게 하였다. keypress+imemode(disable)


// 업데이트 내역도 저장(성공내역) 할까?

// NuGet 패키지 정리하여 용량을 줄이기 (필수는 제외, 예.OpenCV)
// 전체함수에 추가하기 l = null;                                                               // 3. 리소스 반환
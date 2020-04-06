# Pokey Ball source code

![ezgif com-video-to-gif](https://user-images.githubusercontent.com/62490237/78562054-b5723180-7853-11ea-89f8-5446fbcd5137.gif)

### 1. Player

* #### Swipe 강도 에 따른 Transform을 이용한 Shakeing 구현
   
![2](https://user-images.githubusercontent.com/62490237/78562371-33363d00-7854-11ea-93bb-656c30aeda5d.gif)
      
   * #### NomalMode 및 OverPower 모드에 따른 최대 점프 높이 및 TrailRenderer을 이용한 색상 변화 구현

![3](https://user-images.githubusercontent.com/62490237/78562933-21a16500-7855-11ea-81e8-0ce22ea4fdf7.gif)   

   * #### Jump 중 화면 터치 Raycast를 이용한 해당 Block Tag 및 좌표값 구하여  Particle 및 HitEffect 생성  
   
![4](https://user-images.githubusercontent.com/62490237/78563943-b22c7500-7856-11ea-9e95-87158ceb7dd1.gif)

            
### 2. Damper   

![5](https://user-images.githubusercontent.com/62490237/78564245-19e2c000-7857-11ea-9a22-dc1e3cc3f5cf.gif)

  * #### 화면 터치 좌표값을 이용한 Swipe 강도에 따른 DmaperPower 증가 및 Angle 변화 구현  
  * #### HingeJoint를 이용한 물리력 전달 구현
   
### 3. Block   
     
  * #### Tag를 이용한 Block 구분하여 해당 동작 구현
    * ##### NonBlock : Player가 매달릴 수 있는 Block
    
![N](https://user-images.githubusercontent.com/62490237/78565007-38958680-7858-11ea-9de8-91411bd56e4b.gif)

   * ##### DestoryBlock : Player가 파괴할 수 있으며 파괴시 Instantiate 및 Rigidbody를 이용한 파편 구현
    
![D](https://user-images.githubusercontent.com/62490237/78565077-582caf00-7858-11ea-8364-f9d6a93934a9.gif)    
    
   * ##### NonBlock : 파괴 및 매달릴 수 없는 Block
    
![B](https://user-images.githubusercontent.com/62490237/78565044-4ba85680-7858-11ea-986c-7dbda3ce06c6.gif)

   * ##### GameOverBlock : SceneManager를 통한 GameOver 구현
  
  
### 4. Camera   
   
  * #### Camera Transform 및 FixedUpdate,Vector.Lerp를 이용한 swipe 강도에 따른 점점 멀어지고 다시 돌아오는 Cam 구현  
  * #### Player의 상태에 따라 멀어지는 최대값 변하도록 구현
  
![6](https://user-images.githubusercontent.com/62490237/78566391-1d2b7b00-785a-11ea-9769-fbf7ec16c3ba.gif)  
  
  * #### FollowCam을 활용한 Jump 할 경우 Player 추적 구현
  
### 5. Object   
   
  * ##### Coin : Rigidbody의 isTriger를 이용한 충돌시 코인 획득 구현
  * ##### Targrt : Raycast를 이용, 충돌 좌표 확인하여 센터 확인하여 Player의 상태 변경 및 점수 획득 구현

### 6. UI   
   
  * #### Coin,Score : Coroutine 활용하여 점수 획득 시 카운팅되며 점수 증가 및 alpha를 이용하여 점점 사라지도록 구현
  * #### Distance : 골인 지점과 Player의 Distance를 구해 Filled를 이용하여 stage의 진행 상태 구현
  
  ![ezgif com-video-to-gif](https://user-images.githubusercontent.com/62490237/78566614-75627d00-785a-11ea-8631-6cfe9d7cd848.gif)

### 7. GamePlay
   
   
### [Youtude Clieck](https://youtu.be/cr5uJMM4LxA)

# THANK YOU!!!!
 

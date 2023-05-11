# Makerspace iOS
- Implement virtual NYU MakerSpace in Unity for the iOS/iPadOS platform.
- VIP Metaverse for Education

## Current Progress
- Added makerspace scene with minimal furnitures
- Added basic player movement and camera control

## Build
Hardware requirements (The below steps are for having both, but you may still 
be able to build this in some other ways):
- an iPhone/iPad
- a Mac

Software requriements:
- Unity
- XCode

Steps:
- Enable developer mode on your iPhone/iPad
- Connect your device with the Mac with a cable and trust the device
- Clone and open this project in Unity
  - Open the top-level-scene from Assets/Scenes
    you should be able to see the room
  - Shift+CMD+B OR Menubar -> File -> Build Settings
    - Select iOS platform, click Switch Platform, and install tools if not already
    - Click on Build and Run, select a build directory of your choice
    - It should now build and redirect you to XCode
  - In your XCode, it should display one error related to the developer profile
    - Resolve the error by logging into your developer account 
    - Now the XCode should build
  - Unlock your device. It should now open the build for you.

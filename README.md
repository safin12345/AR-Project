# MyProj - AR Application

## Background
During my final year, I undertook a compelling project—a dissertation centred on developing an Augmented Reality application using Unity and C#. This innovative app replicated real-time measurement capabilities and enabled the placement of life-sized objects, resembling the functionality of IKEA's AR app. However, a significant challenge surfaced: while IKEA's app was exclusive to iOS due to its Lidar scanner, I resolved to develop a counterpart for Android users.

Upon completion, I conducted a rigorous series of tests to evaluate accuracy discrepancies, revealing that my Android application boasted a remarkable precision rate of 98.4%.

## Instructions to Run the App

1. **Device Requirements**:
   - Ensure you are running on an Android device with a minimum API level of 24.

2. **Project Setup**:
   - Import the project into Unity.
   - Alternatively, you can load the project by navigating to:  
     `MyProj > Assets > Scenes`
   - Open the following scenes:  
     `ARUI`, `MeasureTool`, `BasicARScene`, and `MainMenu`.

3. **Running the Project**:
   - Open the scenes, then click `File > Build and Run` (Top Right in Unity).
   - Ensure your Android device is:
     - Plugged into your computer.
     - Has USB debugging enabled.
     - File transfer is enabled.
   
   If the project does not run, navigate to `File > Build Settings > Android` and set the **minimum API level** to 24.

4. **Customization (Optional)**:
   - To increase the number of objects that can be placed in a scene:
     - Navigate to: `BasicARScene > Hierarchy window > AR Session Origin`.
     - In the **Inspector window**, scroll down to find `SpawnOnPlane`.
     - Adjust the value of `MaxPrefabSpawnCount` to increase or decrease the limit.


## Instructions to Use the App

1. **Permissions**:
   - The app will prompt you for access to your camera. Please grant permission if comfortable.

2. **Main Menu**:
   - After the app launches, press the button at the bottom of the screen to start.

3. **Scanning Mode**:
   - You will be in scanning mode after an initialization screen. Slowly move your camera until it switches to the next scene (furniture mode).

4. **Furniture Mode**:
   - On the right-hand side, you'll see 5 buttons:
     - The **first button** removes the last object placed.
     - The buttons below allow you to select different types of furniture.
   - To place furniture:
     - Select a type, then tap anywhere on the screen where a dotted plane is visualized.
     - **Note**: There is a known bug with frames, which may cause them to not function as intended.

5. **Measure Mode**:
   - Press the button at the top of the screen to enter **measure mode**.
   - Move the device until the app displays a dotted plane in the scene.
   - Tap on the plane to place nodes. Tapping a second location will show the distance between the two points. You can add as many points as you'd like!
   - **Note**: Switching between metric systems is currently non-functional.


## Instructions to View the Code

- Navigate to:  
  `MyProj > Assets > Scripts`
- There are 3 scripts that are not my own but are required for part of the project (this is mentioned in the project report). These scripts are:
  - `InteractionController`
  - `UIController`
  - `Singleton`
  - Feel free to view them, but please note they are not my original work.


## Other Notes

- There is an imported module called `ARFSample`. Please ignore this folder as it has no direct relevance to the project.
- However, it was needed for its **plane debug visualizer prefab**, which allows you to visualize detected planes.

---

Thank you for trying the app! It’s not perfect yet, but it's a step in the right direction!

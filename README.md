# Build notes, etc. 

### To Convert a App module in Android Studio to a Library: 

1. Open Android Studio (I'm on Hedgehog | 2023.1.1 Patch 2),
2. New Project,
3. Phone and Tablet > "No Activity",
4. Fill out the new empty project details (I'm calling mine HelloJava),
5. Finish and wait for sync....
6. Select Project from the drop-down in the project pane to view the project files,
7. Expand "app", double click "build.gradle.kts",
8. Find the "plugins" section and convert "com.android.application" to "com.android.library".
9. Find the "defaultConfig" section, and remove lines for "applicationId", "versionCode", "versionName", "targetSdk" (is deprecated)


### Notes on creating an Android library that utilizes ACS

- Minimum SDK version must be API 26: Android 8.0 (Oreo) or greater. 
- Need to update 'build.gradle.kts' to have `implementation("com.azure.android:azure-communication-calling:2.6.0")` under "dependencies". 
- Permissions that are required (for basic demo): INTERNET, ACCESS_NETWORK_STATE, ACCESS_WIFI_STATE, RECORD_AUDIO, CAMERA, WRITE_EXTERNAL_STORAGE, READ_PHONE_STATE

### Links and handy tidbits: 
- https://developer.android.com/studio/projects/android-library
- https://learn.microsoft.com/en-us/azure/communication-services/quickstarts/voice-video-calling/getting-started-with-calling?pivots=platform-android&tabs=uwp
- If Intellisense stops working: File > Build > Rebuild Project, and then File > Invalidate Caches > Invalidate and Restart. Intellisense works again. 
- To find the dependencies: a) [Environment]::SetEnvironmentVariable('JAVA_HOME', "D:\Program Files\Android\Android Studio\jbr") to set JAVA_HOME, then b) .\gradlew.bat app:dependencies in the "HelloJava" project dir. This will show all of the dependency tree. 

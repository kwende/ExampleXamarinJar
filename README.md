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
9. Find the "defaultConfig" section, and remove lines for "applicationId", "versionCode", "versionName"
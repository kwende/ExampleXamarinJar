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
- Some notes on JARs/AARs in general and how they interact with Xamarin and can be used w/ ACS
    1) First, it's important to remember/note that JARs and AARs don't have built-in mechanisms for maintaining dependency lists, this is the job of tooling (such as maven).
    2) Because of this, you have to use _tools_ (such as gradlew.bat) to procure the list of dependencies.
    3) Therefore, if I wish to build a JAR/AAR, but then include with it all of its dependencies within an APK, I would have to do the following: 
        1) First, add a couple "functions" or commands to your build.gradle.kts build script for your AAR project. Functions can be called via the gradle wrapper to invoke the gradle engine and its functionality: 

        ```
        tasks.register("printConfigurations") {
            doLast {
                configurations.forEach { println(it.name) }
            }
        }

        tasks.register<Copy>("copyDebugDependencies") {
            from(configurations.getByName("debugRuntimeClasspath"))
            into("$buildDir/libs/debug")
        }
        ```
        what these functions do is allow you to print the various configurations (of which debugRuntimeClasspath is one) and use the configurations to copy dependencies; one of which is debugRuntimeClasspath. I'm not 100% sure how this 
        works, but functionally it gets the list of all dependencies and transitive dependencies and feeds it to the "from" function. The "into" function seems to take this list and copy the files in the list to the directory specified. In short: 
        this function gets all the dependencies and dumps them into a single directory. 
        
        2) Then invoke these functions using gradlew. First: *gradlew.bat printConfigurations*. This should list the configuration options. Look for "*runtimeClassPath" and choose the appropriate one to replace "debugRuntimeClasspath"
        in the getByName function (or keep debugRuntimeClasspath if appropriate). This will dump the dependency tree into *$buildDir/libs/debug*
        3) And now that you have all of the JAR/AAR file that are dependencies for your, copy the JAR files to the binding library. And the AAR files to a sub-folder in your Xamarin Android project. 
        4) For the JAR files, unload the project and edit the project file. Make sure Bind="false" is applied to each of the references, and that the JAR references are included as "AndroidLibrary". 
        5) You will then need to build the Android project w/ the binding project. A lot of the libraries are going to be ones that are already referenced by the build engine, and so you'll have to weed those out. I did so by looking at errors associated
        with build and removing the files that were obviously associated with it. 
        6) Then you will need to set the AAR files to "AndroidLibrary" as well and also set Bind="false" for them. You will then need to weed those out as well. 

### Links and handy tidbits: 
- https://developer.android.com/studio/projects/android-library
- https://learn.microsoft.com/en-us/azure/communication-services/quickstarts/voice-video-calling/getting-started-with-calling?pivots=platform-android&tabs=uwp
- If Intellisense stops working: File > Build > Rebuild Project, and then File > Invalidate Caches > Invalidate and Restart. Intellisense works again. 
- To find the dependencies: 
    1) [Environment]::SetEnvironmentVariable('JAVA_HOME', "D:\Program Files\Android\Android Studio\jbr") to set JAVA_HOME, then 
    2) .\gradlew.bat app:dependencies in the "HelloJava" project dir. This will show all of the dependency tree. 


# UnityAndroidLifecycleSkeleton
A skeleton unity application to see how lifecycle events appear on android.

This app is deliberately very basic, just enough to see the lifecycle in Android and to show how we can load and save state when the lifecycle events occur.  The app just lets you press a button that increments a number and that number survives the app being kicked out of memory and then reloaded.

## How to use this
-   Clone the repository to somewhere useful on your disk.
-   Start `Unity3d` and from the launcher choose `Open`
-   Select the folder you've cloned into

`Unity3d` should open the project and digest it all automatically, regenerating various .sln and .vcproj files.

The project build should be set to Android automatically so you just need to get your device connected via `adb` in whatever manner you prefer then use `build and run` to deploy the app.

Once deployed you can use `adb logcat -s Unity:*` to see the log messages coming from the app.


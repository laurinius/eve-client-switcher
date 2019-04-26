---
#EVE Client Switcher -
---
created by Laurinius

1 - About EVE Client Switcher
----------------------
EVE Client Switcher lets you switch between your EVE client windows or minimize all client windows at once with simple hotkeys.
It was designed for being used with clients running in "Fixed Window" mode and provides two advantages over e.g. using "Alt-Tab":

a) Performance
When you use "Alt-Tab" the old window does not get minimized and stays in the background but active, which has an impact on performance (CPU-/GPU-Load).

Even more I found some glitches with "Fixed Window" windows not being minimized the right way when using for example the "Show Desktop" button in the taskbar.
This leads to each client looking like they are minimized, but are putting an entire core of your CPU under full load (more CPU load than if they where active).

EVE Client Switcher minimizes the other windows when switching to the next one or with the second hotkey minimizes all of them.
The windows minimized through EVE Client Switcher are minimized and "de-focused" correctly, so the CPU-/GPU-Load is minimized as well.

b) Convenience
With EVE Client Switcher you switch directly between EVE clients or minimize all EVE clients without having to deal with the windows of other applications.

2 - Requirements
----------------
- EVE clients running in "Fixed Window" or "Window Mode" (designed for "Fixed Window")
- .NET Framework is required
(tested with .NET 4.5.1 on Windows 7)

3 - Usage
---------
Just start the Program, no installation needed.
It will start directly minimized to the tray, where you can either right-click for a menu or double-click to open the settings directly.

In the settings you can define two hotkey, one for switching between EVE client windows and one for minimizing all EVE client windows.
The default is ALT+SHIFT+S for switching and ALT+SHIFT+X for minimizing.
If you click the "Set & Save" button it registers your choices and saves them in "ecs.dat" at the location of the exe-file.

Minimizing the settings window will set it back to the tray, closing it will close the program as well.

4 - Notes
---------
This tool does in no way modify or manipulate the EVE client.
It uses functions provided by Windows for changing window states (like minimizing, restoring, focusing).

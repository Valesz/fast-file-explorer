# Fast File Explorer

Fast File Explorer is a console application for fast file management with only the keyboard to maximize efficency. With this application you don't need to spend time navigating between your mouse and keyboard, so you can be as productive as you can be! 

This project was created for a university course where we learned about developing with modern principals in C#. Although those principles apply generally.

## Technologies

- .NET 8
- C#

## Installation

1. Build the project.
2. Copy the Config directory to the built path.
3. Add the application to your path variables.
4. Use it where ever and whenever you like!

## Making your own configuration:

Just modify the Config.json file in the Config folder to your liking.

### Key Commands

Key commands are a type of commands that can be activated by a single key press.

Set the **Key** property to a **ConsoleKey** value to activate the Action paired to it! <br>
You can also apply shift, alt, ctrl modifiers to it. <br>
(See: `LeftArrow + ctrl + alt`)

For the **Action** property choose one from the available Key commands which you can find below.

Also don't forget to set the **Type** property to `KeyCommand`.

## Line Commands

Line commands are activated by a key command which you can specify. (As default it is `I`)

Set the **Key** property to the activation word. (Like: `grep`, `jump`)

Set the **Action** property to one of the available Line commands which you can see below.

Also don't forget to set the **Type** property to `LineCommand`.

## Available commands:

### Key commands:

- MOVE_UP
- MOVE_DOWN
- MOVE_TOP
- MOVE_MIDDLE
- MOVE_BOTTOM
- FIND_CHAR
- RELOAD_ENTRIES
- OPEN_FOLDER
- CLOSE_FOLDER
- NEW_WINDOW
- DELETE_WINDOW
- SWITCH_WINDOW_FIRST
- SWITCH_WINDOW_LEFT
- SWITCH_WINDOW_RIGHT
- SWITCH_WINDOW_LAST
- ITERATE (Only works with numbers)
- COPY_ENTRY
- PASTE_ENTRY
- DELETE_ENTRY
- SAVE_CONFIG
- READ_LINE_COMMAND

### Line commands:

- JUMP_TO_LINE
- GREP_STRING_CONTAINS
- GREP_REGEX
- FILTER_FILES
- FILTER_DIRECTORIES

## Credits

The application was developed by: Csonka Valentin Viktor

# TextFormatter
## About 
Simple and fast text formatter

## Installation

1. Build the project to get the executable

2. Add the directory containing TextFormatter.exe to your system PATH:
    - Windows:
        - Open System Properties → Advanced → Environment Variables

        - Add the directory path to the "Path" variable under System variables

    - Linux/macOS:
        - Add the directory path to your $PATH in .bashrc or .zshrc

## Usage
    in cmd/terminal

```tf "Your text" flags```

if you enter only ```tf```, then help list will be displayed

## Flags
-l    ```makes letters lowercase```

-h    ```makes letters capital```

-wc   ```print words count```

-cc   ```print chars count```
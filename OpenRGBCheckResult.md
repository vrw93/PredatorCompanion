=== PROTOCOL NEGOTIATION ===
SDK Protocol: 3

=== CONTROLLER AUDIT ===
Controllers: 3

Reading controller 0 ...

Current LED colors:

Index LED                       RawColor
----- ---                       --------
    0 Keyboard Backlight zone 1 0x0000FF00
    1 Keyboard Backlight zone 2 0x00FFFF00
    2 Keyboard Backlight zone 3 0x00FF00FF
    3 Keyboard Backlight zone 4 0x00FFFFFF


--- AcerHIDKeyboard Device ---
Vendor      : acer
Type        : 5
Data Size   : 904
Active Mode : 5
Modes       : 10
Zones       : 1
LEDs        : 4
Colors      : 4

Zones:

Index Name                    Type LEDsMin LEDsMax LEDsCount MatrixBytes
----- ----                    ---- ------- ------- --------- -----------
    0 Keyboard Backlight zone    1       4       4         4           0

Modes:

Name      Value SpeedRange BrightnessRange ColorsRange
----      ----- ---------- --------------- -----------
Direct      255 0 - 0      0 - 100         0 - 0
STATIC        0 0 - 0      0 - 100         1 - 1
BREATHING     1 1 - 9      0 - 100         1 - 1
NEON          2 1 - 9      0 - 100         1 - 1
OPMODE       34 0 - 0      0 - 0           1 - 1
WAVE          3 1 - 9      0 - 100         1 - 1
SHIFTING      4 1 - 9      0 - 100         1 - 1
ZOOM          5 1 - 9      0 - 100         1 - 1
METEOR        6 1 - 9      0 - 100         1 - 1
TWINKLING     7 1 - 9      0 - 100         1 - 1

First 12 LEDs:

Index Name                      Value
----- ----                      -----
    0 Keyboard Backlight zone 1     0
    1 Keyboard Backlight zone 2     0
    2 Keyboard Backlight zone 3     0
    3 Keyboard Backlight zone 4     0

Remaining bytes: 0

Reading controller 1 ...

Current LED colors:

Index LED            RawColor
----- ---            --------
    0 Mode Key LED 1 0x00000000


--- AcerHIDModeKeyLED Device ---
Vendor      : acer
Type        : 11
Data Size   : 464
Active Mode : 4
Modes       : 5
Zones       : 1
LEDs        : 1
Colors      : 1

Zones:

Index Name         Type LEDsMin LEDsMax LEDsCount MatrixBytes
----- ----         ---- ------- ------- --------- -----------
    0 Mode Key LED    0       1       1         1           0

Modes:

Name      Value SpeedRange BrightnessRange ColorsRange
----      ----- ---------- --------------- -----------
Direct      255 0 - 0      0 - 100         0 - 0
STATIC        0 0 - 0      0 - 100         1 - 1
BREATHING     1 1 - 5      0 - 100         1 - 1
NEON          2 1 - 5      0 - 100         1 - 1
OPMODE       34 0 - 0      0 - 100         1 - 1

First 12 LEDs:

Index Name                Value
----- ----                -----
    0 Mode Key LED 1 2924462432

Remaining bytes: 0

Reading controller 2 ...

Current LED colors:

Index LED              RawColor
----- ---              --------
    0 Cover Logo LED 1 0x00000000


--- AcerHIDCoverLogoLED Device ---
Vendor      : acer
Type        : 11
Data Size   : 472
Active Mode : 3
Modes       : 5
Zones       : 1
LEDs        : 1
Colors      : 1

Zones:

Index Name           Type LEDsMin LEDsMax LEDsCount MatrixBytes
----- ----           ---- ------- ------- --------- -----------
    0 Cover Logo LED    0       1       1         1           0

Modes:

Name      Value SpeedRange BrightnessRange ColorsRange
----      ----- ---------- --------------- -----------
Direct      255 0 - 0      0 - 100         0 - 0
STATIC        0 0 - 0      0 - 100         1 - 1
BREATHING     1 1 - 5      0 - 100         1 - 1
NEON          2 1 - 5      0 - 100         1 - 1
OPMODE       34 0 - 0      0 - 0           1 - 1

First 12 LEDs:

Index Name                  Value
----- ----                  -----
    0 Cover Logo LED 1 2924462432

Remaining bytes: 0

=== KEYBOARD MODE CHECK ===

Name      Value Flags
----      ----- -----
Direct      255    48
STATIC        0    80
BREATHING     1    81
NEON          2    17
OPMODE       34    64
WAVE          3    19
SHIFTING      4    83
ZOOM          5    81
METEOR        6    81
TWINKLING     7    81

Active Mode: 5
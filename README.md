# HapticsTweaker

Highly configurable controller haptics!

## Features
- **Haptics Customization**  
Fully customize the haptic duration and strength of Normal Notes, Chain Heads, Chain Links/Elements, Bad Cuts, Bombs, Arcs, Saber Clashes, and Wall Clashes!  
Arcs and clashes do not have a duration as they are continuous.

## How To Install
- Simply download HapticsTweaker.dll from [releases](https://github.com/BlqzingIce/HapticsTweaker/releases) and put it in your Plugins folder!
- Requires BSIPA, BSML, and SiraUtil
- Likely not compatible with any mods that modify haptics. Please disable Custom Haptics in Tweaks55 to avoid unintended behavior!
- Tweaks55 disables clash particles and haptics together, overriding this mod. Use Particle Overdrive or BS+'s GameTweaker to disable clash particles if you still want clash haptics!

## Config File
- The config file can be found at Beat Saber/UserData/HapticsTweaker.json
- `EnableMod`: Enables or disables all mod functionality
- `_____HapticDuration`: Controls the duration of the haptic impulse triggered, in seconds. Any non-negative value should work, but values above 1 second are discouraged
- `_____HapticStrength`: Controls the strength of the haptic impulse triggered, in percent of max. Represented by a float from 0-1.

## Credits
This mod is essentially my own take on SaberHaptics and I referenced a lot of code from it, and referenced a lot from Tweaks55 as well. Major thanks to GoldenGuy1000 and kinsi55 for their great mods.

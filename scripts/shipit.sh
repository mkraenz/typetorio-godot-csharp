#!/usr/bin/env bash
set -euxo pipefail

rm -rf .build
mkdir -p .build/linux

/home/mirco/programming/gamedev/godot4/Godot_v4.2.2-stable_mono_linux_x86_64/Godot_v4.2.2-stable_mono_linux.x86_64 --export-release 'Linux/X11' .build/linux/Typetorio.x86_64

/home/mirco/programming/gamedev/itchio-butler/butler push .build/linux mkraenz/typetorio:linux

# windows TODO
# mkdir -p .build/windows
# /home/mirco/programming/gamedev/godot4/Godot_v4.2.2-stable_mono_linux_x86_64/Godot_v4.2.2-stable_mono_linux.x86_64 --export-release 'Windows Desktop' .build/windows/Typetorio.x86_64
# /home/mirco/programming/gamedev/itchio-butler/butler push .build/windows mkraenz/typetorio:windows
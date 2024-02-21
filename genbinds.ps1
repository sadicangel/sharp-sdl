$src = "D:\Development\SDL\include";
$dst = ".\src\SharpSDL\Interop";
$log = "$dst\genbinds_log.txt";

$headers = 
"SDL_audio.h ",
"SDL_blendmode.h",
"SDL_clipboard.h",
"SDL_cpuinfo.h",
"SDL_error.h",
"SDL_events.h",
"SDL_filesystem.h",
"SDL_gamecontroller.h",
"SDL_guid.h",
"SDL_haptic.h",
"SDL_hints.h",
"SDL_joystick.h",
"SDL_keyboard.h",
"SDL_keycode.h",
"SDL_locale.h",
"SDL_log.h",
"SDL_main.h",
"SDL_messagebox.h",
"SDL_metal.h",
"SDL_misc.h",
"SDL_mouse.h",
"SDL_pixels.h",
"SDL_platform.h",
"SDL_power.h",
"SDL_rect.h",
"SDL_render.h",
"SDL_revision.h",
"SDL_rwops.h",
"SDL_scancode.h",
"SDL_sensor.h",
"SDL_shape.h",
"SDL_stdinc.h",
"SDL_surface.h",
"SDL_system.h",
"SDL_syswm.h",
"SDL_timer.h",
"SDL_touch.h",
"SDL_version.h",
"SDL_video.h",
"SDL_vulkan.h",
"SDL.h";

[System.IO.File]::Delete($log);

Get-ChildItem $dst -Filter "SDL.*" | ForEach-Object {
    [System.IO.File]::Delete($_);
}

[string[]] $generated = @();

$headers | ForEach-Object {
    $in = "$src\$($_)";
    $out = "$dst\$([System.IO.Path]::ChangeExtension($_.Replace("SDL_", "SDL."), ".cs"))";
    ClangSharpPInvokeGenerator `
        --file $in `
        --output $out `
        --language "c" `
        --libraryPath "SDL2" `
        --namespace "SharpSDL.Interop" `
        --methodClassName "SDL" `
        --prefixStrip "SDL_" `
        --nativeTypeNamesToStrip `
        "Uint8" `
        "Uint8 *" `
        "Uint16" `
        "Uint16 *" `
        "Uint32" `
        "Uint32 *" `
        "Uint64" `
        "Uint64 *" `
        "Sint8" `
        "Sint8 *" `
        "Sint16" `
        "Sint16 *" `
        "Sint32" `
        "Sint32 *" `
        "Sint64" `
        "Sint64 *" `
        --remap "sbyte=byte" `
        --config preview-codegen `
        --config generate-macro-bindings `
        --config generate-unmanaged-constants `
        --config exclude-using-statics-for-enums `
        --config exclude-funcs-with-body `
    | Out-File $log -Append
    #--config generate-file-scoped-namespaces `
    #--config generate-helper-types `
    #--config log-visited-files `
    
    $generated += $out;
}

$source = Get-Content -Path ".\fixbinds.cs";
Add-Type -TypeDefinition "$source";
[FixBinds]::Process($generated);
Flash:
      mov r0, #1        ; delay time
      mov r1, #2        ; pause time
      mov r2, #.green   ; flash on
      bl DrawPixel      ; draws pixel
      mov r2, #.white   ; flash off
      bl DrawPixel      ; draws pixel
      mov r2, #.green   ; flash on
      bl DrawPixel      ; draws pixel
      push {r0}
      mov r0, r1        ; change delay time to 2 seconds
      pop {r0}
      mov r2, #.white   ; flash off
      bl DrawPixel      ; draws pixel
      b Flash           ; loop Flash
      halt
DrawPixel:
      str r2, .Pixel367 ; draw pixel
      push {lr}
      bl Delay          ; Delay function
      pop {lr}
      ret               ; returns to Flash
Delay:
      ldr r3, .Time     ; set up time when start the function
Time:                   ; current time in loop
      ldr r4, .Time     ; set up current time in loop
      sub r5, r4, r3    ; subtract start time from current time to find time passed
      cmp r5, r0        ; compare time passed to start time
      bne Time          ; if branch is not equal go to time
      ret               ; returns to DrawPixel function